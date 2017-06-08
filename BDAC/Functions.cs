using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;

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

        private IEnumerable<Process> Processes() 
        {
            return Process.GetProcessesByName("BlackDesert64").Concat(Process.GetProcessesByName("BlackDesert32"));
        }

        //Check if BDO's process is running
        public bool IsProcessRunning()
        {
            try
            {
                return Processes().Any();
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
                var processes = Processes();
                var establishedConnections = new Connections().GetAllTcpConnections().Where(c => c.State == MibTcpState.ESTABLISHED);

                return processes.Any() && establishedConnections.Any(conn => processes.Any(p => conn.ProcessId == p.Id));
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
                foreach (Process bd in Processes())
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
