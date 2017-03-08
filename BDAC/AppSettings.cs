using System;
using System.IO;
using System.Xml.Serialization;

namespace BDAC
{
    public class AppConfig
    {
        public static readonly string ConfigFile = "bdac-settings.xml";

        public AppSettings Config { get; set; } = new AppSettings();

        // Load configuration file
        public void LoadConfig()
        {
            if (File.Exists(ConfigFile))
            {
                StreamReader srReader = File.OpenText(ConfigFile);
                Type tType = Config.GetType();
                XmlSerializer xsSerializer = new XmlSerializer(tType);
                object oData = xsSerializer.Deserialize(srReader);
                Config = (AppSettings)oData;
                srReader.Close();
            }
        }

        // Save configuration file
        public void SaveConfig()
        {
            StreamWriter swWriter = File.CreateText(ConfigFile);
            Type tType = Config.GetType();
            if (tType.IsSerializable)
            {
                XmlSerializer xsSerializer = new XmlSerializer(tType);
                xsSerializer.Serialize(swWriter, Config);
                swWriter.Close();
            }
        }
    }

    [Serializable]
    public class AppSettings
    {
        private bool _tray;
        private bool _autoClose;
        private bool _shutDown;

        public bool Tray
        {
            get { return _tray; }
            set { _tray = value; }
        }

        public bool AutoClose
        {
            get { return _autoClose; }
            set { _autoClose = value; }
        }

        public bool ShutDown
        {
            get { return _shutDown; }
            set { _shutDown = value; }
        }
    }
}
