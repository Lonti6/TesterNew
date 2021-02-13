using System;
using System.IO;
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
        public List<TextBox> elemInp = new List<TextBox> { };
        public List<TextBox> elemOut = new List<TextBox> { };
        public void Gen(Panel panel, TextBox CountText, string type)
        {
            panel.Controls.Clear();
            int top = 10;
            int left = 10;
            int column = 0;
            for (int i = 0; i < int.Parse(CountText.Text); i++)
            {
                TextBox textBox = new TextBox();
                
                if (column == 0)
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = "0";
                    if (type == "inp") elemInp.Add(textBox);
                    else if (type == "out") elemOut.Add(textBox);
                    panel.Controls.Add(textBox);
                    column = 1;
                    left += textBox1.Width + 30;
                }
                else
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = "0";
                    if (type == "inp") elemInp.Add(textBox);
                    else if (type == "out") elemOut.Add(textBox);
                    panel.Controls.Add(textBox);
                    column = 0;
                    left = 10;
                    top += 10;
                }
                if (column == 0) top += textBox.Height + 5;
                Inform.count = elemInp.Count;
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
            Gen(PanelOne, textBox1, "inp");
            Gen(PanelTwo, textBox1, "out");
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
                    if (sender.Equals(textBox1)) 
                    {
                        Control[] cont = new Control[int.Parse(textBox1.Text)];
                        Gen(PanelOne, textBox1, "inp");
                        Gen(PanelTwo, textBox1, "out");
                    }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            string dirInp = AppDomain.CurrentDomain.BaseDirectory;
            dirInp += "/data/input.txt";
            for (int i = 0; i<Inform.count; i++) 
            {
                File.AppendAllText(dirInp, elemInp[i].Text+"\n");
            }

            string dirOut = AppDomain.CurrentDomain.BaseDirectory;
            dirOut += "/data/output.txt";
            for (int i = 0; i < Inform.count; i++)
            {
                File.AppendAllText(dirOut, elemOut[i].Text + "\n");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
