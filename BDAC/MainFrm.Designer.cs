namespace BDAC
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.traySystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkGameTimer = new System.Windows.Forms.Timer(this.components);
            this.checkAutoClose = new System.Windows.Forms.Timer(this.components);
            this.checkShutdown = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.iTalk_SeparatorV2 = new iTalk.iTalk_SeparatorV();
            this.statusTimelabel = new iTalk.iTalk_Label();
            this.startCheckBtn = new iTalk.iTalk_Button_2();
            this.iTalk_Separator1 = new iTalk.iTalk_Separator();
            this.runLed = new BDAC.Theme.Led();
            this.dcLbl = new iTalk.iTalk_Label();
            this.runLbl = new iTalk.iTalk_Label();
            this.labelConnected = new iTalk.iTalk_Label();
            this.labelRunning = new iTalk.iTalk_Label();
            this.iTalk_Separator2 = new iTalk.iTalk_Separator();
            this.dcLed = new BDAC.Theme.Led();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.iTalk_Separator3 = new iTalk.iTalk_Separator();
            this.nSaveLog = new iTalk.iTalk_CheckBox();
            this.nShutdownDC = new iTalk.iTalk_CheckBox();
            this.nCloseDC = new iTalk.iTalk_CheckBox();
            this.nMinBox = new iTalk.iTalk_CheckBox();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.iTalk_TabControl1.SuspendLayout();
            this.mainTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "app_window_shell_icon_32_w.png");
            this.imageList1.Images.SetKeyName(1, "cog_icon_32_w.png");
            this.imageList1.Images.SetKeyName(2, "about-32.png");
            // 
            // traySystem
            // 
            this.traySystem.Icon = ((System.Drawing.Icon)(resources.GetObject("traySystem.Icon")));
            this.traySystem.Text = "BD Auto Closer";
            this.traySystem.Visible = true;
            this.traySystem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.traySystem_MouseDoubleClick);
            // 
            // checkGameTimer
            // 
            this.checkGameTimer.Interval = 1000;
            this.checkGameTimer.Tick += new System.EventHandler(this.checkGame_Tick);
            // 
            // checkAutoClose
            // 
            this.checkAutoClose.Interval = 1000;
            this.checkAutoClose.Tick += new System.EventHandler(this.checkAutoClose_Tick);
            // 
            // checkShutdown
            // 
            this.checkShutdown.Interval = 1000;
            this.checkShutdown.Tick += new System.EventHandler(this.checkShutdown_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.mainTabPage);
            this.iTalk_TabControl1.Controls.Add(this.settingsTabPage);
            this.iTalk_TabControl1.Controls.Add(this.aboutTabPage);
            this.iTalk_TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.ImageList = this.imageList1;
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 120);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(415, 156);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 0;
            this.iTalk_TabControl1.TabStop = false;
            // 
            // mainTabPage
            // 
            this.mainTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.mainTabPage.Controls.Add(this.iTalk_SeparatorV2);
            this.mainTabPage.Controls.Add(this.statusTimelabel);
            this.mainTabPage.Controls.Add(this.startCheckBtn);
            this.mainTabPage.Controls.Add(this.iTalk_Separator1);
            this.mainTabPage.Controls.Add(this.runLed);
            this.mainTabPage.Controls.Add(this.dcLbl);
            this.mainTabPage.Controls.Add(this.runLbl);
            this.mainTabPage.Controls.Add(this.labelConnected);
            this.mainTabPage.Controls.Add(this.labelRunning);
            this.mainTabPage.Controls.Add(this.iTalk_Separator2);
            this.mainTabPage.Controls.Add(this.dcLed);
            this.mainTabPage.ImageIndex = 0;
            this.mainTabPage.Location = new System.Drawing.Point(124, 4);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabPage.Size = new System.Drawing.Size(287, 148);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "Main";
            // 
            // iTalk_SeparatorV2
            // 
            this.iTalk_SeparatorV2.Location = new System.Drawing.Point(245, -1);
            this.iTalk_SeparatorV2.Name = "iTalk_SeparatorV2";
            this.iTalk_SeparatorV2.Size = new System.Drawing.Size(1, 73);
            this.iTalk_SeparatorV2.TabIndex = 11;
            this.iTalk_SeparatorV2.Text = "iTalk_SeparatorV2";
            // 
            // statusTimelabel
            // 
            this.statusTimelabel.BackColor = System.Drawing.Color.Transparent;
            this.statusTimelabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.statusTimelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusTimelabel.Location = new System.Drawing.Point(6, 75);
            this.statusTimelabel.Name = "statusTimelabel";
            this.statusTimelabel.Size = new System.Drawing.Size(273, 30);
            this.statusTimelabel.TabIndex = 7;
            this.statusTimelabel.Text = "iTalk_Label1";
            this.statusTimelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startCheckBtn
            // 
            this.startCheckBtn.BackColor = System.Drawing.Color.Transparent;
            this.startCheckBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startCheckBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startCheckBtn.ForeColor = System.Drawing.Color.White;
            this.startCheckBtn.Image = null;
            this.startCheckBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startCheckBtn.Location = new System.Drawing.Point(3, 110);
            this.startCheckBtn.Name = "startCheckBtn";
            this.startCheckBtn.Size = new System.Drawing.Size(281, 35);
            this.startCheckBtn.TabIndex = 8;
            this.startCheckBtn.TabStop = false;
            this.startCheckBtn.Text = "Start Monitoring";
            this.startCheckBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.startCheckBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startCheckBtn_MouseClick);
            // 
            // iTalk_Separator1
            // 
            this.iTalk_Separator1.Location = new System.Drawing.Point(0, 28);
            this.iTalk_Separator1.Name = "iTalk_Separator1";
            this.iTalk_Separator1.Size = new System.Drawing.Size(287, 10);
            this.iTalk_Separator1.TabIndex = 9;
            this.iTalk_Separator1.Text = "iTalk_Separator1";
            // 
            // runLed
            // 
            this.runLed.Location = new System.Drawing.Point(257, 3);
            this.runLed.Name = "runLed";
            this.runLed.On = false;
            this.runLed.Size = new System.Drawing.Size(23, 23);
            this.runLed.TabIndex = 3;
            this.runLed.TabStop = false;
            // 
            // dcLbl
            // 
            this.dcLbl.AutoSize = true;
            this.dcLbl.BackColor = System.Drawing.Color.Transparent;
            this.dcLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dcLbl.ForeColor = System.Drawing.Color.Red;
            this.dcLbl.Location = new System.Drawing.Point(155, 46);
            this.dcLbl.Name = "dcLbl";
            this.dcLbl.Size = new System.Drawing.Size(29, 13);
            this.dcLbl.TabIndex = 5;
            this.dcLbl.Text = "N/A";
            // 
            // runLbl
            // 
            this.runLbl.AutoSize = true;
            this.runLbl.BackColor = System.Drawing.Color.Transparent;
            this.runLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.runLbl.ForeColor = System.Drawing.Color.Red;
            this.runLbl.Location = new System.Drawing.Point(155, 8);
            this.runLbl.Name = "runLbl";
            this.runLbl.Size = new System.Drawing.Size(29, 13);
            this.runLbl.TabIndex = 2;
            this.runLbl.Text = "N/A";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.BackColor = System.Drawing.Color.Transparent;
            this.labelConnected.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelConnected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelConnected.Location = new System.Drawing.Point(6, 46);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(134, 13);
            this.labelConnected.TabIndex = 4;
            this.labelConnected.Text = "Black Desert connection:";
            // 
            // labelRunning
            // 
            this.labelRunning.AutoSize = true;
            this.labelRunning.BackColor = System.Drawing.Color.Transparent;
            this.labelRunning.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelRunning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRunning.Location = new System.Drawing.Point(6, 8);
            this.labelRunning.Name = "labelRunning";
            this.labelRunning.Size = new System.Drawing.Size(132, 13);
            this.labelRunning.TabIndex = 1;
            this.labelRunning.Text = "Black Desert is currently:";
            // 
            // iTalk_Separator2
            // 
            this.iTalk_Separator2.Location = new System.Drawing.Point(0, 66);
            this.iTalk_Separator2.Name = "iTalk_Separator2";
            this.iTalk_Separator2.Size = new System.Drawing.Size(287, 10);
            this.iTalk_Separator2.TabIndex = 13;
            this.iTalk_Separator2.Text = "iTalk_Separator2";
            // 
            // dcLed
            // 
            this.dcLed.Location = new System.Drawing.Point(257, 41);
            this.dcLed.Name = "dcLed";
            this.dcLed.On = false;
            this.dcLed.Size = new System.Drawing.Size(23, 23);
            this.dcLed.TabIndex = 6;
            this.dcLed.TabStop = false;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.settingsTabPage.Controls.Add(this.iTalk_Separator3);
            this.settingsTabPage.Controls.Add(this.nSaveLog);
            this.settingsTabPage.Controls.Add(this.nShutdownDC);
            this.settingsTabPage.Controls.Add(this.nCloseDC);
            this.settingsTabPage.Controls.Add(this.nMinBox);
            this.settingsTabPage.ImageIndex = 1;
            this.settingsTabPage.Location = new System.Drawing.Point(124, 4);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(287, 148);
            this.settingsTabPage.TabIndex = 2;
            this.settingsTabPage.Text = "Settings";
            // 
            // iTalk_Separator3
            // 
            this.iTalk_Separator3.Location = new System.Drawing.Point(0, 51);
            this.iTalk_Separator3.Name = "iTalk_Separator3";
            this.iTalk_Separator3.Size = new System.Drawing.Size(287, 10);
            this.iTalk_Separator3.TabIndex = 13;
            this.iTalk_Separator3.Text = "iTalk_Separator3";
            // 
            // nSaveLog
            // 
            this.nSaveLog.BackColor = System.Drawing.Color.Transparent;
            this.nSaveLog.Checked = false;
            this.nSaveLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nSaveLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nSaveLog.Location = new System.Drawing.Point(5, 31);
            this.nSaveLog.Name = "nSaveLog";
            this.nSaveLog.Size = new System.Drawing.Size(276, 15);
            this.nSaveLog.TabIndex = 12;
            this.nSaveLog.TabStop = false;
            this.nSaveLog.Text = "Log BD Auto Closer\'s actions";
            this.nSaveLog.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nSaveLog_CheckedChanged);
            // 
            // nShutdownDC
            // 
            this.nShutdownDC.BackColor = System.Drawing.Color.Transparent;
            this.nShutdownDC.Checked = false;
            this.nShutdownDC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nShutdownDC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nShutdownDC.Location = new System.Drawing.Point(5, 92);
            this.nShutdownDC.Name = "nShutdownDC";
            this.nShutdownDC.Size = new System.Drawing.Size(276, 15);
            this.nShutdownDC.TabIndex = 11;
            this.nShutdownDC.TabStop = false;
            this.nShutdownDC.Text = "Shutdown PC after 5 min. of disconnection";
            this.nShutdownDC.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nShutdownDC_CheckedChanged);
            // 
            // nCloseDC
            // 
            this.nCloseDC.BackColor = System.Drawing.Color.Transparent;
            this.nCloseDC.Checked = false;
            this.nCloseDC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nCloseDC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nCloseDC.Location = new System.Drawing.Point(5, 66);
            this.nCloseDC.Name = "nCloseDC";
            this.nCloseDC.Size = new System.Drawing.Size(276, 15);
            this.nCloseDC.TabIndex = 10;
            this.nCloseDC.TabStop = false;
            this.nCloseDC.Text = "Close BDO after 1 min. of disconnection";
            this.nCloseDC.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nCloseDC_CheckedChanged);
            // 
            // nMinBox
            // 
            this.nMinBox.BackColor = System.Drawing.Color.Transparent;
            this.nMinBox.Checked = false;
            this.nMinBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nMinBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nMinBox.Location = new System.Drawing.Point(5, 5);
            this.nMinBox.Name = "nMinBox";
            this.nMinBox.Size = new System.Drawing.Size(276, 15);
            this.nMinBox.TabIndex = 9;
            this.nMinBox.TabStop = false;
            this.nMinBox.Text = "Minimize BD Auto Closer to tray";
            this.nMinBox.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nMinBox_CheckedChanged);
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.aboutTabPage.Controls.Add(this.iTalk_Label2);
            this.aboutTabPage.Controls.Add(this.iTalk_Label1);
            this.aboutTabPage.ImageIndex = 2;
            this.aboutTabPage.Location = new System.Drawing.Point(124, 4);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(287, 148);
            this.aboutTabPage.TabIndex = 3;
            this.aboutTabPage.Text = "About";
            // 
            // iTalk_Label2
            // 
            this.iTalk_Label2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_Label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iTalk_Label2.Location = new System.Drawing.Point(3, 23);
            this.iTalk_Label2.Name = "iTalk_Label2";
            this.iTalk_Label2.Size = new System.Drawing.Size(281, 122);
            this.iTalk_Label2.TabIndex = 1;
            this.iTalk_Label2.Text = resources.GetString("iTalk_Label2.Text");
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(3, 3);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(281, 20);
            this.iTalk_Label1.TabIndex = 0;
            this.iTalk_Label1.Text = "Credits";
            this.iTalk_Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 156);
            this.Controls.Add(this.iTalk_TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BD Auto Closer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.mainTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.aboutTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.NotifyIcon traySystem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.Timer checkGameTimer;
        public System.Windows.Forms.Timer checkAutoClose;
        public System.Windows.Forms.Timer checkShutdown;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage mainTabPage;
        public iTalk.iTalk_Button_2 startCheckBtn;
        private iTalk.iTalk_SeparatorV iTalk_SeparatorV2;
        private iTalk.iTalk_Separator iTalk_Separator1;
        public Theme.Led runLed;
        public iTalk.iTalk_Label runLbl;
        private iTalk.iTalk_Label labelConnected;
        private iTalk.iTalk_Label labelRunning;
        private iTalk.iTalk_Separator iTalk_Separator2;
        private System.Windows.Forms.TabPage settingsTabPage;
        public iTalk.iTalk_CheckBox nShutdownDC;
        public iTalk.iTalk_CheckBox nCloseDC;
        public iTalk.iTalk_CheckBox nMinBox;
        public Theme.Led dcLed;
        public iTalk.iTalk_Label dcLbl;
        private System.Windows.Forms.TabPage aboutTabPage;
        private iTalk.iTalk_Separator iTalk_Separator3;
        public iTalk.iTalk_CheckBox nSaveLog;
        public iTalk.iTalk_Label statusTimelabel;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_Label iTalk_Label1;
    }
}

