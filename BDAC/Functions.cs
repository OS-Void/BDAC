using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BDAC
{
    public class Functions
    {
        private readonly MainFrm _mainform;

        public Functions(MainFrm frm)
        {
            _mainform = frm;
        }

        private readonly Process[] _bd64 = Process.GetProcessesByName("BlackDesert64");
        private readonly Process[] _bd32 = Process.GetProcessesByName("BlackDesert32");

        //This is a backup process name
        //As I do not know if the 32bit version
        //Of BDO has '32' at the end of it's name
        private readonly Process[] _bdo = Process.GetProcessesByName("BlackDesert");

        #region Monitoring Thread

        private ThreadStart _tsMonitor;
        private Thread _monitor;

        public bool GRunning;
        public bool GConnected;
        public bool AutoClose;

        private int _concurrentFails;
        public int MaxAttempts = 3;

        public void Monitor()
        {
            //Create a Thread to do the work
            //To keep the UI responsive/lag-less at all times
            _tsMonitor = MMonitor;
            _monitor = new Thread(_tsMonitor);

            //Start the thread
            _monitor.Start();

            //Prevent repeated work to be done
            //while the thread isn't finished
            _monitor.Join();
        }

        private void MMonitor()
        {
            //Check if game is running
            GRunning = IsProcessRunning();

            //Check if the game is connected
            //only when the game is running
            if (GRunning)
            {
                GConnected = IsConnected();
            }
        }

        public bool IsProcessRunning()
        {
            try
            {
                //Check if BDO's process is running
                return _bd64.Concat(_bd32).Concat(_bdo).Any();

                //Not running
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsConnected()
        {
            try
            {
                using (Process p = new Process())
                {
                    ProcessStartInfo ps = new ProcessStartInfo
                    {
                        FileName = "netstat.exe",
                        Arguments = "-n -o",
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };

                    //netstat displays active TCP connections and ports

                    //-n Displays active TCP connections, however,
                    //addresses and port numbers are expressed
                    //numerically and no attempt is made to determine names.

                    //-o Displays active TCP connections and includes
                    //the process ID (PID) for each connection.


                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    string content = stdOutput.ReadToEnd();

                    //Read netstat's output
                    string[] rows = Regex.Split(content, "\r\n");
                    if (
                        rows.Select(t => Regex.Split(t, "\\s+"))
                            .Where(
                                tokens =>
                                    tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")) &&
                                    tokens[4].Equals("ESTABLISHED"))
                            .Any(
                                tokens =>
                                    Process.GetProcessById(Convert.ToInt32(tokens[5]))
                                        .ProcessName.Contains("BlackDesert")))
                    {
                        _concurrentFails = 0;
                        return true;
                    }

                    _concurrentFails++;
                    if (_mainform.nCloseDC.Checked)
                    {
                        Log(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": Failed to detect a connection " + _concurrentFails +
                            " time(s). Will attempt " + (MaxAttempts - _concurrentFails) + " more times.");
                    }
                    //BDO has no active connection
                    if (_mainform.nCloseDC.Checked && _concurrentFails >= MaxAttempts)
                    {
                        AutoClose = true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mainform.traySystem.Text = @"BDAC - Disconnected";
                return false;
            }
        }

        public void CloseGame()
        {
            try
            {
                if (_mainform.nCloseDC.Checked)
                {
                    foreach (Process bd in _bd64.Concat(_bd32).Concat(_bdo))
                    {
                        bd.Kill();
                        _mainform.runLbl.Text = @"Auto Closed";
                        _mainform.runLbl.ForeColor = System.Drawing.Color.Red;
                        _mainform.startCheckBtn.Text = @"BDO Auto Closed";
                        _mainform.traySystem.Text = @"BDAC - Auto Closed";

                        //_mainform.checkShutdown.Start();
                    }
                    Log(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": Killed all running instances.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Log(string msg)
        {
            StreamWriter writer = new StreamWriter("log.txt", true);
            writer.WriteLine(msg);
            writer.Close();
            writer.Dispose();
        }

        public void ShutdownPc()
        {
            //Start the shutdown
            //Process.Start("shutdown", "/s /t 0");

            // the argument /s is to shut down the computer.
            // the argument /t sets the time-out period before doing (how long until shutdown)
            // the operation, in our case we have it set to no time-out. 
        }

        #endregion
    }
}
