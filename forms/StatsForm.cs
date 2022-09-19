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
    public partial class StatsForm : Form {
        public Time time { get; set; }
        public StatsForm(Time time) {
            InitializeComponent();
            this.time = time;
        }
        private void StatsForm_Load(object sender, EventArgs e) {
            labelSession.Text = "Session: " + time.session;
            labelTime.Text = "Time: " + time.time;
            textBoxScramble.Text = time.scramble;
            labelDate.Text = "Date: " + time.date.ToString();
        }
    }
}