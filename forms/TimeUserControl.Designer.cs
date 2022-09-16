namespace LakaCubeTimer.forms {
    partial class TimeUserControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(3, 3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(76, 33);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Time";
            this.labelTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseClick);
            this.labelTime.MouseEnter += new System.EventHandler(this.labelTime_MouseEnter);
            this.labelTime.MouseLeave += new System.EventHandler(this.labelTime_MouseLeave);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(3, 44);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(81, 33);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date";
            this.labelDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelDate_MouseClick);
            this.labelDate.MouseEnter += new System.EventHandler(this.labelDate_MouseEnter);
            this.labelDate.MouseLeave += new System.EventHandler(this.labelDate_MouseLeave);
            // 
            // TimeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTime);
            this.Name = "TimeUserControl";
            this.Size = new System.Drawing.Size(240, 80);
            this.Load += new System.EventHandler(this.TimeUserControl_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TimeUserControl_MouseClick);
            this.MouseEnter += new System.EventHandler(this.TimeUserControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TimeUserControl_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelTime;
        private Label labelDate;
    }
}
