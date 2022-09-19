﻿using LakaCubeTimer.model;
using LakaCubeTimer.util;
using OpenCvSharp.Dnn;
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
        private CubeTimerForm cubeTimerForm { get; set; }
        public TimeUserControl(Time time) {
            InitializeComponent();
            this.time = time;
            this.cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];          
        }
        private void TimeUserControl_Load(object sender, EventArgs e) {
            labelTime.Text = time.time;
            checkBoxIsPlusTwo.Checked = time.isPlusTwo;
            checkBoxIsDNF.Checked = time.isDNF;
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
        private void checkBoxIsPlusTwo_CheckedChanged(object sender, EventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            if (checkBoxIsPlusTwo.Checked) {
                time.isPlusTwo = true;
                time.timeInMilliseconds = time.initialTimeInMilliseconds + 2000;
                time.time = Util.longMillisecondsToString(time.timeInMilliseconds) + " (+2)"; 
                SqlUtil.updateIsPlusTwo(time);
                labelTime.Text = time.time;
                
            }
            else {
                time.isPlusTwo = false;
                time.timeInMilliseconds = time.initialTimeInMilliseconds;
                time.time = Util.longMillisecondsToString(time.timeInMilliseconds);
                SqlUtil.updateIsPlusTwo(time);
                labelTime.Text = time.time;
            }
            cubeTimerForm.updateStats(time.session);
            cubeTimerForm.displayStats();
        }
        private void checkBoxIsDNF_CheckedChanged(object sender, EventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            if (checkBoxIsDNF.Checked) {
                time.isDNF = true;
                SqlUtil.updateIsDNF(time);
            }
            else {
                time.isDNF = false;
                SqlUtil.updateIsDNF(time);
            }
        }

        private void buttonDelete_MouseClick(object sender, MouseEventArgs e) {
            cubeTimerForm = (CubeTimerForm)Application.OpenForms["CubeTimerForm"];
            SqlUtil.deleteTime(time.session, time.id);
            cubeTimerForm.flowLayoutPanelTimes.Controls.Remove(this);
        }
    }
}