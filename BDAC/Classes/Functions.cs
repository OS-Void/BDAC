using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BDAC.Classes
{
    public class Functions
    {
        private Main_Frm Mainform = null;
        public Functions(Main_Frm frm)
        {
            Mainform = frm;
        }

        Process[] BD64 = Process.GetProcessesByName("BlackDesert64");
        Process[] BD32 = Process.GetProcessesByName("BlackDesert32");

        //This is a backup process name
        //As I do not know if the 32bit version
        //Of BDO has '32' at the end of it's name
        Process[] BDO = Process.GetProcessesByName("BlackDesert");

        #region Monitoring Thread

        private ThreadStart TS_Monitor;
        public Thread T_Monitor;

        public bool gRunning = false;
        public bool gConnected = false;
        public bool autoClose = false;

        public void Monitor()
        {
            //Create a Thread to do the work
            //To keep the UI responsive/lag-less at all times
            TS_Monitor = new ThreadStart(MMonitor);
            T_Monitor = new Thread(TS_Monitor);

            //Start the thread
            T_Monitor.Start();

            //Prevent repeated work to be done
            //while the thread isn't finished
            T_Monitor.Join();
        }

        private void MMonitor()
        {
            //Check if game is running
            gRunning = isProcessRunning();

            //Check if the game is connected
            //only when the game is running
            if (gRunning)
            {
                gConnected = isConnected();
            }
        }

        public bool isProcessRunning()
        {
            try
            {
                //Check if BDO's process is running
                foreach (Process BD in BD64.Concat(BD32).Concat(BDO))
                {
                    return true;
                }

                //Not running
                return false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
        }

        public bool isConnected()
        {
            try
            {
                using (Process p = new Process())
                {
                    ProcessStartInfo ps = new ProcessStartInfo();

                    //netstat displays active TCP connections and ports
                    ps.FileName = "netstat.exe";

                    //-n Displays active TCP connections, however,
                    //addresses and port numbers are expressed
                    //numerically and no attempt is made to determine names.

                    //-o Displays active TCP connections and includes
                    //the process ID (PID) for each connection.
                    ps.Arguments = "-n -o";

                    ps.UseShellExecute = false;
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.RedirectStandardOutput = true;
                    ps.CreateNoWindow = true;

                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    string content = stdOutput.ReadToEnd();

                    //Read netstat's output
                    string[] rows = Regex.Split(content, "\r\n");
                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] tokens = Regex.Split(rows[i], "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")) && tokens[4].Equals("ESTABLISHED"))
                        {
                            if (Process.GetProcessById(Convert.ToInt32(tokens[5].ToString())).ProcessName.Contains("BlackDesert"))
                            {
                                return true;
                            }
                        }
                    }

                    //BDO has no active connection
                    if(Mainform.nCloseDC.Checked)
                    {
                        autoClose = true;
                    }
                    
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error); Mainform.traySystem.Text = "BDAC - Disconnected"; return false; }
        }

        public void closeGame()
        {
            try
            {
                if (Mainform.nCloseDC.Checked)
                {
                    foreach (Process BD in BD64.Concat(BD32).Concat(BDO))
                    {
                        BD.Kill();
                        Mainform.runLbl.Text = "Auto Closed";
                        Mainform.runLbl.ForeColor = System.Drawing.Color.Red;
                        Mainform.startCheckBtn.Text = "BDO Auto Closed";
                        Mainform.traySystem.Text = "BDAC - Auto Closed";

                        Mainform.checkShutdown.Start();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "BD Auto Closer", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void shutdownPC()
        {
            //Start the shutdown
            Process.Start("shutdown", "/s /t 0");

            // the argument /s is to shut down the computer.
            // the argument /t sets the time-out period before doing (how long until shutdown)
            // the operation, in our case we have it set to no time-out. 
        }

        #endregion
    }
}
