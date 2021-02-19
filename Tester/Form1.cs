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
using System.Diagnostics;

namespace Tester
{
    public partial class Form1 : Form
    {
        //названия столбцов и то, в каком порядке они будут распологаться в таблице
        List<string> columnsNames = new List<string> { "№", "Input", "Output", "Result", "Memory", "Time" };
        //путь к data
        string pathData = Directory.GetCurrentDirectory() + "/data";
        Button clickedButtonTheme;
        private void ProcGenTasks(string path) 
        {
            var dirs = Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            for (int i = 0; i < countElems; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle());
                tableLayoutPanel1.RowStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[i].Height = 51;
                Button but = new Button();
                but.Width = tableLayoutPanel1.Width - 50;
                but.Height = 50;
                but.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                but.Click += new EventHandler(this.GreetingBtnTasks_Click);
                tableLayoutPanel1.Controls.Add(but, 0, tableLayoutPanel1.GetRow(clickedButtonTheme)+1);

            }
        }
        private void ProcGenTable(string path)
        {
            int countLen = File.ReadAllLines(path + "/input.txt").Length;
            //генерирую таблицу
            GenerateTable.GenerataTable(countLen, columnsNames, dataGridView1);
            //изменяю данные таблицы считывая по очереди каждую строку из инпута
            StreamReader sr1 = new StreamReader(path + "/input.txt");
            Inform.pathInp = path + "/input.txt";
            for (int i = 0; i < countLen; i++)
            {
                GenerateTable.ReValue(i, 0, dataGridView1, (i + 1).ToString());
            }
            for (int i = 0; i < countLen; i++)
            {
                GenerateTable.ReValue(i, 1, dataGridView1, sr1.ReadLine());
            }
            sr1.Close(); //вырубаю чтение инпута
                         //изменяю данные таблицы считывая по очереди каждую строку из инпута
            StreamReader sr2 = new StreamReader(path + "/output.txt");
            Inform.pathOut = path + "/output.txt";
            for (int i = 0; i < countLen; i++)
            {
                GenerateTable.ReValue(i, 2, dataGridView1, sr2.ReadLine());
            }
            sr2.Close(); //вырубаю чтение аутпута
        }
        public Form1()
        {
            InitializeComponent();
        }
        void GreetingBtnTheme_Click(Object sender, EventArgs e)
        {
            clickedButtonTheme = (Button)sender;
            ProcGenTasks(pathData + "/" + clickedButtonTheme.Text);
        }
        void GreetingBtnTasks_Click(Object sender, EventArgs e)
        {
            Button clickedButtonTasks = (Button)sender;
            ProcGenTable(pathData + "/" + clickedButtonTheme.Text +"/"+clickedButtonTasks.Text);
        }
        private void добавитьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTest programm = new AddTest();
            programm.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm programm = new AboutProgramm();
            programm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void пройтиТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //привязываю к кнопке открытие окна в котором выбираем папку с инп и аут
            OpenFileDialog opf = new OpenFileDialog();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //тут задаём нужные колонки
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProcGenTasks(fbd.SelectedPath);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RefreshTree()
        {
            var dirs = Directory.GetDirectories(pathData, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i<countElems; i++) 
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle());
                tableLayoutPanel1.RowStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[i].Height = 51;
                Button but = new Button();
                but.Width = tableLayoutPanel1.Width-30;
                but.Height = 50;
                but.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\")+1);
                but.Click += new EventHandler(this.GreetingBtnTheme_Click);
                tableLayoutPanel1.Controls.Add(but, 0, i);
                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.HorizontalScroll.Maximum = 0;
            tableLayoutPanel1.AutoScroll = false;
            tableLayoutPanel1.HorizontalScroll.Enabled = false;
            tableLayoutPanel1.HorizontalScroll.Visible = false;
            tableLayoutPanel1.AutoScroll = true;
            RefreshTree();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start(pathData);
        }
    }
}
