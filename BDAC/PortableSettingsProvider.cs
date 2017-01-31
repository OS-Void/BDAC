using System;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Xml;
using System.IO;
using System.Linq;

namespace BDAC
{
    public class PortableSettingsProvider : SettingsProvider
    {
        //XML Root Node
        private const string Settingsroot = "Settings";
        
        public override void Initialize(string name, NameValueCollection col)
        {
            base.Initialize(ApplicationName, col);
        }

        public override string ApplicationName
        {
            get
            {
                if (Application.ProductName.Trim().Length > 0)
                {
                    return Application.ProductName;
                }
                FileInfo fi = new FileInfo(Application.ExecutablePath);
                return fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
            }
            set
            {
                //Do nothing
            }

        }

        public override string Name => "PortableSettingsProvider";

        public virtual string GetAppSettingsPath()
        {
            //Used to determine where to store the settings
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            return fi.DirectoryName;
        }

        public virtual string GetAppSettingsFilename()
        {
            //Used to determine the filename to store the settings
            return ApplicationName + ".settings";
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals)
        {
            //Iterate through the settings to be stored
            //Only dirty settings are included in proposals, and only ones relevant to this provider
            foreach (SettingsPropertyValue propval in propvals)
            {
                SetValue(propval);
            }

            try
            {
                SettingsXml.Save(Path.Combine(GetAppSettingsPath(), GetAppSettingsFilename()));
            }
            catch (Exception ex)
            {
                //Ignore if cant save, device been ejected
                Console.WriteLine(ex.Message);
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {
            //Create new collection of values
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            //Iterate through the settings to be retrieved
            foreach (SettingsProperty setting in props)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(setting)
                {
                    IsDirty = false,
                    SerializedValue = GetValue(setting)
                };
                values.Add(value);
            }
            return values;
        }

        private XmlDocument _settingsXml;

        private XmlDocument SettingsXml
        {
            get
            {
                //If we dont hold an XML document, try opening one.  
                //If it doesn't exist then create a new one ready.
                if (_settingsXml == null)
                {
                    _settingsXml = new XmlDocument();

                    try
                    {
                        _settingsXml.Load(Path.Combine(GetAppSettingsPath(), GetAppSettingsFilename()));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //Create new document
                        XmlDeclaration dec = _settingsXml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
                        _settingsXml.AppendChild(dec);

                        XmlNode nodeRoot = _settingsXml.CreateNode(XmlNodeType.Element, Settingsroot, "");
                        _settingsXml.AppendChild(nodeRoot);
                    }
                }

                return _settingsXml;
            }
        }

        private string GetValue(SettingsProperty setting)
        {
            string ret;

            try
            {
                ret = IsRoaming(setting) ? SettingsXml.SelectSingleNode(Settingsroot + "/" + setting.Name)?.InnerText : SettingsXml.SelectSingleNode(Settingsroot + "/" + Environment.MachineName + "/" + setting.Name)?.InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = setting.DefaultValue?.ToString() ?? "";
            }

            return ret;
        }

        private void SetValue(SettingsPropertyValue propVal)
        {
            XmlElement settingNode;

            //Determine if the setting is roaming.
            //If roaming then the value is stored as an element under the root
            //Otherwise it is stored under a machine name node 
            try
            {
                if (IsRoaming(propVal.Property))
                {
                    settingNode = (XmlElement) SettingsXml.SelectSingleNode(Settingsroot + "/" + propVal.Name);
                }
                else
                {
                    settingNode =
                        (XmlElement)
                            SettingsXml.SelectSingleNode(Settingsroot + "/" + Environment.MachineName + "/" +
                                                         propVal.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                settingNode = null;
            }

            //Check to see if the node exists, if so then set its new value
            if ((settingNode != null))
            {
                settingNode.InnerText = propVal.SerializedValue.ToString();
            }
            else
            {
                if (IsRoaming(propVal.Property))
                {
                    //Store the value as an element of the Settings Root Node
                    settingNode = SettingsXml.CreateElement(propVal.Name);
                    settingNode.InnerText = propVal.SerializedValue.ToString();
                    SettingsXml.SelectSingleNode(Settingsroot)?.AppendChild(settingNode);
                }
                else
                {
                    //Its machine specific, store as an element of the machine name node,
                    //creating a new machine name node if one doesn't exist.
                    XmlElement machineNode;
                    try
                    {
                        machineNode =
                            (XmlElement) SettingsXml.SelectSingleNode(Settingsroot + "/" + Environment.MachineName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        machineNode = SettingsXml.CreateElement(Environment.MachineName);
                        SettingsXml.SelectSingleNode(Settingsroot)?.AppendChild(machineNode);
                    }

                    if (machineNode == null)
                    {
                        machineNode = SettingsXml.CreateElement(Environment.MachineName);
                        SettingsXml.SelectSingleNode(Settingsroot)?.AppendChild(machineNode);
                    }

                    settingNode = SettingsXml.CreateElement(propVal.Name);
                    settingNode.InnerText = propVal.SerializedValue.ToString();
                    machineNode.AppendChild(settingNode);
                }
            }
        }

        private static bool IsRoaming(SettingsProperty prop)
        {
            //Determine if the setting is marked as Roaming
            return (from DictionaryEntry d in prop.Attributes select (Attribute) d.Value).OfType<SettingsManageabilityAttribute>().Any();
        }
    }
}