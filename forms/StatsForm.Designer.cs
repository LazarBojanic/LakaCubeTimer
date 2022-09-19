namespace LakaCubeTimer.forms {
    partial class StatsForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelSession = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelScramble = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxScramble = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelSession
            // 
            this.labelSession.AutoSize = true;
            this.labelSession.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSession.Location = new System.Drawing.Point(12, 24);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(82, 22);
            this.labelSession.TabIndex = 1;
            this.labelSession.Text = "Session: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(12, 71);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 22);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "Time: ";
            // 
            // labelScramble
            // 
            this.labelScramble.AutoSize = true;
            this.labelScramble.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScramble.Location = new System.Drawing.Point(12, 118);
            this.labelScramble.Name = "labelScramble";
            this.labelScramble.Size = new System.Drawing.Size(105, 22);
            this.labelScramble.TabIndex = 6;
            this.labelScramble.Text = "Scramble: ";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(12, 165);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(66, 22);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Date: ";
            // 
            // textBoxScramble
            // 
            this.textBoxScramble.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxScramble.Location = new System.Drawing.Point(123, 114);
            this.textBoxScramble.Name = "textBoxScramble";
            this.textBoxScramble.Size = new System.Drawing.Size(391, 31);
            this.textBoxScramble.TabIndex = 8;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 211);
            this.Controls.Add(this.textBoxScramble);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelScramble);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSession);
            this.MinimumSize = new System.Drawing.Size(542, 250);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSession;
        private Label labelTime;
        private Label labelScramble;
        private Label labelDate;
        private TextBox textBoxScramble;
    }
}