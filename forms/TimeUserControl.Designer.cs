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
            this.checkBoxPlusTwo = new System.Windows.Forms.CheckBox();
            this.checkBoxDNF = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(6, 25);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(70, 30);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Time";
            this.labelTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseClick);
            this.labelTime.MouseEnter += new System.EventHandler(this.labelTime_MouseEnter);
            this.labelTime.MouseLeave += new System.EventHandler(this.labelTime_MouseLeave);
            // 
            // checkBoxPlusTwo
            // 
            this.checkBoxPlusTwo.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPlusTwo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxPlusTwo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPlusTwo.Location = new System.Drawing.Point(132, 16);
            this.checkBoxPlusTwo.Name = "checkBoxPlusTwo";
            this.checkBoxPlusTwo.Size = new System.Drawing.Size(48, 48);
            this.checkBoxPlusTwo.TabIndex = 1;
            this.checkBoxPlusTwo.Text = "+2";
            this.checkBoxPlusTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPlusTwo.UseVisualStyleBackColor = true;
            this.checkBoxPlusTwo.CheckedChanged += new System.EventHandler(this.checkBoxPlusTwo_CheckedChanged);
            // 
            // checkBoxDNF
            // 
            this.checkBoxDNF.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxDNF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxDNF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxDNF.Location = new System.Drawing.Point(186, 16);
            this.checkBoxDNF.Name = "checkBoxDNF";
            this.checkBoxDNF.Size = new System.Drawing.Size(48, 48);
            this.checkBoxDNF.TabIndex = 2;
            this.checkBoxDNF.Text = "DNF";
            this.checkBoxDNF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxDNF.UseVisualStyleBackColor = true;
            this.checkBoxDNF.CheckedChanged += new System.EventHandler(this.checkBoxDNF_CheckedChanged);
            // 
            // TimeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxDNF);
            this.Controls.Add(this.checkBoxPlusTwo);
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
        private CheckBox checkBoxPlusTwo;
        private CheckBox checkBoxDNF;
    }
}
