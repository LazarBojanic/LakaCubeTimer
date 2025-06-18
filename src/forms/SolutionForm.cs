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
    public partial class SolutionForm : Form {
        private string solution { get; set; }
        public SolutionForm(string solution) {
            InitializeComponent();
            this.solution = solution;
        }

        private void SolutionForm_Load(object sender, EventArgs e) {
            textBoxSolution.Text = solution;
        }
    }
}
