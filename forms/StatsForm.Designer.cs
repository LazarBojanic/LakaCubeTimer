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
            this.labelId = new System.Windows.Forms.Label();
            this.labelSession = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeInMilliseconds = new System.Windows.Forms.Label();
            this.labelIsPlusTwo = new System.Windows.Forms.Label();
            this.labelIsDNF = new System.Windows.Forms.Label();
            this.labelScramble = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelId.Location = new System.Drawing.Point(12, 9);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(28, 22);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            // 
            // labelSession
            // 
            this.labelSession.AutoSize = true;
            this.labelSession.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSession.Location = new System.Drawing.Point(12, 39);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(72, 22);
            this.labelSession.TabIndex = 1;
            this.labelSession.Text = "Session";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTime.Location = new System.Drawing.Point(12, 69);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(50, 22);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "Time";
            // 
            // labelTimeInMilliseconds
            // 
            this.labelTimeInMilliseconds.AutoSize = true;
            this.labelTimeInMilliseconds.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimeInMilliseconds.Location = new System.Drawing.Point(12, 99);
            this.labelTimeInMilliseconds.Name = "labelTimeInMilliseconds";
            this.labelTimeInMilliseconds.Size = new System.Drawing.Size(181, 22);
            this.labelTimeInMilliseconds.TabIndex = 3;
            this.labelTimeInMilliseconds.Text = "Time In Milliseconds";
            // 
            // labelIsPlusTwo
            // 
            this.labelIsPlusTwo.AutoSize = true;
            this.labelIsPlusTwo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIsPlusTwo.Location = new System.Drawing.Point(12, 129);
            this.labelIsPlusTwo.Name = "labelIsPlusTwo";
            this.labelIsPlusTwo.Size = new System.Drawing.Size(101, 22);
            this.labelIsPlusTwo.TabIndex = 4;
            this.labelIsPlusTwo.Text = "Is Plus Two";
            // 
            // labelIsDNF
            // 
            this.labelIsDNF.AutoSize = true;
            this.labelIsDNF.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIsDNF.Location = new System.Drawing.Point(12, 159);
            this.labelIsDNF.Name = "labelIsDNF";
            this.labelIsDNF.Size = new System.Drawing.Size(64, 22);
            this.labelIsDNF.TabIndex = 5;
            this.labelIsDNF.Text = "Is DNF";
            // 
            // labelScramble
            // 
            this.labelScramble.AutoSize = true;
            this.labelScramble.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScramble.Location = new System.Drawing.Point(12, 189);
            this.labelScramble.Name = "labelScramble";
            this.labelScramble.Size = new System.Drawing.Size(95, 22);
            this.labelScramble.TabIndex = 6;
            this.labelScramble.Text = "Scramble";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(12, 219);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(56, 22);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Date";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 261);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelScramble);
            this.Controls.Add(this.labelIsDNF);
            this.Controls.Add(this.labelIsPlusTwo);
            this.Controls.Add(this.labelTimeInMilliseconds);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSession);
            this.Controls.Add(this.labelId);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelId;
        private Label labelSession;
        private Label labelTime;
        private Label labelTimeInMilliseconds;
        private Label labelIsPlusTwo;
        private Label labelIsDNF;
        private Label labelScramble;
        private Label labelDate;
    }
}