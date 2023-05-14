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
            components = new System.ComponentModel.Container();
            labelTimer = new Label();
            timerSolve = new System.Windows.Forms.Timer(components);
            panelTimer = new Panel();
            buttonExportCubeState = new Button();
            checkBoxInspectionEnabled = new CheckBox();
            panelTurns = new Panel();
            buttonLeftTurn = new Button();
            buttonFrontTurn = new Button();
            buttonDownTurn = new Button();
            buttonUpTurn = new Button();
            buttonBackTurn = new Button();
            buttonRightTurn = new Button();
            buttonNewScramble = new Button();
            panelCube = new Panel();
            panelDown = new Panel();
            panelDown8 = new Panel();
            panelDown0 = new Panel();
            panelDown7 = new Panel();
            panelDown1 = new Panel();
            panelDown6 = new Panel();
            panelDown2 = new Panel();
            panelDown5 = new Panel();
            panelDown3 = new Panel();
            panelDown4 = new Panel();
            panelBack = new Panel();
            panelBack8 = new Panel();
            panelBack0 = new Panel();
            panelBack7 = new Panel();
            panelBack1 = new Panel();
            panelBack6 = new Panel();
            panelBack2 = new Panel();
            panelBack5 = new Panel();
            panelBack3 = new Panel();
            panelBack4 = new Panel();
            panelRight = new Panel();
            panelRight8 = new Panel();
            panelRight0 = new Panel();
            panelRight7 = new Panel();
            panelRight1 = new Panel();
            panelRight6 = new Panel();
            panelRight2 = new Panel();
            panelRight5 = new Panel();
            panelRight3 = new Panel();
            panelRight4 = new Panel();
            panelUp = new Panel();
            panelUp8 = new Panel();
            panelUp0 = new Panel();
            panelUp7 = new Panel();
            panelUp1 = new Panel();
            panelUp6 = new Panel();
            panelUp2 = new Panel();
            panelUp5 = new Panel();
            panelUp3 = new Panel();
            panelUp4 = new Panel();
            panelFront = new Panel();
            panelFront8 = new Panel();
            panelFront0 = new Panel();
            panelFront7 = new Panel();
            panelFront1 = new Panel();
            panelFront6 = new Panel();
            panelFront2 = new Panel();
            panelFront5 = new Panel();
            panelFront3 = new Panel();
            panelFront4 = new Panel();
            panelLeft = new Panel();
            panelLeft8 = new Panel();
            panelLeft7 = new Panel();
            panelLeft6 = new Panel();
            panelLeft5 = new Panel();
            panelLeft4 = new Panel();
            panelLeft3 = new Panel();
            panelLeft2 = new Panel();
            panelLeft1 = new Panel();
            panelLeft0 = new Panel();
            labelScramble = new Label();
            flowLayoutPanelTimes = new FlowLayoutPanel();
            panelStats = new Panel();
            labelBestTime = new Label();
            labelAverageOfTwelve = new Label();
            labelAverageOfFive = new Label();
            comboBoxSession = new ComboBox();
            buttonSelectSession = new Button();
            buttonDeleteAllFromSession = new Button();
            timerInspection = new System.Windows.Forms.Timer(components);
            buttonSolveCube = new Button();
            panelTimer.SuspendLayout();
            panelTurns.SuspendLayout();
            panelCube.SuspendLayout();
            panelDown.SuspendLayout();
            panelBack.SuspendLayout();
            panelRight.SuspendLayout();
            panelUp.SuspendLayout();
            panelFront.SuspendLayout();
            panelLeft.SuspendLayout();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // labelTimer
            // 
            labelTimer.Anchor = AnchorStyles.Top;
            labelTimer.AutoSize = true;
            labelTimer.Font = new Font("Century Gothic", 72F, FontStyle.Regular, GraphicsUnit.Point);
            labelTimer.Location = new Point(307, 210);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(527, 115);
            labelTimer.TabIndex = 0;
            labelTimer.Text = "00 : 00 . 00";
            labelTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerSolve
            // 
            timerSolve.Interval = 10;
            timerSolve.Tick += timerSolve_Tick;
            // 
            // panelTimer
            // 
            panelTimer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTimer.Controls.Add(buttonSolveCube);
            panelTimer.Controls.Add(buttonExportCubeState);
            panelTimer.Controls.Add(checkBoxInspectionEnabled);
            panelTimer.Controls.Add(panelTurns);
            panelTimer.Controls.Add(buttonNewScramble);
            panelTimer.Controls.Add(panelCube);
            panelTimer.Controls.Add(labelScramble);
            panelTimer.Controls.Add(labelTimer);
            panelTimer.Location = new Point(360, 12);
            panelTimer.Name = "panelTimer";
            panelTimer.Size = new Size(1141, 782);
            panelTimer.TabIndex = 2;
            // 
            // buttonExportCubeState
            // 
            buttonExportCubeState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportCubeState.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExportCubeState.Location = new Point(971, 91);
            buttonExportCubeState.Name = "buttonExportCubeState";
            buttonExportCubeState.Size = new Size(155, 70);
            buttonExportCubeState.TabIndex = 11;
            buttonExportCubeState.Text = "Export Cube State";
            buttonExportCubeState.UseVisualStyleBackColor = true;
            buttonExportCubeState.Click += buttonExportCubeState_Click;
            // 
            // checkBoxInspectionEnabled
            // 
            checkBoxInspectionEnabled.Appearance = Appearance.Button;
            checkBoxInspectionEnabled.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxInspectionEnabled.Location = new Point(15, 15);
            checkBoxInspectionEnabled.Name = "checkBoxInspectionEnabled";
            checkBoxInspectionEnabled.Size = new Size(163, 70);
            checkBoxInspectionEnabled.TabIndex = 10;
            checkBoxInspectionEnabled.Text = "Inspection On/Off";
            checkBoxInspectionEnabled.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxInspectionEnabled.UseVisualStyleBackColor = true;
            checkBoxInspectionEnabled.CheckedChanged += checkBoxInspectionEnabled_CheckedChanged;
            // 
            // panelTurns
            // 
            panelTurns.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelTurns.Controls.Add(buttonLeftTurn);
            panelTurns.Controls.Add(buttonFrontTurn);
            panelTurns.Controls.Add(buttonDownTurn);
            panelTurns.Controls.Add(buttonUpTurn);
            panelTurns.Controls.Add(buttonBackTurn);
            panelTurns.Controls.Add(buttonRightTurn);
            panelTurns.Location = new Point(3, 437);
            panelTurns.Name = "panelTurns";
            panelTurns.Size = new Size(456, 342);
            panelTurns.TabIndex = 9;
            // 
            // buttonLeftTurn
            // 
            buttonLeftTurn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLeftTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLeftTurn.Location = new Point(3, 117);
            buttonLeftTurn.Name = "buttonLeftTurn";
            buttonLeftTurn.Size = new Size(108, 108);
            buttonLeftTurn.TabIndex = 2;
            buttonLeftTurn.TabStop = false;
            buttonLeftTurn.Text = "Left";
            buttonLeftTurn.UseVisualStyleBackColor = true;
            buttonLeftTurn.MouseDown += buttonLeftTurn_MouseDown;
            // 
            // buttonFrontTurn
            // 
            buttonFrontTurn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFrontTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFrontTurn.Location = new Point(117, 117);
            buttonFrontTurn.Name = "buttonFrontTurn";
            buttonFrontTurn.Size = new Size(108, 108);
            buttonFrontTurn.TabIndex = 3;
            buttonFrontTurn.TabStop = false;
            buttonFrontTurn.Text = "Front";
            buttonFrontTurn.UseVisualStyleBackColor = true;
            buttonFrontTurn.MouseDown += buttonFrontTurn_MouseDown;
            // 
            // buttonDownTurn
            // 
            buttonDownTurn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDownTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDownTurn.Location = new Point(117, 231);
            buttonDownTurn.Name = "buttonDownTurn";
            buttonDownTurn.Size = new Size(108, 108);
            buttonDownTurn.TabIndex = 7;
            buttonDownTurn.TabStop = false;
            buttonDownTurn.Text = "Down";
            buttonDownTurn.UseVisualStyleBackColor = true;
            buttonDownTurn.MouseDown += buttonDownTurn_MouseDown;
            // 
            // buttonUpTurn
            // 
            buttonUpTurn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonUpTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUpTurn.Location = new Point(117, 3);
            buttonUpTurn.Name = "buttonUpTurn";
            buttonUpTurn.Size = new Size(108, 108);
            buttonUpTurn.TabIndex = 4;
            buttonUpTurn.TabStop = false;
            buttonUpTurn.Text = "Up";
            buttonUpTurn.UseVisualStyleBackColor = true;
            buttonUpTurn.MouseDown += buttonUpTurn_MouseDown;
            // 
            // buttonBackTurn
            // 
            buttonBackTurn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonBackTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBackTurn.Location = new Point(345, 117);
            buttonBackTurn.Name = "buttonBackTurn";
            buttonBackTurn.Size = new Size(108, 108);
            buttonBackTurn.TabIndex = 6;
            buttonBackTurn.TabStop = false;
            buttonBackTurn.Text = "Back";
            buttonBackTurn.UseVisualStyleBackColor = true;
            buttonBackTurn.MouseDown += buttonBackTurn_MouseDown;
            // 
            // buttonRightTurn
            // 
            buttonRightTurn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRightTurn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRightTurn.Location = new Point(231, 117);
            buttonRightTurn.Name = "buttonRightTurn";
            buttonRightTurn.Size = new Size(108, 108);
            buttonRightTurn.TabIndex = 5;
            buttonRightTurn.TabStop = false;
            buttonRightTurn.Text = "Right";
            buttonRightTurn.UseVisualStyleBackColor = true;
            buttonRightTurn.MouseDown += buttonRightTurn_MouseDown;
            // 
            // buttonNewScramble
            // 
            buttonNewScramble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonNewScramble.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewScramble.Location = new Point(971, 15);
            buttonNewScramble.Name = "buttonNewScramble";
            buttonNewScramble.Size = new Size(155, 70);
            buttonNewScramble.TabIndex = 8;
            buttonNewScramble.Text = "New Scramble";
            buttonNewScramble.UseVisualStyleBackColor = true;
            buttonNewScramble.MouseClick += buttonNewScramble_MouseClick;
            // 
            // panelCube
            // 
            panelCube.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelCube.Controls.Add(panelDown);
            panelCube.Controls.Add(panelBack);
            panelCube.Controls.Add(panelRight);
            panelCube.Controls.Add(panelUp);
            panelCube.Controls.Add(panelFront);
            panelCube.Controls.Add(panelLeft);
            panelCube.Location = new Point(682, 437);
            panelCube.Name = "panelCube";
            panelCube.Size = new Size(456, 342);
            panelCube.TabIndex = 1;
            // 
            // panelDown
            // 
            panelDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown.BackColor = Color.Black;
            panelDown.Controls.Add(panelDown8);
            panelDown.Controls.Add(panelDown0);
            panelDown.Controls.Add(panelDown7);
            panelDown.Controls.Add(panelDown1);
            panelDown.Controls.Add(panelDown6);
            panelDown.Controls.Add(panelDown2);
            panelDown.Controls.Add(panelDown5);
            panelDown.Controls.Add(panelDown3);
            panelDown.Controls.Add(panelDown4);
            panelDown.Location = new Point(117, 231);
            panelDown.Name = "panelDown";
            panelDown.Size = new Size(108, 108);
            panelDown.TabIndex = 1;
            // 
            // panelDown8
            // 
            panelDown8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown8.Location = new Point(75, 75);
            panelDown8.Name = "panelDown8";
            panelDown8.Size = new Size(30, 30);
            panelDown8.TabIndex = 8;
            // 
            // panelDown0
            // 
            panelDown0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown0.Location = new Point(3, 3);
            panelDown0.Name = "panelDown0";
            panelDown0.Size = new Size(30, 30);
            panelDown0.TabIndex = 0;
            // 
            // panelDown7
            // 
            panelDown7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown7.Location = new Point(39, 75);
            panelDown7.Name = "panelDown7";
            panelDown7.Size = new Size(30, 30);
            panelDown7.TabIndex = 7;
            // 
            // panelDown1
            // 
            panelDown1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown1.Location = new Point(39, 3);
            panelDown1.Name = "panelDown1";
            panelDown1.Size = new Size(30, 30);
            panelDown1.TabIndex = 1;
            // 
            // panelDown6
            // 
            panelDown6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown6.Location = new Point(3, 75);
            panelDown6.Name = "panelDown6";
            panelDown6.Size = new Size(30, 30);
            panelDown6.TabIndex = 6;
            // 
            // panelDown2
            // 
            panelDown2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown2.Location = new Point(75, 3);
            panelDown2.Name = "panelDown2";
            panelDown2.Size = new Size(30, 30);
            panelDown2.TabIndex = 2;
            // 
            // panelDown5
            // 
            panelDown5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown5.Location = new Point(75, 39);
            panelDown5.Name = "panelDown5";
            panelDown5.Size = new Size(30, 30);
            panelDown5.TabIndex = 5;
            // 
            // panelDown3
            // 
            panelDown3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown3.Location = new Point(3, 39);
            panelDown3.Name = "panelDown3";
            panelDown3.Size = new Size(30, 30);
            panelDown3.TabIndex = 3;
            // 
            // panelDown4
            // 
            panelDown4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDown4.Location = new Point(39, 39);
            panelDown4.Name = "panelDown4";
            panelDown4.Size = new Size(30, 30);
            panelDown4.TabIndex = 4;
            // 
            // panelBack
            // 
            panelBack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack.BackColor = Color.Black;
            panelBack.Controls.Add(panelBack8);
            panelBack.Controls.Add(panelBack0);
            panelBack.Controls.Add(panelBack7);
            panelBack.Controls.Add(panelBack1);
            panelBack.Controls.Add(panelBack6);
            panelBack.Controls.Add(panelBack2);
            panelBack.Controls.Add(panelBack5);
            panelBack.Controls.Add(panelBack3);
            panelBack.Controls.Add(panelBack4);
            panelBack.Location = new Point(345, 117);
            panelBack.Name = "panelBack";
            panelBack.Size = new Size(108, 108);
            panelBack.TabIndex = 5;
            // 
            // panelBack8
            // 
            panelBack8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack8.Location = new Point(75, 75);
            panelBack8.Name = "panelBack8";
            panelBack8.Size = new Size(30, 30);
            panelBack8.TabIndex = 8;
            // 
            // panelBack0
            // 
            panelBack0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack0.Location = new Point(3, 3);
            panelBack0.Name = "panelBack0";
            panelBack0.Size = new Size(30, 30);
            panelBack0.TabIndex = 0;
            // 
            // panelBack7
            // 
            panelBack7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack7.Location = new Point(39, 75);
            panelBack7.Name = "panelBack7";
            panelBack7.Size = new Size(30, 30);
            panelBack7.TabIndex = 7;
            // 
            // panelBack1
            // 
            panelBack1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack1.Location = new Point(39, 3);
            panelBack1.Name = "panelBack1";
            panelBack1.Size = new Size(30, 30);
            panelBack1.TabIndex = 1;
            // 
            // panelBack6
            // 
            panelBack6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack6.Location = new Point(3, 75);
            panelBack6.Name = "panelBack6";
            panelBack6.Size = new Size(30, 30);
            panelBack6.TabIndex = 6;
            // 
            // panelBack2
            // 
            panelBack2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack2.Location = new Point(75, 3);
            panelBack2.Name = "panelBack2";
            panelBack2.Size = new Size(30, 30);
            panelBack2.TabIndex = 2;
            // 
            // panelBack5
            // 
            panelBack5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack5.Location = new Point(75, 39);
            panelBack5.Name = "panelBack5";
            panelBack5.Size = new Size(30, 30);
            panelBack5.TabIndex = 5;
            // 
            // panelBack3
            // 
            panelBack3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack3.Location = new Point(3, 39);
            panelBack3.Name = "panelBack3";
            panelBack3.Size = new Size(30, 30);
            panelBack3.TabIndex = 3;
            // 
            // panelBack4
            // 
            panelBack4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBack4.Location = new Point(39, 39);
            panelBack4.Name = "panelBack4";
            panelBack4.Size = new Size(30, 30);
            panelBack4.TabIndex = 4;
            // 
            // panelRight
            // 
            panelRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight.BackColor = Color.Black;
            panelRight.Controls.Add(panelRight8);
            panelRight.Controls.Add(panelRight0);
            panelRight.Controls.Add(panelRight7);
            panelRight.Controls.Add(panelRight1);
            panelRight.Controls.Add(panelRight6);
            panelRight.Controls.Add(panelRight2);
            panelRight.Controls.Add(panelRight5);
            panelRight.Controls.Add(panelRight3);
            panelRight.Controls.Add(panelRight4);
            panelRight.Location = new Point(231, 117);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(108, 108);
            panelRight.TabIndex = 3;
            // 
            // panelRight8
            // 
            panelRight8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight8.Location = new Point(75, 75);
            panelRight8.Name = "panelRight8";
            panelRight8.Size = new Size(30, 30);
            panelRight8.TabIndex = 8;
            // 
            // panelRight0
            // 
            panelRight0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight0.Location = new Point(3, 3);
            panelRight0.Name = "panelRight0";
            panelRight0.Size = new Size(30, 30);
            panelRight0.TabIndex = 0;
            // 
            // panelRight7
            // 
            panelRight7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight7.Location = new Point(39, 75);
            panelRight7.Name = "panelRight7";
            panelRight7.Size = new Size(30, 30);
            panelRight7.TabIndex = 7;
            // 
            // panelRight1
            // 
            panelRight1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight1.Location = new Point(39, 3);
            panelRight1.Name = "panelRight1";
            panelRight1.Size = new Size(30, 30);
            panelRight1.TabIndex = 1;
            // 
            // panelRight6
            // 
            panelRight6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight6.Location = new Point(3, 75);
            panelRight6.Name = "panelRight6";
            panelRight6.Size = new Size(30, 30);
            panelRight6.TabIndex = 6;
            // 
            // panelRight2
            // 
            panelRight2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight2.Location = new Point(75, 3);
            panelRight2.Name = "panelRight2";
            panelRight2.Size = new Size(30, 30);
            panelRight2.TabIndex = 2;
            // 
            // panelRight5
            // 
            panelRight5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight5.Location = new Point(75, 39);
            panelRight5.Name = "panelRight5";
            panelRight5.Size = new Size(30, 30);
            panelRight5.TabIndex = 5;
            // 
            // panelRight3
            // 
            panelRight3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight3.Location = new Point(3, 39);
            panelRight3.Name = "panelRight3";
            panelRight3.Size = new Size(30, 30);
            panelRight3.TabIndex = 3;
            // 
            // panelRight4
            // 
            panelRight4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight4.Location = new Point(39, 39);
            panelRight4.Name = "panelRight4";
            panelRight4.Size = new Size(30, 30);
            panelRight4.TabIndex = 4;
            // 
            // panelUp
            // 
            panelUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp.BackColor = Color.Black;
            panelUp.Controls.Add(panelUp8);
            panelUp.Controls.Add(panelUp0);
            panelUp.Controls.Add(panelUp7);
            panelUp.Controls.Add(panelUp1);
            panelUp.Controls.Add(panelUp6);
            panelUp.Controls.Add(panelUp2);
            panelUp.Controls.Add(panelUp5);
            panelUp.Controls.Add(panelUp3);
            panelUp.Controls.Add(panelUp4);
            panelUp.Location = new Point(117, 3);
            panelUp.Name = "panelUp";
            panelUp.Size = new Size(108, 108);
            panelUp.TabIndex = 0;
            // 
            // panelUp8
            // 
            panelUp8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp8.Location = new Point(75, 75);
            panelUp8.Name = "panelUp8";
            panelUp8.Size = new Size(30, 30);
            panelUp8.TabIndex = 8;
            // 
            // panelUp0
            // 
            panelUp0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp0.Location = new Point(3, 3);
            panelUp0.Name = "panelUp0";
            panelUp0.Size = new Size(30, 30);
            panelUp0.TabIndex = 0;
            // 
            // panelUp7
            // 
            panelUp7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp7.Location = new Point(39, 75);
            panelUp7.Name = "panelUp7";
            panelUp7.Size = new Size(30, 30);
            panelUp7.TabIndex = 7;
            // 
            // panelUp1
            // 
            panelUp1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp1.Location = new Point(39, 3);
            panelUp1.Name = "panelUp1";
            panelUp1.Size = new Size(30, 30);
            panelUp1.TabIndex = 1;
            // 
            // panelUp6
            // 
            panelUp6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp6.Location = new Point(3, 75);
            panelUp6.Name = "panelUp6";
            panelUp6.Size = new Size(30, 30);
            panelUp6.TabIndex = 6;
            // 
            // panelUp2
            // 
            panelUp2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp2.Location = new Point(75, 3);
            panelUp2.Name = "panelUp2";
            panelUp2.Size = new Size(30, 30);
            panelUp2.TabIndex = 2;
            // 
            // panelUp5
            // 
            panelUp5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp5.Location = new Point(75, 39);
            panelUp5.Name = "panelUp5";
            panelUp5.Size = new Size(30, 30);
            panelUp5.TabIndex = 5;
            // 
            // panelUp3
            // 
            panelUp3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp3.Location = new Point(3, 39);
            panelUp3.Name = "panelUp3";
            panelUp3.Size = new Size(30, 30);
            panelUp3.TabIndex = 3;
            // 
            // panelUp4
            // 
            panelUp4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUp4.Location = new Point(39, 39);
            panelUp4.Name = "panelUp4";
            panelUp4.Size = new Size(30, 30);
            panelUp4.TabIndex = 4;
            // 
            // panelFront
            // 
            panelFront.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront.BackColor = Color.Black;
            panelFront.Controls.Add(panelFront8);
            panelFront.Controls.Add(panelFront0);
            panelFront.Controls.Add(panelFront7);
            panelFront.Controls.Add(panelFront1);
            panelFront.Controls.Add(panelFront6);
            panelFront.Controls.Add(panelFront2);
            panelFront.Controls.Add(panelFront5);
            panelFront.Controls.Add(panelFront3);
            panelFront.Controls.Add(panelFront4);
            panelFront.Location = new Point(117, 117);
            panelFront.Name = "panelFront";
            panelFront.Size = new Size(108, 108);
            panelFront.TabIndex = 4;
            // 
            // panelFront8
            // 
            panelFront8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront8.Location = new Point(75, 75);
            panelFront8.Name = "panelFront8";
            panelFront8.Size = new Size(30, 30);
            panelFront8.TabIndex = 8;
            // 
            // panelFront0
            // 
            panelFront0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront0.Location = new Point(3, 3);
            panelFront0.Name = "panelFront0";
            panelFront0.Size = new Size(30, 30);
            panelFront0.TabIndex = 0;
            // 
            // panelFront7
            // 
            panelFront7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront7.Location = new Point(39, 75);
            panelFront7.Name = "panelFront7";
            panelFront7.Size = new Size(30, 30);
            panelFront7.TabIndex = 7;
            // 
            // panelFront1
            // 
            panelFront1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront1.Location = new Point(39, 3);
            panelFront1.Name = "panelFront1";
            panelFront1.Size = new Size(30, 30);
            panelFront1.TabIndex = 1;
            // 
            // panelFront6
            // 
            panelFront6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront6.Location = new Point(3, 75);
            panelFront6.Name = "panelFront6";
            panelFront6.Size = new Size(30, 30);
            panelFront6.TabIndex = 6;
            // 
            // panelFront2
            // 
            panelFront2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront2.Location = new Point(75, 3);
            panelFront2.Name = "panelFront2";
            panelFront2.Size = new Size(30, 30);
            panelFront2.TabIndex = 2;
            // 
            // panelFront5
            // 
            panelFront5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront5.Location = new Point(75, 39);
            panelFront5.Name = "panelFront5";
            panelFront5.Size = new Size(30, 30);
            panelFront5.TabIndex = 5;
            // 
            // panelFront3
            // 
            panelFront3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront3.Location = new Point(3, 39);
            panelFront3.Name = "panelFront3";
            panelFront3.Size = new Size(30, 30);
            panelFront3.TabIndex = 3;
            // 
            // panelFront4
            // 
            panelFront4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFront4.Location = new Point(39, 39);
            panelFront4.Name = "panelFront4";
            panelFront4.Size = new Size(30, 30);
            panelFront4.TabIndex = 4;
            // 
            // panelLeft
            // 
            panelLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft.BackColor = Color.Black;
            panelLeft.Controls.Add(panelLeft8);
            panelLeft.Controls.Add(panelLeft7);
            panelLeft.Controls.Add(panelLeft6);
            panelLeft.Controls.Add(panelLeft5);
            panelLeft.Controls.Add(panelLeft4);
            panelLeft.Controls.Add(panelLeft3);
            panelLeft.Controls.Add(panelLeft2);
            panelLeft.Controls.Add(panelLeft1);
            panelLeft.Controls.Add(panelLeft0);
            panelLeft.Location = new Point(3, 117);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(108, 108);
            panelLeft.TabIndex = 2;
            // 
            // panelLeft8
            // 
            panelLeft8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft8.Location = new Point(75, 75);
            panelLeft8.Name = "panelLeft8";
            panelLeft8.Size = new Size(30, 30);
            panelLeft8.TabIndex = 8;
            // 
            // panelLeft7
            // 
            panelLeft7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft7.Location = new Point(39, 75);
            panelLeft7.Name = "panelLeft7";
            panelLeft7.Size = new Size(30, 30);
            panelLeft7.TabIndex = 7;
            // 
            // panelLeft6
            // 
            panelLeft6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft6.Location = new Point(3, 75);
            panelLeft6.Name = "panelLeft6";
            panelLeft6.Size = new Size(30, 30);
            panelLeft6.TabIndex = 6;
            // 
            // panelLeft5
            // 
            panelLeft5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft5.Location = new Point(75, 39);
            panelLeft5.Name = "panelLeft5";
            panelLeft5.Size = new Size(30, 30);
            panelLeft5.TabIndex = 5;
            // 
            // panelLeft4
            // 
            panelLeft4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft4.Location = new Point(39, 39);
            panelLeft4.Name = "panelLeft4";
            panelLeft4.Size = new Size(30, 30);
            panelLeft4.TabIndex = 4;
            // 
            // panelLeft3
            // 
            panelLeft3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft3.Location = new Point(3, 39);
            panelLeft3.Name = "panelLeft3";
            panelLeft3.Size = new Size(30, 30);
            panelLeft3.TabIndex = 3;
            // 
            // panelLeft2
            // 
            panelLeft2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft2.Location = new Point(75, 3);
            panelLeft2.Name = "panelLeft2";
            panelLeft2.Size = new Size(30, 30);
            panelLeft2.TabIndex = 2;
            // 
            // panelLeft1
            // 
            panelLeft1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft1.Location = new Point(39, 3);
            panelLeft1.Name = "panelLeft1";
            panelLeft1.Size = new Size(30, 30);
            panelLeft1.TabIndex = 1;
            // 
            // panelLeft0
            // 
            panelLeft0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLeft0.Location = new Point(3, 3);
            panelLeft0.Name = "panelLeft0";
            panelLeft0.Size = new Size(30, 30);
            panelLeft0.TabIndex = 0;
            // 
            // labelScramble
            // 
            labelScramble.Anchor = AnchorStyles.Top;
            labelScramble.AutoSize = true;
            labelScramble.Font = new Font("Century Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelScramble.Location = new Point(488, 123);
            labelScramble.Name = "labelScramble";
            labelScramble.Size = new Size(165, 39);
            labelScramble.TabIndex = 1;
            labelScramble.Text = "Scramble";
            labelScramble.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelTimes
            // 
            flowLayoutPanelTimes.AutoScroll = true;
            flowLayoutPanelTimes.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelTimes.Location = new Point(12, 12);
            flowLayoutPanelTimes.Name = "flowLayoutPanelTimes";
            flowLayoutPanelTimes.Size = new Size(342, 576);
            flowLayoutPanelTimes.TabIndex = 3;
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(labelBestTime);
            panelStats.Controls.Add(labelAverageOfTwelve);
            panelStats.Controls.Add(labelAverageOfFive);
            panelStats.Location = new Point(12, 671);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(342, 123);
            panelStats.TabIndex = 4;
            // 
            // labelBestTime
            // 
            labelBestTime.AutoSize = true;
            labelBestTime.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelBestTime.Location = new Point(15, 83);
            labelBestTime.Name = "labelBestTime";
            labelBestTime.Size = new Size(97, 22);
            labelBestTime.TabIndex = 2;
            labelBestTime.Text = "Best Time:";
            // 
            // labelAverageOfTwelve
            // 
            labelAverageOfTwelve.AutoSize = true;
            labelAverageOfTwelve.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelAverageOfTwelve.Location = new Point(15, 49);
            labelAverageOfTwelve.Name = "labelAverageOfTwelve";
            labelAverageOfTwelve.Size = new Size(64, 22);
            labelAverageOfTwelve.TabIndex = 1;
            labelAverageOfTwelve.Text = "Ao12:";
            // 
            // labelAverageOfFive
            // 
            labelAverageOfFive.AutoSize = true;
            labelAverageOfFive.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelAverageOfFive.Location = new Point(15, 15);
            labelAverageOfFive.Name = "labelAverageOfFive";
            labelAverageOfFive.Size = new Size(53, 22);
            labelAverageOfFive.TabIndex = 0;
            labelAverageOfFive.Text = "Ao5:";
            // 
            // comboBoxSession
            // 
            comboBoxSession.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSession.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSession.FormattingEnabled = true;
            comboBoxSession.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBoxSession.Location = new Point(12, 603);
            comboBoxSession.Name = "comboBoxSession";
            comboBoxSession.Size = new Size(80, 41);
            comboBoxSession.TabIndex = 5;
            comboBoxSession.TabStop = false;
            // 
            // buttonSelectSession
            // 
            buttonSelectSession.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSelectSession.Location = new Point(98, 594);
            buttonSelectSession.Name = "buttonSelectSession";
            buttonSelectSession.Size = new Size(89, 59);
            buttonSelectSession.TabIndex = 9;
            buttonSelectSession.TabStop = false;
            buttonSelectSession.Text = "Select";
            buttonSelectSession.UseVisualStyleBackColor = true;
            buttonSelectSession.MouseClick += buttonSelectSession_MouseClick;
            // 
            // buttonDeleteAllFromSession
            // 
            buttonDeleteAllFromSession.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDeleteAllFromSession.Location = new Point(193, 594);
            buttonDeleteAllFromSession.Name = "buttonDeleteAllFromSession";
            buttonDeleteAllFromSession.Size = new Size(161, 59);
            buttonDeleteAllFromSession.TabIndex = 10;
            buttonDeleteAllFromSession.TabStop = false;
            buttonDeleteAllFromSession.Text = "Delete All From Session";
            buttonDeleteAllFromSession.UseVisualStyleBackColor = true;
            buttonDeleteAllFromSession.MouseClick += buttonDeleteAllFromSession_MouseClick;
            // 
            // timerInspection
            // 
            timerInspection.Tick += timerInspection_Tick;
            // 
            // buttonSolveCube
            // 
            buttonSolveCube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSolveCube.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSolveCube.Location = new Point(971, 167);
            buttonSolveCube.Name = "buttonSolveCube";
            buttonSolveCube.Size = new Size(155, 70);
            buttonSolveCube.TabIndex = 12;
            buttonSolveCube.Text = "Solve Cube";
            buttonSolveCube.UseVisualStyleBackColor = true;
            buttonSolveCube.Click += buttonSolveCube_Click;
            // 
            // CubeTimerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1513, 806);
            Controls.Add(buttonDeleteAllFromSession);
            Controls.Add(buttonSelectSession);
            Controls.Add(comboBoxSession);
            Controls.Add(panelStats);
            Controls.Add(flowLayoutPanelTimes);
            Controls.Add(panelTimer);
            KeyPreview = true;
            MinimumSize = new Size(1529, 845);
            Name = "CubeTimerForm";
            Text = "CubeTimerForm";
            FormClosing += CubeTimerForm_FormClosing;
            Load += CubeTimerForm_Load;
            KeyDown += CubeTimerForm_KeyDown;
            KeyUp += CubeTimerForm_KeyUp;
            panelTimer.ResumeLayout(false);
            panelTimer.PerformLayout();
            panelTurns.ResumeLayout(false);
            panelCube.ResumeLayout(false);
            panelDown.ResumeLayout(false);
            panelBack.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelUp.ResumeLayout(false);
            panelFront.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTimer;
        private System.Windows.Forms.Timer timerSolve;
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
        public FlowLayoutPanel flowLayoutPanelTimes;
        private Panel panelStats;
        private Label labelBestTime;
        private Label labelAverageOfTwelve;
        private Label labelAverageOfFive;
        private ComboBox comboBoxSession;
        private Button buttonNewScramble;
        private Button buttonSelectSession;
        private Panel panelTurns;
        private Button buttonDeleteAllFromSession;
        private CheckBox checkBoxInspectionEnabled;
        private System.Windows.Forms.Timer timerInspection;
        private Button buttonExportCubeState;
        private Button buttonSolveCube;
    }
}