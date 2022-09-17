using LakaCubeTimer.model;
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
        public Time time { get; set; }
        public TimeUserControl(Time time) {
            InitializeComponent();
            this.time = time;
        }
        private void TimeUserControl_Load(object sender, EventArgs e) {
            labelTime.Text = time.time;
            labelDate.Text = time.date.ToString();
        }
        private void TimeUserControl_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void TimeUserControl_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void TimeUserControl_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm(time);
            statsForm.ShowDialog();
        }
        private void labelTime_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void labelTime_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void labelTime_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm(time);
            statsForm.ShowDialog();
        }
        private void labelDate_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }
        private void labelDate_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Control.DefaultBackColor;
        }
        private void labelDate_MouseClick(object sender, MouseEventArgs e) {
            StatsForm statsForm = new StatsForm(time);
            statsForm.ShowDialog();
        }
    }
}