using LakaCubeTimer.forms;
using LakaCubeTimer.model;
using LakaCubeTimer.util;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace LakaCubeTimer {
    public partial class CubeTimerForm : Form {
        public enum TimerStates {
            IDLE,
            INSPECTION,
            SOLVING,
            STOPPED
        }
        private static bool isPlusTwoInInspection = false;
        private static bool inspectionEnabled = true;
        private int currentSession = 1;
        private TimerStates timerState = TimerStates.IDLE;
        private List<string> scramble;
        private Cube initialCube;
        private Cube cubeToTurn;
        private Cube scrambledCube;
        private List<SolveTimeUserControl> listOfTimes;
        private static Stopwatch solveStopwatch;
        private static Stopwatch inspectionStopwatch;
        private static string bestTime { get; set; }
        private static string averageOfFive { get; set; }
        private static string averageOfTwelve { get; set; }
        public CubeTimerForm() {
            InitializeComponent();
        }
        private void CubeTimerForm_Load(object sender, EventArgs e) {
            checkBoxInspectionEnabled.Checked = Properties.Settings.Default.inspectionEnabled;
            inspectionEnabled = Properties.Settings.Default.inspectionEnabled;
            comboBoxSession.SelectedIndex = 0;
            fillTimesPanel(currentSession);
            displayScramble();
            updateStats(currentSession);
            displayStats();
        }
        public void updateStats(int session) {
            if (SqlUtil.getNumberOfSolvesForAverage(session) >= 1) {
                bestTime = "Best Time: " + SqlUtil.getBestTime(session);
            }
            else {
                bestTime = "Best Time:";
            }
            if (SqlUtil.getNumberOfSolvesForAverage(session) >= 5 && Util.calculateAverage(SqlUtil.timesToCalculate(5, session)) != 0) {
                averageOfFive = "Ao5: " + Util.longMillisecondsToString(Util.calculateAverage(SqlUtil.timesToCalculate(5, session)));
            }
            else {
                averageOfFive = "Ao5:";
            }
            if (SqlUtil.getNumberOfSolvesForAverage(session) >= 12 && Util.calculateAverage(SqlUtil.timesToCalculate(12, session)) != 0) {
                averageOfTwelve = "Ao12: " + Util.longMillisecondsToString(Util.calculateAverage(SqlUtil.timesToCalculate(12, session)));
            }
            else {
                averageOfTwelve = "Ao12:";
            }
        }
        public void displayStats() {
            labelBestTime.Text = bestTime;
            labelAverageOfFive.Text = averageOfFive;
            labelAverageOfTwelve.Text = averageOfTwelve;
        }
        private void CubeTimerForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                if (inspectionEnabled) {
                    if (timerState == TimerStates.IDLE) {
                        labelTimer.ForeColor = Color.MediumVioletRed;
                    }
                    else if (timerState == TimerStates.INSPECTION) {
                        labelTimer.ForeColor = Color.Lime;
                    }
                    else if (timerState == TimerStates.SOLVING) {
                        timerState = TimerStates.STOPPED;
                        endSolve(isPlusTwoInInspection, false);
                    }
                }
                else {
                    if (timerState == TimerStates.IDLE) {
                        labelTimer.ForeColor = Color.Lime;
                    }
                    else if (timerState == TimerStates.SOLVING) {
                        timerState = TimerStates.STOPPED;
                        endSolve(isPlusTwoInInspection, false);
                    }
                }
            }
        }
        private void CubeTimerForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                if (inspectionEnabled) {
                    if (timerState == TimerStates.STOPPED) {
                        timerState = TimerStates.IDLE;
                        return;
                    }
                    else if (timerState == TimerStates.IDLE) {
                        timerState = TimerStates.INSPECTION;
                        labelTimer.ForeColor = Control.DefaultForeColor;
                        beginInspection();
                    }
                    else if (timerState == TimerStates.INSPECTION) {
                        timerState = TimerStates.SOLVING;
                        labelTimer.ForeColor = Control.DefaultForeColor;
                        endInspection();
                        beginSolve();
                    }
                }
                else {
                    if (timerState == TimerStates.STOPPED) {
                        timerState = TimerStates.IDLE;
                        return;
                    }
                    else if (timerState == TimerStates.IDLE) {
                        timerState = TimerStates.SOLVING;
                        labelTimer.ForeColor = Control.DefaultForeColor;
                        beginSolve();
                    }
                }
            }
        }
        public void fillTimesPanel(int session) {
            listOfTimes = SqlUtil.fillTimes(session);
            foreach (SolveTimeUserControl solveTime in listOfTimes) {
                flowLayoutPanelTimes.Controls.Add(solveTime);
                solveTime.Left = (flowLayoutPanelTimes.Width - solveTime.Width) / 2;
            }
        }
        public void beginInspection() {
            inspectionStopwatch = new Stopwatch();
            inspectionStopwatch.Start();
            timerInspection.Start();
        }
        public void endInspection() {
            inspectionStopwatch.Stop();
            timerInspection.Stop();
        }
        public void beginSolve() {
            solveStopwatch = new Stopwatch();
            solveStopwatch.Start();
            timerSolve.Start();
        }
        public void endSolve(bool isPlusTwo, bool isDNF) {
            solveStopwatch.Stop();
            timerSolve.Stop();
            long elapsedMilliseconds = solveStopwatch.ElapsedMilliseconds;
            labelTimer.Text = Util.longMillisecondsToString(elapsedMilliseconds);
            SolveTime time = new SolveTime(0, currentSession, elapsedMilliseconds, elapsedMilliseconds,
                Util.longMillisecondsToString(elapsedMilliseconds), isPlusTwo, isDNF, Util.scrambleToString(scramble), DateTime.Now);
            SqlUtil.saveToDatabase(time);
            SolveTime latestTime = SqlUtil.getLatestAddedTime(time.solveSession);
            SolveTimeUserControl timeUserControl = new SolveTimeUserControl(latestTime);
            flowLayoutPanelTimes.Controls.Add(timeUserControl);
            updateStats(currentSession);
            displayScramble();
            displayStats();
        }
        private void timerSolve_Tick(object sender, EventArgs e) {
            long elapsedMilliseconds = solveStopwatch.ElapsedMilliseconds;
            labelTimer.Text = Util.longMillisecondsToString(elapsedMilliseconds);
            labelTimer.Left = (panelTimer.Width - labelTimer.Width) / 2;
        }
        private void timerInspection_Tick(object sender, EventArgs e) {
            long elapsedMilliseconds = inspectionStopwatch.ElapsedMilliseconds;
            labelTimer.Text = (elapsedMilliseconds / 1000).ToString();
            if (elapsedMilliseconds / 1000 >= 15) {
                isPlusTwoInInspection = true;
                labelTimer.Text += " (+2)";
            }
            if (elapsedMilliseconds / 1000 >= 17) {
                endInspection();
                endSolve(false, true);
                labelTimer.Text = "DNF";
                timerState = TimerStates.IDLE;
            }
            labelTimer.Left = (panelTimer.Width - labelTimer.Width) / 2;
            Thread.Sleep(150);
        }
        public void displayScramble() {
            scramble = Util.generateScramble();
            initialCube = new Cube();
            scrambledCube = Util.scrambleCube(initialCube, scramble);
            labelScramble.Text = Util.scrambleToString(scramble);
            labelScramble.Left = (panelTimer.Width - labelScramble.Width) / 2;
            paintCube(scrambledCube);
            cubeToTurn = scrambledCube;
        }
        public void paintCube(Cube cube) {
            foreach (Side side in cube.sides) {
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_UP)) {
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
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_DOWN)) {
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
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_LEFT)) {
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
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_RIGHT)) {
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
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_FRONT)) {
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
                if (side.stickers[4].colorNameAsSide.Equals(Util.SIDE_BACK)) {
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
            foreach (Process process in Process.GetProcessesByName("LakaCubeTimer")) {
                process.Kill();
            }
        }
        private void buttonSelectSession_MouseClick(object sender, MouseEventArgs e) {
            currentSession = Convert.ToInt32(comboBoxSession.Text);
            flowLayoutPanelTimes.Controls.Clear();
            fillTimesPanel(currentSession);
            updateStats(currentSession);
            displayStats();
        }
        private void buttonNewScramble_MouseClick(object sender, MouseEventArgs e) {
            displayScramble();
        }
        private void buttonDeleteAllFromSession_MouseClick(object sender, MouseEventArgs e) {
            flowLayoutPanelTimes.Controls.Clear();
            SqlUtil.deleteAllFromSession(currentSession);
            updateStats(currentSession);
            displayStats();
        }
        private void checkBoxInspectionEnabled_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxInspectionEnabled.Checked) {
                Properties.Settings.Default.inspectionEnabled = true;

                inspectionEnabled = Properties.Settings.Default.inspectionEnabled;
            }
            else {
                Properties.Settings.Default.PropertyValues["inspectionEnabled"].PropertyValue = false;
                inspectionEnabled = Properties.Settings.Default.inspectionEnabled;
            }
            Properties.Settings.Default.Save();
        }

        private void buttonExportCubeState_Click(object sender, EventArgs e) {
            CubeState cubeState = new CubeState(Util.scrambleToString(scramble), cubeToTurn.sides);
            string cubeStateJson = Serializer.serialize(cubeState);
            File.WriteAllText("cubeState.json", cubeStateJson);
        }
    }
}