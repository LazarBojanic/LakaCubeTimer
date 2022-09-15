using LakaCubeTimer.model;
using LakaCubeTimer.util;
using System.Data.OleDb;
using System.Diagnostics;

namespace LakaCubeTimer {
    public partial class CubeTimerForm : Form {
        private int milliseconds = 0;
        private int seconds = 0;
        private int minutes = 0;
        private string secondsString;
        private string minutesString;
        private int timerState = 0;
        private List<string> scramble;
        Stopwatch stopwatch;
        public CubeTimerForm() {
            InitializeComponent();
            
            
        }
        private void CubeTimerForm_Load(object sender, EventArgs e) {
            scramble = Util.generateScramble();
            labelScramble.Text = Util.scrambleToString(scramble);
            Cube oldCube = new Cube();
            Cube newCube = Util.turnCube(oldCube, "U");
            MessageBox.Show(Util.cubeToString(newCube));
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
    }
}
