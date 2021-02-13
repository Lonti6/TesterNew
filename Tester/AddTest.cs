using System;
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
    public partial class AddTest : Form
    {
        public void Gen(Panel panel, TextBox CountText)
        {
            panel.Controls.Clear();
            int top = 10;
            int left = 10;
            int column = 0;
            Control[] cont = new Control[int.Parse(CountText.Text)];
            for (int i = 0; i < int.Parse(CountText.Text); i++)
            {
                TextBox textBox = new TextBox();
                
                if (column == 0)
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    panel.Controls.Add(textBox);
                    cont.Append(textBox);
                    column = 1;
                    left += textBox1.Width + 30;
                }
                else
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    panel.Controls.Add(textBox);
                    cont.Append(textBox);
                    column = 0;
                    left = 10;
                    top += 10;
                }
                if (column == 0) top += textBox.Height + 5;
            }
        }
        public AddTest()
        {
            InitializeComponent();
        }

        private void PanelOne_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PanelTwo_Paint(object sender, PaintEventArgs e)
                {

                }
        private void button1_Click(object sender, EventArgs e)
        {
            Gen(PanelOne, textBox1);
            Gen(PanelTwo, textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '0')) return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1)) button1.Text = textBox1.Text;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelOne_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void PanelTwo_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
