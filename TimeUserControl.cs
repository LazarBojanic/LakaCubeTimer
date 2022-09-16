using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LakaCubeTimer {
    public partial class TimeUserControl : UserControl {
        public TimeUserControl(string time, DateTime dateTime) {
            InitializeComponent();
            labelTime.Text = time;
            labelDate.Text = dateTime.ToString();
        }
    }
}
