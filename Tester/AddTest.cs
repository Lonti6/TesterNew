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
        public void Gen(Panel panel, TextBox CountText, string type) //генерирует текстовые поля на панели Pane, кол-во полей получаем из CountText
        {                                                       //type(либо "inp", либо "out"), с помощью него определяем в какой список в Inform засунуть генерируемое текстовое поле
            panel.Controls.Clear(); //очищаем от предыдущих полей
            int top = 10;    //изначальные координаты 1го текстового поля по отношению к родительскому объекту  
            int left = 10;
            int column = 0;
            for (int i = 0; i < int.Parse(CountText.Text); i++)
            {
                TextBox textBox = new TextBox(); //создаю текстовое поле
                //колонка 1
                if (column == 0)
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = "0";
                    if (type == "inp") Inform.elemInp.Add(textBox);            //задаю ему настройки, добовляю в список опред. список(в зависимости от типа) в Inform
                    else if (type == "out") Inform.elemOut.Add(textBox);       //и добавляю на панель
                    panel.Controls.Add(textBox);
                    column = 1;
                    left += textBox1.Width + 30;
                }
                //колонка 2
                else
                {
                    textBox.Left = left;
                    textBox.Top = top;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Text = "0";
                    if (type == "inp") Inform.elemInp.Add(textBox);
                    else if (type == "out") Inform.elemOut.Add(textBox);
                    panel.Controls.Add(textBox);
                    column = 0;
                    left = 10;
                    top += 10;
                }
                if (column == 0) top += textBox.Height + 5;
                Inform.count = Inform.elemInp.Count;
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
            //когда нажимается кнопка, происходит генерация
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
            //возможность генерации тест. полей не по нажатию кнопки, а по клику на Enter
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
            //создание инпута
            string dataDir = AppDomain.CurrentDomain.BaseDirectory+ "/data/"+textBox2.Text; ; //получаем текущую директорию
            Directory.CreateDirectory(dataDir);
            dataDir += "/" + textBox3.Text;
            Directory.CreateDirectory(dataDir);
            for (int i = 0; i<Inform.count; i++) 
            {
                File.AppendAllText(dataDir+"/input.txt", Inform.elemInp[i].Text+"\n");
            }
            //создание аутпута
            for (int i = 0; i < Inform.count; i++)
            {
                File.AppendAllText(dataDir+"/output.txt", Inform.elemOut[i].Text + "\n");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
