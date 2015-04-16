namespace RelaxYourEyes
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timerRest = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.timerResting = new System.Windows.Forms.Timer(this.components);
            this.notifyIconFormMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripFormMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delayNextBreakBy3MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFormMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRest
            // 
            this.timerRest.Interval = 1000;
            this.timerRest.Tick += new System.EventHandler(this.timerRest_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(281, 70);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start and hide";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // timerResting
            // 
            this.timerResting.Tick += new System.EventHandler(this.timerResting_Tick);
            // 
            // notifyIconFormMain
            // 
            this.notifyIconFormMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconFormMain.BalloonTipTitle = "Relax your eyes";
            this.notifyIconFormMain.ContextMenuStrip = this.contextMenuStripFormMain;
            this.notifyIconFormMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconFormMain.Icon")));
            this.notifyIconFormMain.Text = "Relax your eyes";
            this.notifyIconFormMain.Visible = true;
            // 
            // contextMenuStripFormMain
            // 
            this.contextMenuStripFormMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delayNextBreakBy3MinutesToolStripMenuItem});
            this.contextMenuStripFormMain.Name = "contextMenuStripFormMain";
            this.contextMenuStripFormMain.Size = new System.Drawing.Size(232, 48);
            // 
            // delayNextBreakBy3MinutesToolStripMenuItem
            // 
            this.delayNextBreakBy3MinutesToolStripMenuItem.Name = "delayNextBreakBy3MinutesToolStripMenuItem";
            this.delayNextBreakBy3MinutesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.delayNextBreakBy3MinutesToolStripMenuItem.Text = "Delay next break by 3 minutes";
            this.delayNextBreakBy3MinutesToolStripMenuItem.Click += new System.EventHandler(this.delayNextBreakBy3MinutesToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 94);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Relax your eyes";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.contextMenuStripFormMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRest;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Timer timerResting;
        private System.Windows.Forms.NotifyIcon notifyIconFormMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFormMain;
        private System.Windows.Forms.ToolStripMenuItem delayNextBreakBy3MinutesToolStripMenuItem;
    }
}

