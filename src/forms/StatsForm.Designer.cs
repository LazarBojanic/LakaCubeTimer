namespace WinterCubeTimer.forms {
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
            labelSession = new Label();
            labelTime = new Label();
            labelScramble = new Label();
            labelDate = new Label();
            textBoxScramble = new TextBox();
            SuspendLayout();
            // 
            // labelSession
            // 
            labelSession.AutoSize = true;
            labelSession.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSession.Location = new Point(12, 24);
            labelSession.Name = "labelSession";
            labelSession.Size = new Size(82, 22);
            labelSession.TabIndex = 1;
            labelSession.Text = "Session: ";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelTime.Location = new Point(12, 99);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(60, 22);
            labelTime.TabIndex = 2;
            labelTime.Text = "Time: ";
            // 
            // labelScramble
            // 
            labelScramble.AutoSize = true;
            labelScramble.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelScramble.Location = new Point(12, 174);
            labelScramble.Name = "labelScramble";
            labelScramble.Size = new Size(105, 22);
            labelScramble.TabIndex = 6;
            labelScramble.Text = "Scramble: ";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDate.Location = new Point(12, 249);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(66, 22);
            labelDate.TabIndex = 7;
            labelDate.Text = "Date: ";
            // 
            // textBoxScramble
            // 
            textBoxScramble.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxScramble.Location = new Point(123, 167);
            textBoxScramble.Name = "textBoxScramble";
            textBoxScramble.ReadOnly = true;
            textBoxScramble.Size = new Size(661, 37);
            textBoxScramble.TabIndex = 8;
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 302);
            Controls.Add(textBoxScramble);
            Controls.Add(labelDate);
            Controls.Add(labelScramble);
            Controls.Add(labelTime);
            Controls.Add(labelSession);
            MinimumSize = new Size(718, 341);
            Name = "StatsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StatsForm";
            Load += StatsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelSession;
        private Label labelTime;
        private Label labelScramble;
        private Label labelDate;
        private TextBox textBoxScramble;
    }
}