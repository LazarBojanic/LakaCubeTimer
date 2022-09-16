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
            this.panelTimer = new System.Windows.Forms.Panel();
            this.buttonDownTurn = new System.Windows.Forms.Button();
            this.buttonBackTurn = new System.Windows.Forms.Button();
            this.buttonRightTurn = new System.Windows.Forms.Button();
            this.buttonUpTurn = new System.Windows.Forms.Button();
            this.buttonFrontTurn = new System.Windows.Forms.Button();
            this.buttonLeftTurn = new System.Windows.Forms.Button();
            this.panelCube = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelDown8 = new System.Windows.Forms.Panel();
            this.panelDown0 = new System.Windows.Forms.Panel();
            this.panelDown7 = new System.Windows.Forms.Panel();
            this.panelDown1 = new System.Windows.Forms.Panel();
            this.panelDown6 = new System.Windows.Forms.Panel();
            this.panelDown2 = new System.Windows.Forms.Panel();
            this.panelDown5 = new System.Windows.Forms.Panel();
            this.panelDown3 = new System.Windows.Forms.Panel();
            this.panelDown4 = new System.Windows.Forms.Panel();
            this.panelBack = new System.Windows.Forms.Panel();
            this.panelBack8 = new System.Windows.Forms.Panel();
            this.panelBack0 = new System.Windows.Forms.Panel();
            this.panelBack7 = new System.Windows.Forms.Panel();
            this.panelBack1 = new System.Windows.Forms.Panel();
            this.panelBack6 = new System.Windows.Forms.Panel();
            this.panelBack2 = new System.Windows.Forms.Panel();
            this.panelBack5 = new System.Windows.Forms.Panel();
            this.panelBack3 = new System.Windows.Forms.Panel();
            this.panelBack4 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRight8 = new System.Windows.Forms.Panel();
            this.panelRight0 = new System.Windows.Forms.Panel();
            this.panelRight7 = new System.Windows.Forms.Panel();
            this.panelRight1 = new System.Windows.Forms.Panel();
            this.panelRight6 = new System.Windows.Forms.Panel();
            this.panelRight2 = new System.Windows.Forms.Panel();
            this.panelRight5 = new System.Windows.Forms.Panel();
            this.panelRight3 = new System.Windows.Forms.Panel();
            this.panelRight4 = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelUp8 = new System.Windows.Forms.Panel();
            this.panelUp0 = new System.Windows.Forms.Panel();
            this.panelUp7 = new System.Windows.Forms.Panel();
            this.panelUp1 = new System.Windows.Forms.Panel();
            this.panelUp6 = new System.Windows.Forms.Panel();
            this.panelUp2 = new System.Windows.Forms.Panel();
            this.panelUp5 = new System.Windows.Forms.Panel();
            this.panelUp3 = new System.Windows.Forms.Panel();
            this.panelUp4 = new System.Windows.Forms.Panel();
            this.panelFront = new System.Windows.Forms.Panel();
            this.panelFront8 = new System.Windows.Forms.Panel();
            this.panelFront0 = new System.Windows.Forms.Panel();
            this.panelFront7 = new System.Windows.Forms.Panel();
            this.panelFront1 = new System.Windows.Forms.Panel();
            this.panelFront6 = new System.Windows.Forms.Panel();
            this.panelFront2 = new System.Windows.Forms.Panel();
            this.panelFront5 = new System.Windows.Forms.Panel();
            this.panelFront3 = new System.Windows.Forms.Panel();
            this.panelFront4 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelLeft8 = new System.Windows.Forms.Panel();
            this.panelLeft7 = new System.Windows.Forms.Panel();
            this.panelLeft6 = new System.Windows.Forms.Panel();
            this.panelLeft5 = new System.Windows.Forms.Panel();
            this.panelLeft4 = new System.Windows.Forms.Panel();
            this.panelLeft3 = new System.Windows.Forms.Panel();
            this.panelLeft2 = new System.Windows.Forms.Panel();
            this.panelLeft1 = new System.Windows.Forms.Panel();
            this.panelLeft0 = new System.Windows.Forms.Panel();
            this.labelScramble = new System.Windows.Forms.Label();
            this.flowLayoutPanelTimes = new System.Windows.Forms.FlowLayoutPanel();
            this.panelStats = new System.Windows.Forms.Panel();
            this.labelAverageOfOneHundred = new System.Windows.Forms.Label();
            this.labelBestTime = new System.Windows.Forms.Label();
            this.labelAverageOfTwelve = new System.Windows.Forms.Label();
            this.labelAverageOfFive = new System.Windows.Forms.Label();
            this.comboBoxSession = new System.Windows.Forms.ComboBox();
            this.panelTimer.SuspendLayout();
            this.panelCube.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.panelBack.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.panelFront.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimer.Location = new System.Drawing.Point(292, 165);
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
            // panelTimer
            // 
            this.panelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTimer.Controls.Add(this.buttonDownTurn);
            this.panelTimer.Controls.Add(this.buttonBackTurn);
            this.panelTimer.Controls.Add(this.buttonRightTurn);
            this.panelTimer.Controls.Add(this.buttonUpTurn);
            this.panelTimer.Controls.Add(this.buttonFrontTurn);
            this.panelTimer.Controls.Add(this.buttonLeftTurn);
            this.panelTimer.Controls.Add(this.panelCube);
            this.panelTimer.Controls.Add(this.labelScramble);
            this.panelTimer.Controls.Add(this.labelTimer);
            this.panelTimer.Location = new System.Drawing.Point(270, 12);
            this.panelTimer.Name = "panelTimer";
            this.panelTimer.Size = new System.Drawing.Size(1111, 771);
            this.panelTimer.TabIndex = 2;
            // 
            // buttonDownTurn
            // 
            this.buttonDownTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDownTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDownTurn.Location = new System.Drawing.Point(117, 660);
            this.buttonDownTurn.Name = "buttonDownTurn";
            this.buttonDownTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonDownTurn.TabIndex = 7;
            this.buttonDownTurn.TabStop = false;
            this.buttonDownTurn.Text = "Down";
            this.buttonDownTurn.UseVisualStyleBackColor = true;
            this.buttonDownTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDownTurn_MouseDown);
            // 
            // buttonBackTurn
            // 
            this.buttonBackTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBackTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBackTurn.Location = new System.Drawing.Point(345, 546);
            this.buttonBackTurn.Name = "buttonBackTurn";
            this.buttonBackTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonBackTurn.TabIndex = 6;
            this.buttonBackTurn.TabStop = false;
            this.buttonBackTurn.Text = "Back";
            this.buttonBackTurn.UseVisualStyleBackColor = true;
            this.buttonBackTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBackTurn_MouseDown);
            // 
            // buttonRightTurn
            // 
            this.buttonRightTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRightTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRightTurn.Location = new System.Drawing.Point(231, 546);
            this.buttonRightTurn.Name = "buttonRightTurn";
            this.buttonRightTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonRightTurn.TabIndex = 5;
            this.buttonRightTurn.TabStop = false;
            this.buttonRightTurn.Text = "Right";
            this.buttonRightTurn.UseVisualStyleBackColor = true;
            this.buttonRightTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRightTurn_MouseDown);
            // 
            // buttonUpTurn
            // 
            this.buttonUpTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUpTurn.Location = new System.Drawing.Point(117, 432);
            this.buttonUpTurn.Name = "buttonUpTurn";
            this.buttonUpTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonUpTurn.TabIndex = 4;
            this.buttonUpTurn.TabStop = false;
            this.buttonUpTurn.Text = "Up";
            this.buttonUpTurn.UseVisualStyleBackColor = true;
            this.buttonUpTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUpTurn_MouseDown);
            // 
            // buttonFrontTurn
            // 
            this.buttonFrontTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFrontTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFrontTurn.Location = new System.Drawing.Point(117, 546);
            this.buttonFrontTurn.Name = "buttonFrontTurn";
            this.buttonFrontTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonFrontTurn.TabIndex = 3;
            this.buttonFrontTurn.TabStop = false;
            this.buttonFrontTurn.Text = "Front";
            this.buttonFrontTurn.UseVisualStyleBackColor = true;
            this.buttonFrontTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFrontTurn_MouseDown);
            // 
            // buttonLeftTurn
            // 
            this.buttonLeftTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLeftTurn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLeftTurn.Location = new System.Drawing.Point(3, 546);
            this.buttonLeftTurn.Name = "buttonLeftTurn";
            this.buttonLeftTurn.Size = new System.Drawing.Size(108, 108);
            this.buttonLeftTurn.TabIndex = 2;
            this.buttonLeftTurn.TabStop = false;
            this.buttonLeftTurn.Text = "Left";
            this.buttonLeftTurn.UseVisualStyleBackColor = true;
            this.buttonLeftTurn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeftTurn_MouseDown);
            // 
            // panelCube
            // 
            this.panelCube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCube.Controls.Add(this.panelDown);
            this.panelCube.Controls.Add(this.panelBack);
            this.panelCube.Controls.Add(this.panelRight);
            this.panelCube.Controls.Add(this.panelUp);
            this.panelCube.Controls.Add(this.panelFront);
            this.panelCube.Controls.Add(this.panelLeft);
            this.panelCube.Location = new System.Drawing.Point(652, 426);
            this.panelCube.Name = "panelCube";
            this.panelCube.Size = new System.Drawing.Size(456, 342);
            this.panelCube.TabIndex = 1;
            // 
            // panelDown
            // 
            this.panelDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown.BackColor = System.Drawing.Color.Black;
            this.panelDown.Controls.Add(this.panelDown8);
            this.panelDown.Controls.Add(this.panelDown0);
            this.panelDown.Controls.Add(this.panelDown7);
            this.panelDown.Controls.Add(this.panelDown1);
            this.panelDown.Controls.Add(this.panelDown6);
            this.panelDown.Controls.Add(this.panelDown2);
            this.panelDown.Controls.Add(this.panelDown5);
            this.panelDown.Controls.Add(this.panelDown3);
            this.panelDown.Controls.Add(this.panelDown4);
            this.panelDown.Location = new System.Drawing.Point(117, 231);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(108, 108);
            this.panelDown.TabIndex = 1;
            // 
            // panelDown8
            // 
            this.panelDown8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown8.Location = new System.Drawing.Point(75, 75);
            this.panelDown8.Name = "panelDown8";
            this.panelDown8.Size = new System.Drawing.Size(30, 30);
            this.panelDown8.TabIndex = 8;
            // 
            // panelDown0
            // 
            this.panelDown0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown0.Location = new System.Drawing.Point(3, 3);
            this.panelDown0.Name = "panelDown0";
            this.panelDown0.Size = new System.Drawing.Size(30, 30);
            this.panelDown0.TabIndex = 0;
            // 
            // panelDown7
            // 
            this.panelDown7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown7.Location = new System.Drawing.Point(39, 75);
            this.panelDown7.Name = "panelDown7";
            this.panelDown7.Size = new System.Drawing.Size(30, 30);
            this.panelDown7.TabIndex = 7;
            // 
            // panelDown1
            // 
            this.panelDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown1.Location = new System.Drawing.Point(39, 3);
            this.panelDown1.Name = "panelDown1";
            this.panelDown1.Size = new System.Drawing.Size(30, 30);
            this.panelDown1.TabIndex = 1;
            // 
            // panelDown6
            // 
            this.panelDown6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown6.Location = new System.Drawing.Point(3, 75);
            this.panelDown6.Name = "panelDown6";
            this.panelDown6.Size = new System.Drawing.Size(30, 30);
            this.panelDown6.TabIndex = 6;
            // 
            // panelDown2
            // 
            this.panelDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown2.Location = new System.Drawing.Point(75, 3);
            this.panelDown2.Name = "panelDown2";
            this.panelDown2.Size = new System.Drawing.Size(30, 30);
            this.panelDown2.TabIndex = 2;
            // 
            // panelDown5
            // 
            this.panelDown5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown5.Location = new System.Drawing.Point(75, 39);
            this.panelDown5.Name = "panelDown5";
            this.panelDown5.Size = new System.Drawing.Size(30, 30);
            this.panelDown5.TabIndex = 5;
            // 
            // panelDown3
            // 
            this.panelDown3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown3.Location = new System.Drawing.Point(3, 39);
            this.panelDown3.Name = "panelDown3";
            this.panelDown3.Size = new System.Drawing.Size(30, 30);
            this.panelDown3.TabIndex = 3;
            // 
            // panelDown4
            // 
            this.panelDown4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDown4.Location = new System.Drawing.Point(39, 39);
            this.panelDown4.Name = "panelDown4";
            this.panelDown4.Size = new System.Drawing.Size(30, 30);
            this.panelDown4.TabIndex = 4;
            // 
            // panelBack
            // 
            this.panelBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack.BackColor = System.Drawing.Color.Black;
            this.panelBack.Controls.Add(this.panelBack8);
            this.panelBack.Controls.Add(this.panelBack0);
            this.panelBack.Controls.Add(this.panelBack7);
            this.panelBack.Controls.Add(this.panelBack1);
            this.panelBack.Controls.Add(this.panelBack6);
            this.panelBack.Controls.Add(this.panelBack2);
            this.panelBack.Controls.Add(this.panelBack5);
            this.panelBack.Controls.Add(this.panelBack3);
            this.panelBack.Controls.Add(this.panelBack4);
            this.panelBack.Location = new System.Drawing.Point(345, 117);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(108, 108);
            this.panelBack.TabIndex = 5;
            // 
            // panelBack8
            // 
            this.panelBack8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack8.Location = new System.Drawing.Point(75, 75);
            this.panelBack8.Name = "panelBack8";
            this.panelBack8.Size = new System.Drawing.Size(30, 30);
            this.panelBack8.TabIndex = 8;
            // 
            // panelBack0
            // 
            this.panelBack0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack0.Location = new System.Drawing.Point(3, 3);
            this.panelBack0.Name = "panelBack0";
            this.panelBack0.Size = new System.Drawing.Size(30, 30);
            this.panelBack0.TabIndex = 0;
            // 
            // panelBack7
            // 
            this.panelBack7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack7.Location = new System.Drawing.Point(39, 75);
            this.panelBack7.Name = "panelBack7";
            this.panelBack7.Size = new System.Drawing.Size(30, 30);
            this.panelBack7.TabIndex = 7;
            // 
            // panelBack1
            // 
            this.panelBack1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack1.Location = new System.Drawing.Point(39, 3);
            this.panelBack1.Name = "panelBack1";
            this.panelBack1.Size = new System.Drawing.Size(30, 30);
            this.panelBack1.TabIndex = 1;
            // 
            // panelBack6
            // 
            this.panelBack6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack6.Location = new System.Drawing.Point(3, 75);
            this.panelBack6.Name = "panelBack6";
            this.panelBack6.Size = new System.Drawing.Size(30, 30);
            this.panelBack6.TabIndex = 6;
            // 
            // panelBack2
            // 
            this.panelBack2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack2.Location = new System.Drawing.Point(75, 3);
            this.panelBack2.Name = "panelBack2";
            this.panelBack2.Size = new System.Drawing.Size(30, 30);
            this.panelBack2.TabIndex = 2;
            // 
            // panelBack5
            // 
            this.panelBack5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack5.Location = new System.Drawing.Point(75, 39);
            this.panelBack5.Name = "panelBack5";
            this.panelBack5.Size = new System.Drawing.Size(30, 30);
            this.panelBack5.TabIndex = 5;
            // 
            // panelBack3
            // 
            this.panelBack3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack3.Location = new System.Drawing.Point(3, 39);
            this.panelBack3.Name = "panelBack3";
            this.panelBack3.Size = new System.Drawing.Size(30, 30);
            this.panelBack3.TabIndex = 3;
            // 
            // panelBack4
            // 
            this.panelBack4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBack4.Location = new System.Drawing.Point(39, 39);
            this.panelBack4.Name = "panelBack4";
            this.panelBack4.Size = new System.Drawing.Size(30, 30);
            this.panelBack4.TabIndex = 4;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.Black;
            this.panelRight.Controls.Add(this.panelRight8);
            this.panelRight.Controls.Add(this.panelRight0);
            this.panelRight.Controls.Add(this.panelRight7);
            this.panelRight.Controls.Add(this.panelRight1);
            this.panelRight.Controls.Add(this.panelRight6);
            this.panelRight.Controls.Add(this.panelRight2);
            this.panelRight.Controls.Add(this.panelRight5);
            this.panelRight.Controls.Add(this.panelRight3);
            this.panelRight.Controls.Add(this.panelRight4);
            this.panelRight.Location = new System.Drawing.Point(231, 117);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(108, 108);
            this.panelRight.TabIndex = 3;
            // 
            // panelRight8
            // 
            this.panelRight8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight8.Location = new System.Drawing.Point(75, 75);
            this.panelRight8.Name = "panelRight8";
            this.panelRight8.Size = new System.Drawing.Size(30, 30);
            this.panelRight8.TabIndex = 8;
            // 
            // panelRight0
            // 
            this.panelRight0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight0.Location = new System.Drawing.Point(3, 3);
            this.panelRight0.Name = "panelRight0";
            this.panelRight0.Size = new System.Drawing.Size(30, 30);
            this.panelRight0.TabIndex = 0;
            // 
            // panelRight7
            // 
            this.panelRight7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight7.Location = new System.Drawing.Point(39, 75);
            this.panelRight7.Name = "panelRight7";
            this.panelRight7.Size = new System.Drawing.Size(30, 30);
            this.panelRight7.TabIndex = 7;
            // 
            // panelRight1
            // 
            this.panelRight1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight1.Location = new System.Drawing.Point(39, 3);
            this.panelRight1.Name = "panelRight1";
            this.panelRight1.Size = new System.Drawing.Size(30, 30);
            this.panelRight1.TabIndex = 1;
            // 
            // panelRight6
            // 
            this.panelRight6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight6.Location = new System.Drawing.Point(3, 75);
            this.panelRight6.Name = "panelRight6";
            this.panelRight6.Size = new System.Drawing.Size(30, 30);
            this.panelRight6.TabIndex = 6;
            // 
            // panelRight2
            // 
            this.panelRight2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight2.Location = new System.Drawing.Point(75, 3);
            this.panelRight2.Name = "panelRight2";
            this.panelRight2.Size = new System.Drawing.Size(30, 30);
            this.panelRight2.TabIndex = 2;
            // 
            // panelRight5
            // 
            this.panelRight5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight5.Location = new System.Drawing.Point(75, 39);
            this.panelRight5.Name = "panelRight5";
            this.panelRight5.Size = new System.Drawing.Size(30, 30);
            this.panelRight5.TabIndex = 5;
            // 
            // panelRight3
            // 
            this.panelRight3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight3.Location = new System.Drawing.Point(3, 39);
            this.panelRight3.Name = "panelRight3";
            this.panelRight3.Size = new System.Drawing.Size(30, 30);
            this.panelRight3.TabIndex = 3;
            // 
            // panelRight4
            // 
            this.panelRight4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight4.Location = new System.Drawing.Point(39, 39);
            this.panelRight4.Name = "panelRight4";
            this.panelRight4.Size = new System.Drawing.Size(30, 30);
            this.panelRight4.TabIndex = 4;
            // 
            // panelUp
            // 
            this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp.BackColor = System.Drawing.Color.Black;
            this.panelUp.Controls.Add(this.panelUp8);
            this.panelUp.Controls.Add(this.panelUp0);
            this.panelUp.Controls.Add(this.panelUp7);
            this.panelUp.Controls.Add(this.panelUp1);
            this.panelUp.Controls.Add(this.panelUp6);
            this.panelUp.Controls.Add(this.panelUp2);
            this.panelUp.Controls.Add(this.panelUp5);
            this.panelUp.Controls.Add(this.panelUp3);
            this.panelUp.Controls.Add(this.panelUp4);
            this.panelUp.Location = new System.Drawing.Point(117, 3);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(108, 108);
            this.panelUp.TabIndex = 0;
            // 
            // panelUp8
            // 
            this.panelUp8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp8.Location = new System.Drawing.Point(75, 75);
            this.panelUp8.Name = "panelUp8";
            this.panelUp8.Size = new System.Drawing.Size(30, 30);
            this.panelUp8.TabIndex = 8;
            // 
            // panelUp0
            // 
            this.panelUp0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp0.Location = new System.Drawing.Point(3, 3);
            this.panelUp0.Name = "panelUp0";
            this.panelUp0.Size = new System.Drawing.Size(30, 30);
            this.panelUp0.TabIndex = 0;
            // 
            // panelUp7
            // 
            this.panelUp7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp7.Location = new System.Drawing.Point(39, 75);
            this.panelUp7.Name = "panelUp7";
            this.panelUp7.Size = new System.Drawing.Size(30, 30);
            this.panelUp7.TabIndex = 7;
            // 
            // panelUp1
            // 
            this.panelUp1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp1.Location = new System.Drawing.Point(39, 3);
            this.panelUp1.Name = "panelUp1";
            this.panelUp1.Size = new System.Drawing.Size(30, 30);
            this.panelUp1.TabIndex = 1;
            // 
            // panelUp6
            // 
            this.panelUp6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp6.Location = new System.Drawing.Point(3, 75);
            this.panelUp6.Name = "panelUp6";
            this.panelUp6.Size = new System.Drawing.Size(30, 30);
            this.panelUp6.TabIndex = 6;
            // 
            // panelUp2
            // 
            this.panelUp2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp2.Location = new System.Drawing.Point(75, 3);
            this.panelUp2.Name = "panelUp2";
            this.panelUp2.Size = new System.Drawing.Size(30, 30);
            this.panelUp2.TabIndex = 2;
            // 
            // panelUp5
            // 
            this.panelUp5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp5.Location = new System.Drawing.Point(75, 39);
            this.panelUp5.Name = "panelUp5";
            this.panelUp5.Size = new System.Drawing.Size(30, 30);
            this.panelUp5.TabIndex = 5;
            // 
            // panelUp3
            // 
            this.panelUp3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp3.Location = new System.Drawing.Point(3, 39);
            this.panelUp3.Name = "panelUp3";
            this.panelUp3.Size = new System.Drawing.Size(30, 30);
            this.panelUp3.TabIndex = 3;
            // 
            // panelUp4
            // 
            this.panelUp4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp4.Location = new System.Drawing.Point(39, 39);
            this.panelUp4.Name = "panelUp4";
            this.panelUp4.Size = new System.Drawing.Size(30, 30);
            this.panelUp4.TabIndex = 4;
            // 
            // panelFront
            // 
            this.panelFront.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront.BackColor = System.Drawing.Color.Black;
            this.panelFront.Controls.Add(this.panelFront8);
            this.panelFront.Controls.Add(this.panelFront0);
            this.panelFront.Controls.Add(this.panelFront7);
            this.panelFront.Controls.Add(this.panelFront1);
            this.panelFront.Controls.Add(this.panelFront6);
            this.panelFront.Controls.Add(this.panelFront2);
            this.panelFront.Controls.Add(this.panelFront5);
            this.panelFront.Controls.Add(this.panelFront3);
            this.panelFront.Controls.Add(this.panelFront4);
            this.panelFront.Location = new System.Drawing.Point(117, 117);
            this.panelFront.Name = "panelFront";
            this.panelFront.Size = new System.Drawing.Size(108, 108);
            this.panelFront.TabIndex = 4;
            // 
            // panelFront8
            // 
            this.panelFront8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront8.Location = new System.Drawing.Point(75, 75);
            this.panelFront8.Name = "panelFront8";
            this.panelFront8.Size = new System.Drawing.Size(30, 30);
            this.panelFront8.TabIndex = 8;
            // 
            // panelFront0
            // 
            this.panelFront0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront0.Location = new System.Drawing.Point(3, 3);
            this.panelFront0.Name = "panelFront0";
            this.panelFront0.Size = new System.Drawing.Size(30, 30);
            this.panelFront0.TabIndex = 0;
            // 
            // panelFront7
            // 
            this.panelFront7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront7.Location = new System.Drawing.Point(39, 75);
            this.panelFront7.Name = "panelFront7";
            this.panelFront7.Size = new System.Drawing.Size(30, 30);
            this.panelFront7.TabIndex = 7;
            // 
            // panelFront1
            // 
            this.panelFront1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront1.Location = new System.Drawing.Point(39, 3);
            this.panelFront1.Name = "panelFront1";
            this.panelFront1.Size = new System.Drawing.Size(30, 30);
            this.panelFront1.TabIndex = 1;
            // 
            // panelFront6
            // 
            this.panelFront6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront6.Location = new System.Drawing.Point(3, 75);
            this.panelFront6.Name = "panelFront6";
            this.panelFront6.Size = new System.Drawing.Size(30, 30);
            this.panelFront6.TabIndex = 6;
            // 
            // panelFront2
            // 
            this.panelFront2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront2.Location = new System.Drawing.Point(75, 3);
            this.panelFront2.Name = "panelFront2";
            this.panelFront2.Size = new System.Drawing.Size(30, 30);
            this.panelFront2.TabIndex = 2;
            // 
            // panelFront5
            // 
            this.panelFront5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront5.Location = new System.Drawing.Point(75, 39);
            this.panelFront5.Name = "panelFront5";
            this.panelFront5.Size = new System.Drawing.Size(30, 30);
            this.panelFront5.TabIndex = 5;
            // 
            // panelFront3
            // 
            this.panelFront3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront3.Location = new System.Drawing.Point(3, 39);
            this.panelFront3.Name = "panelFront3";
            this.panelFront3.Size = new System.Drawing.Size(30, 30);
            this.panelFront3.TabIndex = 3;
            // 
            // panelFront4
            // 
            this.panelFront4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFront4.Location = new System.Drawing.Point(39, 39);
            this.panelFront4.Name = "panelFront4";
            this.panelFront4.Size = new System.Drawing.Size(30, 30);
            this.panelFront4.TabIndex = 4;
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft.BackColor = System.Drawing.Color.Black;
            this.panelLeft.Controls.Add(this.panelLeft8);
            this.panelLeft.Controls.Add(this.panelLeft7);
            this.panelLeft.Controls.Add(this.panelLeft6);
            this.panelLeft.Controls.Add(this.panelLeft5);
            this.panelLeft.Controls.Add(this.panelLeft4);
            this.panelLeft.Controls.Add(this.panelLeft3);
            this.panelLeft.Controls.Add(this.panelLeft2);
            this.panelLeft.Controls.Add(this.panelLeft1);
            this.panelLeft.Controls.Add(this.panelLeft0);
            this.panelLeft.Location = new System.Drawing.Point(3, 117);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(108, 108);
            this.panelLeft.TabIndex = 2;
            // 
            // panelLeft8
            // 
            this.panelLeft8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft8.Location = new System.Drawing.Point(75, 75);
            this.panelLeft8.Name = "panelLeft8";
            this.panelLeft8.Size = new System.Drawing.Size(30, 30);
            this.panelLeft8.TabIndex = 8;
            // 
            // panelLeft7
            // 
            this.panelLeft7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft7.Location = new System.Drawing.Point(39, 75);
            this.panelLeft7.Name = "panelLeft7";
            this.panelLeft7.Size = new System.Drawing.Size(30, 30);
            this.panelLeft7.TabIndex = 7;
            // 
            // panelLeft6
            // 
            this.panelLeft6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft6.Location = new System.Drawing.Point(3, 75);
            this.panelLeft6.Name = "panelLeft6";
            this.panelLeft6.Size = new System.Drawing.Size(30, 30);
            this.panelLeft6.TabIndex = 6;
            // 
            // panelLeft5
            // 
            this.panelLeft5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft5.Location = new System.Drawing.Point(75, 39);
            this.panelLeft5.Name = "panelLeft5";
            this.panelLeft5.Size = new System.Drawing.Size(30, 30);
            this.panelLeft5.TabIndex = 5;
            // 
            // panelLeft4
            // 
            this.panelLeft4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft4.Location = new System.Drawing.Point(39, 39);
            this.panelLeft4.Name = "panelLeft4";
            this.panelLeft4.Size = new System.Drawing.Size(30, 30);
            this.panelLeft4.TabIndex = 4;
            // 
            // panelLeft3
            // 
            this.panelLeft3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft3.Location = new System.Drawing.Point(3, 39);
            this.panelLeft3.Name = "panelLeft3";
            this.panelLeft3.Size = new System.Drawing.Size(30, 30);
            this.panelLeft3.TabIndex = 3;
            // 
            // panelLeft2
            // 
            this.panelLeft2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft2.Location = new System.Drawing.Point(75, 3);
            this.panelLeft2.Name = "panelLeft2";
            this.panelLeft2.Size = new System.Drawing.Size(30, 30);
            this.panelLeft2.TabIndex = 2;
            // 
            // panelLeft1
            // 
            this.panelLeft1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft1.Location = new System.Drawing.Point(39, 3);
            this.panelLeft1.Name = "panelLeft1";
            this.panelLeft1.Size = new System.Drawing.Size(30, 30);
            this.panelLeft1.TabIndex = 1;
            // 
            // panelLeft0
            // 
            this.panelLeft0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft0.Location = new System.Drawing.Point(3, 3);
            this.panelLeft0.Name = "panelLeft0";
            this.panelLeft0.Size = new System.Drawing.Size(30, 30);
            this.panelLeft0.TabIndex = 0;
            // 
            // labelScramble
            // 
            this.labelScramble.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelScramble.AutoSize = true;
            this.labelScramble.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScramble.Location = new System.Drawing.Point(473, 74);
            this.labelScramble.Name = "labelScramble";
            this.labelScramble.Size = new System.Drawing.Size(165, 39);
            this.labelScramble.TabIndex = 1;
            this.labelScramble.Text = "Scramble";
            this.labelScramble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelTimes
            // 
            this.flowLayoutPanelTimes.AutoScroll = true;
            this.flowLayoutPanelTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelTimes.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelTimes.Name = "flowLayoutPanelTimes";
            this.flowLayoutPanelTimes.Size = new System.Drawing.Size(252, 467);
            this.flowLayoutPanelTimes.TabIndex = 3;
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.labelAverageOfOneHundred);
            this.panelStats.Controls.Add(this.labelBestTime);
            this.panelStats.Controls.Add(this.labelAverageOfTwelve);
            this.panelStats.Controls.Add(this.labelAverageOfFive);
            this.panelStats.Location = new System.Drawing.Point(12, 532);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(252, 251);
            this.panelStats.TabIndex = 4;
            // 
            // labelAverageOfOneHundred
            // 
            this.labelAverageOfOneHundred.AutoSize = true;
            this.labelAverageOfOneHundred.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAverageOfOneHundred.Location = new System.Drawing.Point(19, 124);
            this.labelAverageOfOneHundred.Name = "labelAverageOfOneHundred";
            this.labelAverageOfOneHundred.Size = new System.Drawing.Size(75, 22);
            this.labelAverageOfOneHundred.TabIndex = 3;
            this.labelAverageOfOneHundred.Text = "Ao100:";
            // 
            // labelBestTime
            // 
            this.labelBestTime.AutoSize = true;
            this.labelBestTime.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBestTime.Location = new System.Drawing.Point(19, 171);
            this.labelBestTime.Name = "labelBestTime";
            this.labelBestTime.Size = new System.Drawing.Size(97, 22);
            this.labelBestTime.TabIndex = 2;
            this.labelBestTime.Text = "Best Time:";
            // 
            // labelAverageOfTwelve
            // 
            this.labelAverageOfTwelve.AutoSize = true;
            this.labelAverageOfTwelve.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAverageOfTwelve.Location = new System.Drawing.Point(19, 77);
            this.labelAverageOfTwelve.Name = "labelAverageOfTwelve";
            this.labelAverageOfTwelve.Size = new System.Drawing.Size(64, 22);
            this.labelAverageOfTwelve.TabIndex = 1;
            this.labelAverageOfTwelve.Text = "Ao12:";
            // 
            // labelAverageOfFive
            // 
            this.labelAverageOfFive.AutoSize = true;
            this.labelAverageOfFive.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAverageOfFive.Location = new System.Drawing.Point(19, 30);
            this.labelAverageOfFive.Name = "labelAverageOfFive";
            this.labelAverageOfFive.Size = new System.Drawing.Size(53, 22);
            this.labelAverageOfFive.TabIndex = 0;
            this.labelAverageOfFive.Text = "Ao5:";
            // 
            // comboBoxSession
            // 
            this.comboBoxSession.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSession.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxSession.FormattingEnabled = true;
            this.comboBoxSession.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxSession.Location = new System.Drawing.Point(12, 485);
            this.comboBoxSession.Name = "comboBoxSession";
            this.comboBoxSession.Size = new System.Drawing.Size(252, 41);
            this.comboBoxSession.TabIndex = 5;
            this.comboBoxSession.TabStop = false;
            // 
            // CubeTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 795);
            this.Controls.Add(this.comboBoxSession);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.flowLayoutPanelTimes);
            this.Controls.Add(this.panelTimer);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1409, 834);
            this.Name = "CubeTimerForm";
            this.Text = "CubeTimerForm";
            this.Load += new System.EventHandler(this.CubeTimerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CubeTimerForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CubeTimerForm_KeyUp);
            this.panelTimer.ResumeLayout(false);
            this.panelTimer.PerformLayout();
            this.panelCube.ResumeLayout(false);
            this.panelDown.ResumeLayout(false);
            this.panelBack.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelUp.ResumeLayout(false);
            this.panelFront.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelTimer;
        private System.Windows.Forms.Timer timerCube;
        private Panel panelTimer;
        private Label labelScramble;
        private Panel panelCube;
        private Panel panelLeft;
        private Panel panelUp;
        private Panel panelFront;
        private Panel panelDown;
        private Panel panelBack;
        private Panel panelRight;
        private Panel panelLeft8;
        private Panel panelLeft7;
        private Panel panelLeft6;
        private Panel panelLeft5;
        private Panel panelLeft4;
        private Panel panelLeft3;
        private Panel panelLeft2;
        private Panel panelLeft1;
        private Panel panelLeft0;
        private Panel panelDown8;
        private Panel panelDown0;
        private Panel panelDown7;
        private Panel panelDown1;
        private Panel panelDown6;
        private Panel panelDown2;
        private Panel panelDown5;
        private Panel panelDown3;
        private Panel panelDown4;
        private Panel panelBack8;
        private Panel panelBack0;
        private Panel panelBack7;
        private Panel panelBack1;
        private Panel panelBack6;
        private Panel panelBack2;
        private Panel panelBack5;
        private Panel panelBack3;
        private Panel panelBack4;
        private Panel panelRight8;
        private Panel panelRight0;
        private Panel panelRight7;
        private Panel panelRight1;
        private Panel panelRight6;
        private Panel panelRight2;
        private Panel panelRight5;
        private Panel panelRight3;
        private Panel panelRight4;
        private Panel panelUp8;
        private Panel panelUp0;
        private Panel panelUp7;
        private Panel panelUp1;
        private Panel panelUp6;
        private Panel panelUp2;
        private Panel panelUp5;
        private Panel panelUp3;
        private Panel panelUp4;
        private Panel panelFront8;
        private Panel panelFront0;
        private Panel panelFront7;
        private Panel panelFront1;
        private Panel panelFront6;
        private Panel panelFront2;
        private Panel panelFront5;
        private Panel panelFront3;
        private Panel panelFront4;
        private Button buttonDownTurn;
        private Button buttonBackTurn;
        private Button buttonRightTurn;
        private Button buttonUpTurn;
        private Button buttonFrontTurn;
        private Button buttonLeftTurn;
        private FlowLayoutPanel flowLayoutPanelTimes;
        private Panel panelStats;
        private Label labelAverageOfOneHundred;
        private Label labelBestTime;
        private Label labelAverageOfTwelve;
        private Label labelAverageOfFive;
        private ComboBox comboBoxSession;
    }
}