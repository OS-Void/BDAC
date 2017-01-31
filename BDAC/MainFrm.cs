using System;
using System.Drawing;
using System.Windows.Forms;

namespace BDAC
{
    public partial class MainFrm : Form
    {
        public Functions Functions;
        public int CloseTime;
        public int ShutdownPc;

        public MainFrm()
        {
            Functions = new Functions(this);
            InitializeComponent();
            nShutdownDC.Enabled = false;
            nShutdownDC.Visible = false;
        }

        private void Main_Frm_Resize(object sender, EventArgs e)
        {
            //Send BDAC to tray when it minimizes if the tray option is checked
            if (nMinBox.Checked && WindowState == FormWindowState.Minimized)
            {
                Hide();
                traySystem.Visible = true;
            }
        }

        private void traySystem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Reveal BDAC when double clicking the tray system
            Show();
            WindowState = FormWindowState.Normal;
            traySystem.Visible = false;
        }

        private void nSetting_CheckedChanged(object sender, EventArgs e)
        {
            //Save settings
            Properties.Settings.Default.Tray = nMinBox.Checked;
            Properties.Settings.Default.AutoClose = nCloseDC.Checked;
            Properties.Settings.Default.Shutdown = nShutdownDC.Checked;
            Properties.Settings.Default.Save();
        }

        private void startCheckBtn_Click(object sender, EventArgs e)
        {
            if (!Functions.AutoClose)
            {
                if (!checkGameTimer.Enabled)
                {
                    startCheckBtn.Text = @"Stop Monitoring";
                    checkGameTimer.Start();
                }
                else
                {
                    runLbl.ForeColor = Color.Red;
                    runLbl.Text = @"N/A";

                    dcLbl.ForeColor = Color.Red;
                    dcLbl.Text = @"N/A";

                    traySystem.Text = @"BDCR";

                    startCheckBtn.Text = @"Start Monitoring";
                    checkGameTimer.Stop();
                }
            }
            else
            {
                checkAutoClose.Stop();
                checkShutdown.Stop();

                Functions.AutoClose = false;

                startCheckBtn.Text = @"Stop Monitoring";
                checkGameTimer.Start();
            }
        }

        private void checkGame_Tick(object sender, EventArgs e)
        {
            //Stop doing extra work if the game is scheduled for closing
            if (Functions.AutoClose)
            {
                checkGameTimer.Stop();

                CloseTime = 0;
                checkAutoClose.Start();
                return;
            }

            //Do checks on a new thread
            Functions.Monitor();

            //Update the labels depending on the results of the checks
            switch (Functions.GRunning)
            {
                case true:
                    runLbl.ForeColor = Color.Green;
                    runLbl.Text = @"Running";
                    break;
                case false:
                    runLbl.ForeColor = Color.Red;
                    runLbl.Text = @"Not Running";
                    break;
            }

            switch (Functions.GConnected)
            {
                case true:
                    dcLbl.ForeColor = Color.Green;
                    dcLbl.Text = @"Connected";
                    traySystem.Text = @"BDAC - Connected";
                    break;
                case false:
                    dcLbl.ForeColor = Color.Red;
                    dcLbl.Text = @"Disconnected";
                    traySystem.Text = @"BDAC - Disconnected";
                    break;
            }
        }

        private void checkAutoClose_Tick(object sender, EventArgs e)
        {
            //Close the game after 60 seconds
            if (CloseTime >= 60)
            {
                startCheckBtn.Enabled = false;
                startCheckBtn.Text = @"Auto Closing BDO";

                checkAutoClose.Stop();
                Functions.CloseGame();

                //Schedule shutdown if
                //the option is checked
                if (nShutdownDC.Checked)
                {
                    checkShutdown.Start();
                    startCheckBtn.Enabled = true;
                    return;
                }

                startCheckBtn.Enabled = true;
                return;
            }

            startCheckBtn.Text = @"Auto closing BDO in " + (60 - CloseTime) + @" second(s) [Cancel]";
            CloseTime++;
        }

        private void checkShutdown_Tick(object sender, EventArgs e)
        {
            //Shutdown PC after 5 minutes
            if (ShutdownPc >= 300)
            {
                startCheckBtn.Enabled = false;
                startCheckBtn.Text = @"Shutting PC down";

                checkShutdown.Stop();
                Functions.ShutdownPc();

                return;
            }

            startCheckBtn.Text = @"Shutting PC down in " + TimeSpan.FromSeconds(300 - ShutdownPc).ToString(@"mm\:ss") + @" minute(s) [Cancel]";
            ShutdownPc++;
        }
    }
}
