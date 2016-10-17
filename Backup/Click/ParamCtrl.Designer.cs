namespace Click {
    partial class ParamCtrl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.panelBegin = new System.Windows.Forms.Panel ();
            this.panelEnd = new System.Windows.Forms.Panel ();
            this.panelExit = new System.Windows.Forms.Panel ();
            this.label1 = new System.Windows.Forms.Label ();
            this.label2 = new System.Windows.Forms.Label ();
            this.label3 = new System.Windows.Forms.Label ();
            this.editSpeed = new System.Windows.Forms.NumericUpDown ();
            this.label4 = new System.Windows.Forms.Label ();
            this.panel1 = new System.Windows.Forms.Panel ();
            this.label5 = new System.Windows.Forms.Label ();
            this.panel2 = new System.Windows.Forms.Panel ();
            ((System.ComponentModel.ISupportInitialize)(this.editSpeed)).BeginInit ();
            this.SuspendLayout ();
            // 
            // panelBegin
            // 
            this.panelBegin.Location = new System.Drawing.Point (140, 80);
            this.panelBegin.Name = "panelBegin";
            this.panelBegin.Size = new System.Drawing.Size (135, 27);
            this.panelBegin.TabIndex = 0;
            // 
            // panelEnd
            // 
            this.panelEnd.Location = new System.Drawing.Point (140, 113);
            this.panelEnd.Name = "panelEnd";
            this.panelEnd.Size = new System.Drawing.Size (135, 27);
            this.panelEnd.TabIndex = 1;
            // 
            // panelExit
            // 
            this.panelExit.Location = new System.Drawing.Point (140, 146);
            this.panelExit.Name = "panelExit";
            this.panelExit.Size = new System.Drawing.Size (135, 27);
            this.panelExit.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font ("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point (7, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (127, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Запуск";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font ("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point (7, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size (127, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Остановка";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font ("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point (7, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size (127, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выход";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editSpeed
            // 
            this.editSpeed.Font = new System.Drawing.Font ("Segoe UI", 10F);
            this.editSpeed.Location = new System.Drawing.Point (140, 43);
            this.editSpeed.Minimum = new decimal (new int[] {
            1,
            0,
            0,
            0});
            this.editSpeed.Name = "editSpeed";
            this.editSpeed.Size = new System.Drawing.Size (135, 25);
            this.editSpeed.TabIndex = 1;
            this.editSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.editSpeed.Value = new decimal (new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font ("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point (8, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size (126, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кликов в секунду";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point (4, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size (268, 1);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font ("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point (3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size (275, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "Параметры";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point (5, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size (268, 1);
            this.panel2.TabIndex = 9;
            // 
            // HotKeyCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add (this.panel2);
            this.Controls.Add (this.label5);
            this.Controls.Add (this.panel1);
            this.Controls.Add (this.label4);
            this.Controls.Add (this.editSpeed);
            this.Controls.Add (this.label3);
            this.Controls.Add (this.label2);
            this.Controls.Add (this.label1);
            this.Controls.Add (this.panelExit);
            this.Controls.Add (this.panelEnd);
            this.Controls.Add (this.panelBegin);
            this.Name = "HotKeyCtrl";
            this.Size = new System.Drawing.Size (278, 179);
            ((System.ComponentModel.ISupportInitialize)(this.editSpeed)).EndInit ();
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBegin;
        private System.Windows.Forms.Panel panelEnd;
        private System.Windows.Forms.Panel panelExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown editSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
    }
}
