namespace LakaCubeTimer {
    partial class CubeTimerForm {
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
            this.components = new System.ComponentModel.Container();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timerCube = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelPuzzles = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTimer = new System.Windows.Forms.Panel();
            this.labelScramble = new System.Windows.Forms.Label();
            this.panelTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimer.Location = new System.Drawing.Point(145, 165);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(527, 115);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.Text = "00 : 00 : 00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCube
            // 
            this.timerCube.Interval = 10;
            this.timerCube.Tick += new System.EventHandler(this.timerCube_Tick);
            // 
            // flowLayoutPanelPuzzles
            // 
            this.flowLayoutPanelPuzzles.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelPuzzles.Name = "flowLayoutPanelPuzzles";
            this.flowLayoutPanelPuzzles.Size = new System.Drawing.Size(159, 636);
            this.flowLayoutPanelPuzzles.TabIndex = 1;
            // 
            // panelTimer
            // 
            this.panelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTimer.Controls.Add(this.labelScramble);
            this.panelTimer.Controls.Add(this.labelTimer);
            this.panelTimer.Location = new System.Drawing.Point(177, 12);
            this.panelTimer.Name = "panelTimer";
            this.panelTimer.Size = new System.Drawing.Size(817, 636);
            this.panelTimer.TabIndex = 2;
            // 
            // labelScramble
            // 
            this.labelScramble.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelScramble.AutoSize = true;
            this.labelScramble.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScramble.Location = new System.Drawing.Point(22, 22);
            this.labelScramble.Name = "labelScramble";
            this.labelScramble.Size = new System.Drawing.Size(0, 39);
            this.labelScramble.TabIndex = 1;
            this.labelScramble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CubeTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 660);
            this.Controls.Add(this.panelTimer);
            this.Controls.Add(this.flowLayoutPanelPuzzles);
            this.Name = "CubeTimerForm";
            this.Text = "CubeTimerForm";
            this.Load += new System.EventHandler(this.CubeTimerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CubeTimerForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CubeTimerForm_KeyUp);
            this.panelTimer.ResumeLayout(false);
            this.panelTimer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelTimer;
        private System.Windows.Forms.Timer timerCube;
        private FlowLayoutPanel flowLayoutPanelPuzzles;
        private Panel panelTimer;
        private Label labelScramble;
    }
}