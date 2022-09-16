using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LakaCubeTimer.forms {
    public partial class TimeUserControl : UserControl {
        private int id { get; set; }
        private int session { get; set; }
        private string time { get; set; }
        private double timeInMilliseconds { get; set; }
        private DateTime date { get; set; }
        public TimeUserControl(int parId, int parSession, string parTime, double parTimeInMilliseconds, DateTime parDate) {
            InitializeComponent();
            this.id = parId;
            this.session = parSession;
            this.time = parTime;
            this.timeInMilliseconds = parTimeInMilliseconds;
            this.date = parDate;
        }
        private void TimeUserControl_Load(object sender, EventArgs e) {
            labelTime.Text = time;
            labelDate.Text = date.ToString();
        }
        private void TimeUserControl_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void TimeUserControl_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void TimeUserControl_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm();
            statsForm.ShowDialog();
        }
        private void labelTime_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void labelTime_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void labelTime_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm();
            statsForm.ShowDialog();
        }
        private void labelDate_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void labelDate_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void labelDate_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm();
            statsForm.ShowDialog();
        }
    }
}