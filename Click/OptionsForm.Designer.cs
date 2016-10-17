namespace Click
{
    partial class OptionsForm
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
            this.components = new System.ComponentModel.Container ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (OptionsForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon (this.components);
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip (this.components);
            this.ctxItemOptions = new System.Windows.Forms.ToolStripMenuItem ();
            this.ctxSepBegin = new System.Windows.Forms.ToolStripSeparator ();
            this.ctxSepEnd = new System.Windows.Forms.ToolStripSeparator ();
            this.ctxItemExit = new System.Windows.Forms.ToolStripMenuItem ();
            this.shownWorker = new System.ComponentModel.BackgroundWorker ();
            this.btnApply = new System.Windows.Forms.Button ();
            this.btnClose = new System.Windows.Forms.Button ();
            this.button1 = new System.Windows.Forms.Button ();
            this.paramCtrl = new Click.ParamCtrl ();
            this.menuNotify.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.menuNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject ("notifyIcon.Icon")));
            this.notifyIcon.Text = "Click!";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler (this.onMouseClick);
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.ctxItemOptions,
            this.ctxSepBegin,
            this.ctxSepEnd,
            this.ctxItemExit});
            this.menuNotify.Name = "menuNotify";
            this.menuNotify.Size = new System.Drawing.Size (153, 82);
            this.menuNotify.Opening += new System.ComponentModel.CancelEventHandler (this.onCtxOpening);
            // 
            // ctxItemOptions
            // 
            this.ctxItemOptions.Name = "ctxItemOptions";
            this.ctxItemOptions.Size = new System.Drawing.Size (152, 22);
            this.ctxItemOptions.Text = "Настройки";
            this.ctxItemOptions.Click += new System.EventHandler (this.onMenuOptions);
            // 
            // ctxSepBegin
            // 
            this.ctxSepBegin.Name = "ctxSepBegin";
            this.ctxSepBegin.Size = new System.Drawing.Size (149, 6);
            // 
            // ctxSepEnd
            // 
            this.ctxSepEnd.Name = "ctxSepEnd";
            this.ctxSepEnd.Size = new System.Drawing.Size (149, 6);
            // 
            // ctxItemExit
            // 
            this.ctxItemExit.Name = "ctxItemExit";
            this.ctxItemExit.Size = new System.Drawing.Size (152, 22);
            this.ctxItemExit.Text = "Выход";
            this.ctxItemExit.Click += new System.EventHandler (this.onExit);
            // 
            // shownWorker
            // 
            this.shownWorker.DoWork += new System.ComponentModel.DoWorkEventHandler (this.onShownWorker);
            this.shownWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler (this.onShownWorkerCompleted);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Lime;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb (((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb (((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font ("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb (((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnApply.Location = new System.Drawing.Point (10, 219);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size (85, 30);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler (this.onApply);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font ("Segoe UI", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb (((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Location = new System.Drawing.Point (102, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size (90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler (this.onCancel);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font ("Segoe UI", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb (((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point (198, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size (90, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler (this.onExit);
            // 
            // paramCtrl
            // 
            this.paramCtrl.BackColor = System.Drawing.Color.White;
            this.paramCtrl.CurrentSpeed = 1;
            this.paramCtrl.KeyBegin = System.Windows.Forms.Keys.None;
            this.paramCtrl.KeyEnd = System.Windows.Forms.Keys.None;
            this.paramCtrl.KeyExit = System.Windows.Forms.Keys.None;
            this.paramCtrl.Location = new System.Drawing.Point (12, 12);
            this.paramCtrl.Name = "paramCtrl";
            this.paramCtrl.Size = new System.Drawing.Size (282, 173);
            this.paramCtrl.TabIndex = 1;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size (301, 261);
            this.Controls.Add (this.button1);
            this.Controls.Add (this.paramCtrl);
            this.Controls.Add (this.btnClose);
            this.Controls.Add (this.btnApply);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Shown += new System.EventHandler (this.onShown);
            this.menuNotify.ResumeLayout (false);
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem ctxItemOptions;
        private System.Windows.Forms.ToolStripMenuItem ctxItemExit;
        private System.Windows.Forms.ToolStripSeparator ctxSepBegin;
        private System.Windows.Forms.ToolStripSeparator ctxSepEnd;
        private System.ComponentModel.BackgroundWorker shownWorker;
        private ParamCtrl paramCtrl;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
    }
}

