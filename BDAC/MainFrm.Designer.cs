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
            this.themeContainer = new iTalk.iTalk_ThemeContainer();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.startCheckBtn = new iTalk.iTalk_Button_2();
            this.iTalk_SeparatorV2 = new iTalk.iTalk_SeparatorV();
            this.iTalk_Separator1 = new iTalk.iTalk_Separator();
            this.dcLed = new BDAC.Theme.Led();
            this.runLed = new BDAC.Theme.Led();
            this.dcLbl = new iTalk.iTalk_Label();
            this.runLbl = new iTalk.iTalk_Label();
            this.labelConnected = new iTalk.iTalk_Label();
            this.labelRunning = new iTalk.iTalk_Label();
            this.iTalk_Separator2 = new iTalk.iTalk_Separator();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.nShutdownDC = new iTalk.iTalk_CheckBox();
            this.nCloseDC = new iTalk.iTalk_CheckBox();
            this.nMinBox = new iTalk.iTalk_CheckBox();
            this.themeContainer.SuspendLayout();
            this.iTalk_TabControl1.SuspendLayout();
            this.mainTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "app_window_shell_icon_32_w.png");
            this.imageList1.Images.SetKeyName(1, "clock_icon_32_w.png");
            this.imageList1.Images.SetKeyName(2, "cog_icon_32_w.png");
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
            this.checkGameTimer.Interval = 30000;
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
            // themeContainer
            // 
            this.themeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.themeContainer.Controls.Add(this.iTalk_ControlBox1);
            this.themeContainer.Controls.Add(this.iTalk_TabControl1);
            this.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themeContainer.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.themeContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.themeContainer.Location = new System.Drawing.Point(0, 0);
            this.themeContainer.Name = "themeContainer";
            this.themeContainer.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.themeContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.themeContainer.Sizable = false;
            this.themeContainer.Size = new System.Drawing.Size(426, 194);
            this.themeContainer.SmartBounds = false;
            this.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.themeContainer.TabIndex = 0;
            this.themeContainer.Text = "BD Auto Closer";
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(345, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 5;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.mainTabPage);
            this.iTalk_TabControl1.Controls.Add(this.settingsTabPage);
            this.iTalk_TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.ImageList = this.imageList1;
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 120);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(3, 28);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(420, 138);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 0;
            // 
            // mainTabPage
            // 
            this.mainTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.mainTabPage.Controls.Add(this.startCheckBtn);
            this.mainTabPage.Controls.Add(this.iTalk_SeparatorV2);
            this.mainTabPage.Controls.Add(this.iTalk_Separator1);
            this.mainTabPage.Controls.Add(this.dcLed);
            this.mainTabPage.Controls.Add(this.runLed);
            this.mainTabPage.Controls.Add(this.dcLbl);
            this.mainTabPage.Controls.Add(this.runLbl);
            this.mainTabPage.Controls.Add(this.labelConnected);
            this.mainTabPage.Controls.Add(this.labelRunning);
            this.mainTabPage.Controls.Add(this.iTalk_Separator2);
            this.mainTabPage.ImageIndex = 0;
            this.mainTabPage.Location = new System.Drawing.Point(124, 4);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabPage.Size = new System.Drawing.Size(292, 130);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "Main";
            // 
            // startCheckBtn
            // 
            this.startCheckBtn.BackColor = System.Drawing.Color.Transparent;
            this.startCheckBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startCheckBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startCheckBtn.ForeColor = System.Drawing.Color.White;
            this.startCheckBtn.Image = null;
            this.startCheckBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startCheckBtn.Location = new System.Drawing.Point(3, 89);
            this.startCheckBtn.Name = "startCheckBtn";
            this.startCheckBtn.Size = new System.Drawing.Size(286, 38);
            this.startCheckBtn.TabIndex = 4;
            this.startCheckBtn.Text = "Start Monitoring";
            this.startCheckBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.startCheckBtn.Click += new System.EventHandler(this.startCheckBtn_Click);
            // 
            // iTalk_SeparatorV2
            // 
            this.iTalk_SeparatorV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.iTalk_SeparatorV2.Location = new System.Drawing.Point(240, 3);
            this.iTalk_SeparatorV2.Name = "iTalk_SeparatorV2";
            this.iTalk_SeparatorV2.Size = new System.Drawing.Size(10, 72);
            this.iTalk_SeparatorV2.TabIndex = 11;
            this.iTalk_SeparatorV2.Text = "iTalk_SeparatorV2";
            // 
            // iTalk_Separator1
            // 
            this.iTalk_Separator1.Location = new System.Drawing.Point(9, 32);
            this.iTalk_Separator1.Name = "iTalk_Separator1";
            this.iTalk_Separator1.Size = new System.Drawing.Size(280, 10);
            this.iTalk_Separator1.TabIndex = 9;
            this.iTalk_Separator1.Text = "iTalk_Separator1";
            // 
            // dcLed
            // 
            this.dcLed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dcLed.Location = new System.Drawing.Point(256, 45);
            this.dcLed.Name = "dcLed";
            this.dcLed.On = true;
            this.dcLed.Size = new System.Drawing.Size(23, 23);
            this.dcLed.TabIndex = 6;
            this.dcLed.Text = "led2";
            // 
            // runLed
            // 
            this.runLed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.runLed.Location = new System.Drawing.Point(256, 7);
            this.runLed.Name = "runLed";
            this.runLed.On = true;
            this.runLed.Size = new System.Drawing.Size(23, 23);
            this.runLed.TabIndex = 5;
            this.runLed.Text = "led1";
            // 
            // dcLbl
            // 
            this.dcLbl.AutoSize = true;
            this.dcLbl.BackColor = System.Drawing.Color.Transparent;
            this.dcLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dcLbl.ForeColor = System.Drawing.Color.Red;
            this.dcLbl.Location = new System.Drawing.Point(155, 50);
            this.dcLbl.Name = "dcLbl";
            this.dcLbl.Size = new System.Drawing.Size(29, 13);
            this.dcLbl.TabIndex = 3;
            this.dcLbl.Text = "N/A";
            // 
            // runLbl
            // 
            this.runLbl.AutoSize = true;
            this.runLbl.BackColor = System.Drawing.Color.Transparent;
            this.runLbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.runLbl.ForeColor = System.Drawing.Color.Red;
            this.runLbl.Location = new System.Drawing.Point(155, 12);
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
            this.labelConnected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.labelConnected.Location = new System.Drawing.Point(6, 50);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(134, 13);
            this.labelConnected.TabIndex = 1;
            this.labelConnected.Text = "Black Desert connection:";
            // 
            // labelRunning
            // 
            this.labelRunning.AutoSize = true;
            this.labelRunning.BackColor = System.Drawing.Color.Transparent;
            this.labelRunning.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelRunning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.labelRunning.Location = new System.Drawing.Point(6, 12);
            this.labelRunning.Name = "labelRunning";
            this.labelRunning.Size = new System.Drawing.Size(132, 13);
            this.labelRunning.TabIndex = 0;
            this.labelRunning.Text = "Black Desert is currently:";
            // 
            // iTalk_Separator2
            // 
            this.iTalk_Separator2.Location = new System.Drawing.Point(8, 70);
            this.iTalk_Separator2.Name = "iTalk_Separator2";
            this.iTalk_Separator2.Size = new System.Drawing.Size(281, 10);
            this.iTalk_Separator2.TabIndex = 13;
            this.iTalk_Separator2.Text = "iTalk_Separator2";
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.settingsTabPage.Controls.Add(this.nShutdownDC);
            this.settingsTabPage.Controls.Add(this.nCloseDC);
            this.settingsTabPage.Controls.Add(this.nMinBox);
            this.settingsTabPage.ImageIndex = 2;
            this.settingsTabPage.Location = new System.Drawing.Point(124, 4);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(292, 130);
            this.settingsTabPage.TabIndex = 2;
            this.settingsTabPage.Text = "Settings";
            // 
            // nShutdownDC
            // 
            this.nShutdownDC.BackColor = System.Drawing.Color.Transparent;
            this.nShutdownDC.Checked = false;
            this.nShutdownDC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nShutdownDC.Location = new System.Drawing.Point(15, 63);
            this.nShutdownDC.Name = "nShutdownDC";
            this.nShutdownDC.Size = new System.Drawing.Size(260, 15);
            this.nShutdownDC.TabIndex = 2;
            this.nShutdownDC.Text = "Shutdown PC after disconnection";
            this.nShutdownDC.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nShutdownDC_CheckedChanged);
            // 
            // nCloseDC
            // 
            this.nCloseDC.BackColor = System.Drawing.Color.Transparent;
            this.nCloseDC.Checked = false;
            this.nCloseDC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nCloseDC.Location = new System.Drawing.Point(15, 37);
            this.nCloseDC.Name = "nCloseDC";
            this.nCloseDC.Size = new System.Drawing.Size(260, 15);
            this.nCloseDC.TabIndex = 1;
            this.nCloseDC.Text = "Close BDO 1 min. after disconnection";
            this.nCloseDC.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nCloseDC_CheckedChanged);
            // 
            // nMinBox
            // 
            this.nMinBox.BackColor = System.Drawing.Color.Transparent;
            this.nMinBox.Checked = false;
            this.nMinBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nMinBox.Location = new System.Drawing.Point(15, 11);
            this.nMinBox.Name = "nMinBox";
            this.nMinBox.Size = new System.Drawing.Size(260, 15);
            this.nMinBox.TabIndex = 0;
            this.nMinBox.Text = "Minimize BD Auto Closer to tray";
            this.nMinBox.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.nMinBox_CheckedChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 194);
            this.Controls.Add(this.themeContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BD Auto Closer";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.themeContainer.ResumeLayout(false);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.mainTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer themeContainer;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage mainTabPage;
        private iTalk.iTalk_Label dcLbl;
        public iTalk.iTalk_Label runLbl;
        private iTalk.iTalk_Label labelConnected;
        private iTalk.iTalk_Label labelRunning;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.ImageList imageList1;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private Theme.Led dcLed;
        public Theme.Led runLed;
        public iTalk.iTalk_CheckBox nShutdownDC;
        public iTalk.iTalk_CheckBox nCloseDC;
        public iTalk.iTalk_CheckBox nMinBox;
        public System.Windows.Forms.NotifyIcon traySystem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private iTalk.iTalk_Separator iTalk_Separator1;
        private iTalk.iTalk_SeparatorV iTalk_SeparatorV2;
        private iTalk.iTalk_Separator iTalk_Separator2;
        public System.Windows.Forms.Timer checkGameTimer;
        public System.Windows.Forms.Timer checkAutoClose;
        public System.Windows.Forms.Timer checkShutdown;
        public iTalk.iTalk_Button_2 startCheckBtn;
    }
}

