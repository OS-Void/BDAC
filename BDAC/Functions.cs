using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BDAC
{
    public class Functions
    {
        private MainFrm _mainform;
        public Functions(MainFrm frm)
        {
            _mainform = frm;
        }

        #region Variables

        //BDO Process Names
        private Process[] _bd64;
        private Process[] _bd32;

        //Game Status
        public bool GRunning;
        public bool GConnected;

        //Auto Close and Shutdown
        public readonly int MaxAttempts = 3;
        public int _concurrentFails;

        public bool AutoClose;

        #endregion

        #region Monitoring Thread

        private ThreadStart _tsMonitor;
        private Thread _monitor;

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
            //Check if the game is running
            if (GRunning = IsProcessRunning())
            {
                //If the game is running
                //then check if it's connected
                GConnected = IsConnected();
            }
        }

        #endregion

        #region Game Checker

        private void RefreshProcess()
        {
            _bd64 = Process.GetProcessesByName("BlackDesert64");
            _bd32 = Process.GetProcessesByName("BlackDesert32");
        }

        public bool IsProcessRunning()
        {
            try
            {
                RefreshProcess();

                //Check if BDO's process is running
                return _bd64.Concat(_bd32).Any();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
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

                    if (_mainform.nCloseDC.Checked)
                    {
                        _concurrentFails++;
                        Log("Failed to detect a connection " + _concurrentFails + " time(s). Will attempt " + (MaxAttempts - _concurrentFails) + " more times.");

                        if (_concurrentFails >= MaxAttempts)
                        {
                            AutoClose = true;
                        }
                    }
                    else
                    {
                        _concurrentFails = 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                _mainform.traySystem.Text = @"BDAC - Disconnected";
                return false;
            }
        }

        #endregion

        #region Actions

        public void CloseGame()
        {
            try
            {
                RefreshProcess();

                foreach (Process bd in _bd64.Concat(_bd32))
                {
                    _mainform.checkAutoClose.Stop();

                    bd.Kill();
                    _mainform.runLbl.Text = "Auto Closed";
                    _mainform.runLbl.ForeColor = Color.Red;
                    _mainform.runLed.On = true;
                    _mainform.runLed.Color = Color.Red;

                    _mainform.traySystem.Text = "BDAC - Auto Closed";

                    if (_mainform.nShutdownDC.Checked)
                    {
                        _mainform.checkShutdown.Start();
                        _mainform.startCheckBtn.Text = "Stop Monitoring";
                    }
                    else
                    {
                        _mainform.startCheckBtn.Text = "Start Monitoring";
                    }
                    
                    break;
                }

                Log("Killed BDO's instance.");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        public void ShutdownPc()
        {
            try
            {
                //Start the shutdown
                Process.Start("shutdown", "/s /t 0");

                // the argument /s is to shut down the computer.
                // the argument /t sets the time-out period before doing (how long until shutdown)
                // the operation, in our case we have it set to no time-out. 
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        public void Log(string msg)
        {
            if(_mainform.nSaveLog.Checked)
            {
                StreamWriter writer = new StreamWriter(_mainform.Logfile, true);
                writer.WriteLine(DateTime.Now.ToString(@"[MMMM dd yyyy] HH:mm:ss | ") + msg);
                writer.Close();
            }
        }

        #endregion
    }
}
