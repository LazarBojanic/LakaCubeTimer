using WinterCubeTimer.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinterCubeTimer.forms {
    public partial class StatsForm : Form {
        private SolveTime solveTime { get; set; }
        public StatsForm(SolveTime solveTime) {
            InitializeComponent();
            this.solveTime = solveTime;
        }
        private void StatsForm_Load(object sender, EventArgs e) {
            labelSession.Text = "Session: " + solveTime.solveSession;
            labelTime.Text = "Time: " + solveTime.solveTime;
            textBoxScramble.Text = solveTime.solveScramble;
            labelDate.Text = "Date: " + solveTime.solveDate.ToString();
        }
    }
}