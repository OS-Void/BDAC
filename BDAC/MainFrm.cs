using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BDAC
{
    public partial class MainFrm : Form
    {
        public Functions Functions;

        public int GameCheckTime;
        public int CloseBDOTime;
        public int ShutdownPCTime;

        public readonly string Logfile = "bdaclog.txt";

        private readonly AppConfig ConfigManager = new AppConfig();

        #region MainFrm

        public MainFrm()
        {
            Functions = new Functions(this);
            InitializeComponent();

            statusTimelabel.Text = string.Empty;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(AppConfig.ConfigFile))
            {
                ConfigManager.SaveConfig();
                iTalk_TabControl1.SelectedTab = settingsTabPage;
            }
            else
            {
                ConfigManager.LoadConfig();

                nMinBox.Checked = ConfigManager.Config.Tray;
                nSaveLog.Checked = ConfigManager.Config.Log;
                nCloseDC.Checked = ConfigManager.Config.AutoClose;
                nShutdownDC.Checked = ConfigManager.Config.ShutDown;

                Functions.Log("BD Auto Closer started.");
                iTalk_TabControl1.SelectedTab = mainTabPage;
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Functions.Log("BD Auto Closer closed.");
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            //Send BDAC to tray when it minimizes if the tray option is checked
            if (nMinBox.Checked && WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void traySystem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Reveal BDAC when double clicking the tray system
            Show();
            WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Main Tab

        private void startCheckBtn_MouseClick(object sender, MouseEventArgs e)
        {
            //Decide whether to start or stop monitoring
            if ((!checkGameTimer.Enabled) && (!checkAutoClose.Enabled) && (!checkShutdown.Enabled))
            {
                startCheckBtn.Text = @"Stop Monitoring";

                GameCheckTime = 30;
                checkGameTimer.Start();

                Functions.Log("Started monitoring.");
            }
            else
            {
                Functions.AutoClose = false;
                Functions._concurrentFails = 0;

                CloseBDOTime = 0;
                ShutdownPCTime = 0;

                checkGameTimer.Stop();
                checkAutoClose.Stop();
                checkShutdown.Stop();

                runLed.On = false;
                runLbl.ForeColor = Color.Red;
                runLbl.Text = @"N/A";

                dcLed.On = false;
                dcLbl.ForeColor = Color.Red;
                dcLbl.Text = @"N/A";

                traySystem.Text = "BDAC";
                statusTimelabel.Text = String.Empty;
                startCheckBtn.Text = "Start Monitoring";

                Functions.Log("Stopped monitoring.");
            }
        }

        private void checkGame_Tick(object sender, EventArgs e)
        {
            //Check every 30 seconds
            if (GameCheckTime >= 30)
            {
                //Stop doing extra work if the game is scheduled for closing
                if (Functions.AutoClose)
                {
                    GameCheckTime = 0;
                    checkAutoClose.Start();

                    Functions.Log(@"Auto closing BDO in 60 seconds.");
                    return;
                }

                statusTimelabel.Text = "Checking BDO..";

                //Do checks on a new thread
                Functions.Monitor();

                //Update the labels depending on the results of the checks
                switch (Functions.GRunning)
                {
                    case true:
                        runLbl.ForeColor = Color.Green;
                        runLbl.Text = @"Running";
                        runLed.On = true;
                        runLed.Color = Color.Green;
                        break;
                    case false:
                        runLbl.ForeColor = Color.Red;
                        runLbl.Text = @"Not Running";
                        runLed.On = true;
                        runLed.Color = Color.Red;
                        break;
                }

                switch (Functions.GConnected)
                {
                    case true:
                        dcLbl.ForeColor = Color.Green;
                        dcLbl.Text = @"Connected";
                        traySystem.Text = @"BDAC - Connected";
                        dcLed.On = true;
                        dcLed.Color = Color.Green;
                        break;
                    case false:
                        dcLbl.ForeColor = Color.Red;
                        dcLbl.Text = @"Disconnected";
                        traySystem.Text = @"BDAC - Disconnected";
                        dcLed.On = true;
                        dcLed.Color = Color.Red;
                        break;
                }

                GameCheckTime = 0;
                return;
            }

            //Start Auto Close Timer
            if (Functions.AutoClose)
            {
                checkGameTimer.Stop();
                checkShutdown.Stop();

                checkAutoClose.Start();
                return;
            }

            //Start PC Shutdown Timer
            if (!Functions.GRunning || (!nCloseDC.Checked && !Functions.GConnected))
            {
                if (nShutdownDC.Checked)
                {
                    checkGameTimer.Stop();
                    checkAutoClose.Stop();

                    Functions.Log(@"Shutting PC down in 5 minutes.");
                    checkShutdown.Start();
                    return;
                }
            }

            //Update Status label
            statusTimelabel.Text = "Checking in " + (30 - GameCheckTime) + " seconds..";

            if ((!checkAutoClose.Enabled) && (!checkShutdown.Enabled))
            {
                if (Functions._concurrentFails > 0)
                {
                    statusTimelabel.Text += "\nDisconnected.. Attempt " + Functions._concurrentFails + "/" + Functions.MaxAttempts;
                }
            }

            GameCheckTime++;
        }

        private void checkAutoClose_Tick(object sender, EventArgs e)
        {
            //Close the game after 60 seconds
            if (CloseBDOTime >= 60)
            {
                startCheckBtn.Enabled = false;
                startCheckBtn.Text = "Auto Closing BDO";

                checkAutoClose.Stop();
                Functions.CloseGame();

                //Schedule shutdown if the option is checked
                if (nShutdownDC.Checked)
                {
                    Functions.Log(@"Shutting PC down in 5 minutes.");
                    checkShutdown.Start();
                }

                startCheckBtn.Enabled = true;
                return;
            }

            statusTimelabel.Text = "Checking in " + (30 - GameCheckTime) + " seconds..\n" + "Auto closing BDO in " + (60 - CloseBDOTime) + @" second(s)";
            CloseBDOTime++;
        }

        private void checkShutdown_Tick(object sender, EventArgs e)
        {
            //Shutdown PC after 5 minutes
            if (ShutdownPCTime >= 300)
            {
                startCheckBtn.Enabled = false;
                startCheckBtn.Text = @"Shutting PC down";

                checkGameTimer.Stop();
                checkAutoClose.Stop();
                checkShutdown.Stop();

                Functions.ShutdownPc();
                return;
            }

            statusTimelabel.Text = "Shutting PC down in " + TimeSpan.FromSeconds(300 - ShutdownPCTime).ToString(@"mm\:ss") + " minute(s)";
            ShutdownPCTime++;
        }

        #endregion

        #region Settings Tab

        private void nMinBox_CheckedChanged(object sender)
        {
            ConfigManager.Config.Tray = nMinBox.Checked;
            ConfigManager.SaveConfig();
        }

        private void nSaveLog_CheckedChanged(object sender)
        {
            ConfigManager.Config.Log = nSaveLog.Checked;
            ConfigManager.SaveConfig();
        }

        private void nCloseDC_CheckedChanged(object sender)
        {
            ConfigManager.Config.AutoClose = nCloseDC.Checked;
            ConfigManager.SaveConfig();
        }

        private void nShutdownDC_CheckedChanged(object sender)
        {
            ConfigManager.Config.ShutDown = nShutdownDC.Checked;
            ConfigManager.SaveConfig();
        }

        #endregion

    }
}
