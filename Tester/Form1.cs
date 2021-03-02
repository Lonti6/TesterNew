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
        string pathData = @"data\";
        string taskName;
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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void добавитьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTest programm = new AddTest();
            programm.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm programm = new AboutProgramm();
            programm.StartPosition = FormStartPosition.CenterScreen;
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
                /*ProcGenTasks(fbd.SelectedPath, clickedButtonTheme);*/
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void вExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTable.ExportToExcel(dataGridView1);
        }

        private void вWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTable.ExportToWord(dataGridView1);
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }
        private void RefreshTree()
        {
            flowLayoutPanel1.Controls.Clear();
            var dirs = Directory.GetDirectories(pathData, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < countElems; i++)
            {
                Button but = new Button();
                but.Width = flowLayoutPanel1.Width - 30;
                but.Height = 50;
                but.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                but.Click += ClickOnButTheme;
                but.Tag = false;
                but.BackColor = Color.FromArgb(117, 186, 156);
                but.FlatAppearance.BorderSize = 0;
                but.FlatStyle = FlatStyle.Flat;
                flowLayoutPanel1.Controls.Add(but);
            }
        }

        private void ClickOnButTheme(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var dirs = Directory.GetDirectories(pathData+"\\"+but.Text, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            if (but.Tag.ToString() == false.ToString())
            {
                for (int i = 0; i < countElems; i++)
                {
                    Button butDown = new Button();
                    butDown.Width = flowLayoutPanel1.Width - 50;
                    butDown.Height = 50;
                    butDown.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                    butDown.Click += ButTasksClick;
                    butDown.Name = "\\" + but.Text + "\\" + butDown.Text;
                    butDown.FlatAppearance.BorderSize = 0;
                    butDown.FlatStyle = FlatStyle.Flat;
                    butDown.BackColor = Color.FromArgb(134, 68, 179);
                    flowLayoutPanel1.Controls.Add(butDown);
                    flowLayoutPanel1.Controls.SetChildIndex(butDown, flowLayoutPanel1.Controls.GetChildIndex(but) + 1);
                }
                but.Tag = true;
            }
            else 
            {
                for (int i = 0; i < countElems; i++)
                {
                    flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.GetChildIndex(but) + 1);
                }
                but.Tag = false;
            }
        }

        private void ButTasksClick(object sender, EventArgs e)
        {
            var but = (Button)sender;
            taskName = pathData + but.Name;
            ProcGenTable(taskName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data");
            RefreshTree();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (opf.ShowDialog() == DialogResult.OK) 
            {
                //создаёшь экземпляр класса
                TestProject test = new TestProject();
                //метод возвращает List<string> с данными которые вывела прога. первое - путь на cs файл, второе путь к входным данным.
                List<string> outputPrgoram = test.test(opf.FileName, taskName + "\\input.txt");
                StreamReader trueOutput = new StreamReader(taskName + "/output.txt");
                string line = trueOutput.ReadLine();
                int i = 0;
                while (line != null)
                {
                    // тут сравниваешь line с строкой в List<string> и записываешь булевой куда тебе нужно
                    GenerateTable.ReValue(i, 3, dataGridView1, outputPrgoram[i]);
                    i++;
                    line = trueOutput.ReadLine();
                }
            }
            
        }
    }
}