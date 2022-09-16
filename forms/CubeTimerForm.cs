﻿using LakaCubeTimer.model;
using LakaCubeTimer.util;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace LakaCubeTimer {
    public partial class CubeTimerForm : Form {
        private int milliseconds = 0;
        private int seconds = 0;
        private int minutes = 0;
        private string secondsString = "";
        private string minutesString = "";
        private int timerState = 0;
        private List<string> scrambleList;
        private Cube initialCube;
        private Cube newCube;
        private Cube scrambledCube;
        Stopwatch stopwatch;
        public CubeTimerForm() {
            InitializeComponent();
            scrambleList = Util.generateScramble();
            initialCube = new Cube();
            scrambledCube = Util.scrambleCube(initialCube, scrambleList);
            newCube = initialCube;
        }
        private void CubeTimerForm_Load(object sender, EventArgs e) {
            labelScramble.Text = Util.scrambleToString(scrambleList);
            paintCube(scrambledCube);
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
                    scrambleList = Util.generateScramble();
                    labelScramble.Text = Util.scrambleToString(scrambleList);
                    scrambledCube = Util.scrambleCube(initialCube, scrambleList);
                    paintCube(scrambledCube);
                }
            }
        }
        private void CubeTimerForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                if (timerState == 1) {
                    labelTimer.ForeColor = Control.DefaultForeColor;
                    timerState = 2;
                    milliseconds = 0;
                    seconds = 0;
                    minutes = 0;
                    stopwatch = new Stopwatch();
                    startTimer();
                    timerCube.Start();
                }
            }
        }
        public void saveToDatabase(Time timeResult) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "INSERT INTO [time] ([time], [date]) VALUES (@time, @date)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@time", timeResult.time);
            command.Parameters.Add("@date", OleDbType.DBTimeStamp).Value = Util.dateTimeWithoutMilliseconds(timeResult.date);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public string timerToString(long elapsedMilliseconds) {
            milliseconds = (int)elapsedMilliseconds % 1000 / 10;
            seconds = (int)(elapsedMilliseconds / 1000) % 60;
            minutes = (int)(elapsedMilliseconds / (1000 * 60) % 60);
            if (seconds < 10) {
                secondsString = "0" + seconds;
                ;
            }
            else {
                secondsString = seconds.ToString();
            }
            if (minutes < 10) {
                minutesString = "0" + minutes;
            }
            else {
                minutesString = minutes.ToString();
            }

            return minutesString + " : " + secondsString + " . " + milliseconds;
        }
        public void startTimer() {
            stopwatch.Start();
        }
        public void stopTimer() {
            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            labelTimer.Text = timerToString(elapsedMilliseconds);
            Time time = new Time(0, timerToString(elapsedMilliseconds), DateTime.Now);
            saveToDatabase(time);
        }

        private void timerCube_Tick(object sender, EventArgs e) {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            labelTimer.Text = timerToString(elapsedMilliseconds);
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
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
        private void buttonDownTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "D";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "D'";
            }
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
        private void buttonLeftTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "L";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "L'";
            }
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
        private void buttonRightTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "R";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "R'";
            }
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
        private void buttonFrontTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "F";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "F'";
            }
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
        private void buttonBackTurn_MouseDown(object sender, MouseEventArgs e) {
            string turn = "";
            if (e.Button == MouseButtons.Left) {
                turn = "B";
            }
            if (e.Button == MouseButtons.Right) {
                turn = "B'";
            }
            newCube = Util.turnCube(newCube, turn);
            paintCube(newCube);
        }
    }
}