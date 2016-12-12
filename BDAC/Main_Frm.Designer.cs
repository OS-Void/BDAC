namespace BDAC
{
    partial class Main_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Frm));
            this.traySystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkGameTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.checkAutoClose = new System.Windows.Forms.Timer(this.components);
            this.checkShutdown = new System.Windows.Forms.Timer(this.components);
            this.xylosTabControl1 = new XylosTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startCheckBtn = new System.Windows.Forms.Button();
            this.runLbl = new System.Windows.Forms.Label();
            this.dcLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nShutdownDC = new System.Windows.Forms.CheckBox();
            this.nCloseDC = new System.Windows.Forms.CheckBox();
            this.nMinBox = new System.Windows.Forms.CheckBox();
            this.xylosTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // traySystem
            // 
            this.traySystem.Icon = ((System.Drawing.Icon)(resources.GetObject("traySystem.Icon")));
            this.traySystem.Text = "BDCR";
            this.traySystem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.traySystem_MouseDoubleClick);
            // 
            // checkGameTimer
            // 
            this.checkGameTimer.Interval = 3000;
            this.checkGameTimer.Tick += new System.EventHandler(this.checkGame_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
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
            // xylosTabControl1
            // 
            this.xylosTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.xylosTabControl1.Controls.Add(this.tabPage1);
            this.xylosTabControl1.Controls.Add(this.tabPage2);
            this.xylosTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xylosTabControl1.FirstHeaderBorder = false;
            this.xylosTabControl1.ItemSize = new System.Drawing.Size(40, 180);
            this.xylosTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xylosTabControl1.Multiline = true;
            this.xylosTabControl1.Name = "xylosTabControl1";
            this.xylosTabControl1.SelectedIndex = 0;
            this.xylosTabControl1.Size = new System.Drawing.Size(456, 86);
            this.xylosTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.xylosTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.startCheckBtn);
            this.tabPage1.Controls.Add(this.runLbl);
            this.tabPage1.Controls.Add(this.dcLbl);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.tabPage1.Location = new System.Drawing.Point(184, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 78);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // startCheckBtn
            // 
            this.startCheckBtn.Location = new System.Drawing.Point(3, 49);
            this.startCheckBtn.Name = "startCheckBtn";
            this.startCheckBtn.Size = new System.Drawing.Size(262, 26);
            this.startCheckBtn.TabIndex = 12;
            this.startCheckBtn.Text = "Start Monitoring";
            this.startCheckBtn.UseVisualStyleBackColor = true;
            this.startCheckBtn.Click += new System.EventHandler(this.startCheckBtn_Click);
            // 
            // runLbl
            // 
            this.runLbl.AutoSize = true;
            this.runLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runLbl.ForeColor = System.Drawing.Color.Red;
            this.runLbl.Location = new System.Drawing.Point(145, 5);
            this.runLbl.Name = "runLbl";
            this.runLbl.Size = new System.Drawing.Size(29, 15);
            this.runLbl.TabIndex = 11;
            this.runLbl.Text = "N/A";
            // 
            // dcLbl
            // 
            this.dcLbl.AutoSize = true;
            this.dcLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcLbl.ForeColor = System.Drawing.Color.Red;
            this.dcLbl.Location = new System.Drawing.Point(145, 28);
            this.dcLbl.Name = "dcLbl";
            this.dcLbl.Size = new System.Drawing.Size(29, 15);
            this.dcLbl.TabIndex = 9;
            this.dcLbl.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Black Desert connection:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Black Desert is currently:\r\n";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.nShutdownDC);
            this.tabPage2.Controls.Add(this.nCloseDC);
            this.tabPage2.Controls.Add(this.nMinBox);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.tabPage2.Location = new System.Drawing.Point(184, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 78);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // nShutdownDC
            // 
            this.nShutdownDC.AutoSize = true;
            this.nShutdownDC.Checked = global::BDAC.Properties.Settings.Default.Shutdown;
            this.nShutdownDC.Location = new System.Drawing.Point(6, 53);
            this.nShutdownDC.Name = "nShutdownDC";
            this.nShutdownDC.Size = new System.Drawing.Size(253, 19);
            this.nShutdownDC.TabIndex = 13;
            this.nShutdownDC.Text = "Shutdown PC after 5 min. of disconnection";
            this.nShutdownDC.UseVisualStyleBackColor = true;
            this.nShutdownDC.CheckedChanged += new System.EventHandler(this.nSetting_CheckedChanged);
            // 
            // nCloseDC
            // 
            this.nCloseDC.AutoSize = true;
            this.nCloseDC.Checked = global::BDAC.Properties.Settings.Default.AutoClose;
            this.nCloseDC.Location = new System.Drawing.Point(6, 30);
            this.nCloseDC.Name = "nCloseDC";
            this.nCloseDC.Size = new System.Drawing.Size(223, 19);
            this.nCloseDC.TabIndex = 12;
            this.nCloseDC.Text = "Close BDO 1 min. after disconnection";
            this.nCloseDC.UseVisualStyleBackColor = true;
            this.nCloseDC.CheckedChanged += new System.EventHandler(this.nSetting_CheckedChanged);
            // 
            // nMinBox
            // 
            this.nMinBox.AutoSize = true;
            this.nMinBox.Checked = global::BDAC.Properties.Settings.Default.Tray;
            this.nMinBox.Location = new System.Drawing.Point(6, 7);
            this.nMinBox.Name = "nMinBox";
            this.nMinBox.Size = new System.Drawing.Size(195, 19);
            this.nMinBox.TabIndex = 7;
            this.nMinBox.Text = "Minimize BD Auto Closer to tray";
            this.nMinBox.UseVisualStyleBackColor = true;
            this.nMinBox.CheckedChanged += new System.EventHandler(this.nSetting_CheckedChanged);
            // 
            // Main_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 86);
            this.Controls.Add(this.xylosTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BD Auto Closer";
            this.Resize += new System.EventHandler(this.Main_Frm_Resize);
            this.xylosTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private XylosTabControl xylosTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox nMinBox;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox nCloseDC;
        public System.Windows.Forms.CheckBox nShutdownDC;
        public System.Windows.Forms.Button startCheckBtn;
        public System.Windows.Forms.NotifyIcon traySystem;
        public System.Windows.Forms.Label dcLbl;
        public System.Windows.Forms.Label runLbl;
        public System.Windows.Forms.Timer checkGameTimer;
        public System.Windows.Forms.Timer checkAutoClose;
        public System.Windows.Forms.Timer checkShutdown;
    }
}

