﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class ColorsSettings : Form
    {
        public ColorsSettings()
        {
            InitializeComponent();
            colorDialog1.FullOpen = true;
        }

        private void ColorsSettings_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Properties.Settings.Default.FalseBGColor;
            pictureBox2.BackColor = Properties.Settings.Default.TrueBGColor;
            pictureBox3.BackColor = Properties.Settings.Default.ErrorBGColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.FalseBGColor = colorDialog1.Color;
            pictureBox1.BackColor = Properties.Settings.Default.FalseBGColor;
            Properties.Settings.Default.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.TrueBGColor = colorDialog1.Color;
            pictureBox1.BackColor = Properties.Settings.Default.TrueBGColor;
            Properties.Settings.Default.Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.ErrorBGColor = colorDialog1.Color;
            pictureBox1.BackColor = Properties.Settings.Default.ErrorBGColor;
            Properties.Settings.Default.Save();
        }
    }
}
