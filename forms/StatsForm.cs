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
            labelId.Text = time.id.ToString();
            labelSession.Text = time.session.ToString();
            labelTime.Text = time.time.ToString();
            labelTimeInMilliseconds.Text = time.timeInMilliseconds.ToString();
            labelIsPlusTwo.Text = time.isPlusTwo.ToString();
            labelIsDNF.Text = time.isDNF.ToString();
            labelScramble.Text = time.scramble.ToString();
            labelDate.Text = time.date.ToString();
        }
    }
}