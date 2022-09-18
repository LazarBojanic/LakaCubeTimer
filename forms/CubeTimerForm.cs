using LakaCubeTimer.forms;
using LakaCubeTimer.model;
using LakaCubeTimer.util;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace LakaCubeTimer {
    public partial class CubeTimerForm : Form {
        private int currentSession = 1;
        private int timerState = 0;
        private List<string> initialScramble;
        private List<string> validatedScramble;
        private Cube initialCube;
        private Cube cubeToTurn;
        private Cube scrambledCube;
        private List<TimeUserControl> listOfTimes;
        private static Stopwatch stopwatch;
        public CubeTimerForm() {
            InitializeComponent();
        }
        private void CubeTimerForm_Load(object sender, EventArgs e) {
            comboBoxSession.SelectedIndex = 0;
            fillTimesPanel(currentSession);
            displayStats();
            displayScramble();
            cubeToTurn = scrambledCube;
        }
        private void CubeTimerForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                if (timerState == 0) {
                    labelTimer.ForeColor = Color.Lime;
                    timerState = 1;
                }
                if (timerState == 2) {
                    timerState = 0;
                    stopTimer();
                    timerCube.Stop();
                    displayScramble();
                }
            }
        }
        private void CubeTimerForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                if (timerState == 1) {
                    labelTimer.ForeColor = Control.DefaultForeColor;
                    timerState = 2;
                    labelTimer.Text = "00 : 00 . 00";
                    stopwatch = new Stopwatch();
                    startTimer();
                    timerCube.Start();
                }
            }
        }
        public void fillTimesPanel(int session) {
            listOfTimes = SqlUtil.fillTimes(session);
            foreach (TimeUserControl time in listOfTimes) {
                flowLayoutPanelTimes.Controls.Add(time);
            }
        }
        public void startTimer() {
            stopwatch.Start();
        }
        public void stopTimer() {
            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            labelTimer.Text = Util.longMillisecondsToString(elapsedMilliseconds);
            Time time = new Time(0, currentSession, elapsedMilliseconds, elapsedMilliseconds, Util.longMillisecondsToString(elapsedMilliseconds), false, false, labelScramble.Text, DateTime.Now);
            SqlUtil.saveToDatabase(time);
            Time latestTime = SqlUtil.getLatestAddedTime(time.session);
            TimeUserControl timeUserControl = new TimeUserControl(latestTime);
            flowLayoutPanelTimes.Controls.Add(timeUserControl);          
            displayStats();
        }
        private void timerCube_Tick(object sender, EventArgs e) {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            labelTimer.Text = Util.longMillisecondsToString(elapsedMilliseconds);
        }
        public void displayScramble() {
            initialScramble = Util.generateScramble();
            validatedScramble = Util.validateScramble(initialScramble);
            initialCube = new Cube();
            scrambledCube = Util.scrambleCube(initialCube, validatedScramble); 
            labelScramble.Text = Util.scrambleToString(validatedScramble);
            labelScramble.Left = (panelTimer.Width - labelScramble.Width) / 2;
            paintCube(scrambledCube);
        }
        public void displayStats() {
            if (flowLayoutPanelTimes.Controls.Count >= 1) {
                labelBestTime.Text = "Best Time: " + SqlUtil.getBestTime(currentSession);
            }
            else {
                labelBestTime.Text = "Best Time:";
                labelAverageOfFive.Text = "Ao5:";
                labelAverageOfTwelve.Text = "Ao12:";
            }
            if (flowLayoutPanelTimes.Controls.Count >= 5) {
                labelAverageOfFive.Text = "Ao5: " + Util.longMillisecondsToString(Util.calculateAverage(SqlUtil.timesToCalculate(5, currentSession)));
            }
            if (flowLayoutPanelTimes.Controls.Count >= 12) {
                labelAverageOfTwelve.Text = "Ao12: " + Util.longMillisecondsToString(Util.calculateAverage(SqlUtil.timesToCalculate(12, currentSession)));
            }
        }
        public void paintCube(Cube cube) {
            foreach (Side side in cube.sides) {
                if (side.stickers[4].color.Equals(Color.White)) {
                    panelUp.GetChildAtPoint(panelUp0.Location).BackColor = side.stickers[0].color;
                    panelUp.GetChildAtPoint(panelUp1.Location).BackColor = side.stickers[1].color;
                    panelUp.GetChildAtPoint(panelUp2.Location).BackColor = side.stickers[2].color;
                    panelUp.GetChildAtPoint(panelUp3.Location).BackColor = side.stickers[3].color;
                    panelUp.GetChildAtPoint(panelUp4.Location).BackColor = side.stickers[4].color;
                    panelUp.GetChildAtPoint(panelUp5.Location).BackColor = side.stickers[5].color;
                    panelUp.GetChildAtPoint(panelUp6.Location).BackColor = side.stickers[6].color;
                    panelUp.GetChildAtPoint(panelUp7.Location).BackColor = side.stickers[7].color;
                    panelUp.GetChildAtPoint(panelUp8.Location).BackColor = side.stickers[8].color;
                }
                if (side.stickers[4].color.Equals(Color.Yellow)) {
                    panelDown.GetChildAtPoint(panelDown0.Location).BackColor = side.stickers[0].color;
                    panelDown.GetChildAtPoint(panelDown1.Location).BackColor = side.stickers[1].color;
                    panelDown.GetChildAtPoint(panelDown2.Location).BackColor = side.stickers[2].color;
                    panelDown.GetChildAtPoint(panelDown3.Location).BackColor = side.stickers[3].color;
                    panelDown.GetChildAtPoint(panelDown4.Location).BackColor = side.stickers[4].color;
                    panelDown.GetChildAtPoint(panelDown5.Location).BackColor = side.stickers[5].color;
                    panelDown.GetChildAtPoint(panelDown6.Location).BackColor = side.stickers[6].color;
                    panelDown.GetChildAtPoint(panelDown7.Location).BackColor = side.stickers[7].color;
                    panelDown.GetChildAtPoint(panelDown8.Location).BackColor = side.stickers[8].color;
                }
                if (side.stickers[4].color.Equals(Color.Orange)) {
                    panelLeft.GetChildAtPoint(panelLeft0.Location).BackColor = side.stickers[0].color;
                    panelLeft.GetChildAtPoint(panelLeft1.Location).BackColor = side.stickers[1].color;
                    panelLeft.GetChildAtPoint(panelLeft2.Location).BackColor = side.stickers[2].color;
                    panelLeft.GetChildAtPoint(panelLeft3.Location).BackColor = side.stickers[3].color;
                    panelLeft.GetChildAtPoint(panelLeft4.Location).BackColor = side.stickers[4].color;
                    panelLeft.GetChildAtPoint(panelLeft5.Location).BackColor = side.stickers[5].color;
                    panelLeft.GetChildAtPoint(panelLeft6.Location).BackColor = side.stickers[6].color;
                    panelLeft.GetChildAtPoint(panelLeft7.Location).BackColor = side.stickers[7].color;
                    panelLeft.GetChildAtPoint(panelLeft8.Location).BackColor = side.stickers[8].color;
                }
                if (side.stickers[4].color.Equals(Color.Red)) {
                    panelRight.GetChildAtPoint(panelRight0.Location).BackColor = side.stickers[0].color;
                    panelRight.GetChildAtPoint(panelRight1.Location).BackColor = side.stickers[1].color;
                    panelRight.GetChildAtPoint(panelRight2.Location).BackColor = side.stickers[2].color;
                    panelRight.GetChildAtPoint(panelRight3.Location).BackColor = side.stickers[3].color;
                    panelRight.GetChildAtPoint(panelRight4.Location).BackColor = side.stickers[4].color;
                    panelRight.GetChildAtPoint(panelRight5.Location).BackColor = side.stickers[5].color;
                    panelRight.GetChildAtPoint(panelRight6.Location).BackColor = side.stickers[6].color;
                    panelRight.GetChildAtPoint(panelRight7.Location).BackColor = side.stickers[7].color;
                    panelRight.GetChildAtPoint(panelRight8.Location).BackColor = side.stickers[8].color;
                }
                if (side.stickers[4].color.Equals(Color.Green)) {
                    panelFront.GetChildAtPoint(panelFront0.Location).BackColor = side.stickers[0].color;
                    panelFront.GetChildAtPoint(panelFront1.Location).BackColor = side.stickers[1].color;
                    panelFront.GetChildAtPoint(panelFront2.Location).BackColor = side.stickers[2].color;
                    panelFront.GetChildAtPoint(panelFront3.Location).BackColor = side.stickers[3].color;
                    panelFront.GetChildAtPoint(panelFront4.Location).BackColor = side.stickers[4].color;
                    panelFront.GetChildAtPoint(panelFront5.Location).BackColor = side.stickers[5].color;
                    panelFront.GetChildAtPoint(panelFront6.Location).BackColor = side.stickers[6].color;
                    panelFront.GetChildAtPoint(panelFront7.Location).BackColor = side.stickers[7].color;
                    panelFront.GetChildAtPoint(panelFront8.Location).BackColor = side.stickers[8].color;
                }
                if (side.stickers[4].color.Equals(Color.Blue)) {
                    panelBack.GetChildAtPoint(panelBack0.Location).BackColor = side.stickers[0].color;
                    panelBack.GetChildAtPoint(panelBack1.Location).BackColor = side.stickers[1].color;
                    panelBack.GetChildAtPoint(panelBack2.Location).BackColor = side.stickers[2].color;
                    panelBack.GetChildAtPoint(panelBack3.Location).BackColor = side.stickers[3].color;
                    panelBack.GetChildAtPoint(panelBack4.Location).BackColor = side.stickers[4].color;
                    panelBack.GetChildAtPoint(panelBack5.Location).BackColor = side.stickers[5].color;
                    panelBack.GetChildAtPoint(panelBack6.Location).BackColor = side.stickers[6].color;
                    panelBack.GetChildAtPoint(panelBack7.Location).BackColor = side.stickers[7].color;
                    panelBack.GetChildAtPoint(panelBack8.Location).BackColor = side.stickers[8].color;
                }
            }
        }
        private void buttonUpTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "U";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "U'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void buttonDownTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "D";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "D'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void buttonLeftTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "L";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "L'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void buttonRightTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "R";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "R'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void buttonFrontTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "F";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "F'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void buttonBackTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "B";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "B'";
            }
            cubeToTurn = Util.turnCube(cubeToTurn, turn);
            paintCube(cubeToTurn);
        }
        private void CubeTimerForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
        private void buttonNewScramble_Click(object sender, EventArgs e) {
            displayScramble();
        }
        private void buttonSelectSession_MouseClick(object sender, MouseEventArgs e) {
            currentSession = Convert.ToInt32(comboBoxSession.Text);
            flowLayoutPanelTimes.Controls.Clear();
            fillTimesPanel(currentSession);
            displayStats();
        }
    }
}