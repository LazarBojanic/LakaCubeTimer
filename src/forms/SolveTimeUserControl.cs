using WinterCubeTimer.database;
using WinterCubeTimer.model;
using WinterCubeTimer.util;

namespace WinterCubeTimer.forms
{
    public partial class SolveTimeUserControl : UserControl {
        private SolveTime solveTime { get; set; }
        private CubeTimerForm cubeTimerForm { get; set; }
        public SolveTimeUserControl(SolveTime solveTime) {
            InitializeComponent();
            this.solveTime = solveTime;
            this.cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];          
        }
        private void TimeUserControl_Load(object sender, EventArgs e) {
            labelTime.Text = solveTime.solveTime;
            checkBoxIsPlusTwo.Checked = solveTime.isPlusTwo;
            checkBoxIsDNF.Checked = solveTime.isDNF;
        }
        private void TimeUserControl_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void TimeUserControl_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void TimeUserControl_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm(solveTime);
            statsForm.ShowDialog();
        }
        private void labelTime_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void labelTime_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void labelTime_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm(solveTime);
            statsForm.ShowDialog();
        }
        
        private void buttonDelete_MouseClick(object sender, MouseEventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            TimesRepository.deleteTime(solveTime.solveSession, solveTime.id);
            cubeTimerForm.flowLayoutPanelTimes.Controls.Remove(this);
            cubeTimerForm.updateStats(solveTime.solveSession);
            cubeTimerForm.displayStats();
        }

        private void checkBoxIsPlusTwo_MouseClick(object sender, MouseEventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            if (checkBoxIsPlusTwo.Checked) {
                solveTime.isPlusTwo = true;
                solveTime.solveTimeInMilliseconds = solveTime.solveInitialTimeInMilliseconds + 2000;
                solveTime.solveTime = Util.longMillisecondsToString(solveTime.solveTimeInMilliseconds) + " (+2)";
                TimesRepository.updateIsPlusTwo(solveTime);
                labelTime.Text = solveTime.solveTime;
            }
            else {
                solveTime.isPlusTwo = false;
                solveTime.solveTimeInMilliseconds = solveTime.solveInitialTimeInMilliseconds;
                solveTime.solveTime = Util.longMillisecondsToString(solveTime.solveTimeInMilliseconds);
                TimesRepository.updateIsPlusTwo(solveTime);
                labelTime.Text = solveTime.solveTime;
            }
            cubeTimerForm.updateStats(solveTime.solveSession);
            cubeTimerForm.displayStats();
        }

        private void checkBoxIsDNF_MouseClick(object sender, MouseEventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            if (checkBoxIsDNF.Checked) {
                solveTime.isDNF = true;
                TimesRepository.updateIsDNF(solveTime);
            }
            else {
                solveTime.isDNF = false;
                TimesRepository.updateIsDNF(solveTime);
            }
            cubeTimerForm.updateStats(solveTime.solveSession);
            cubeTimerForm.displayStats();
        }
    }
}