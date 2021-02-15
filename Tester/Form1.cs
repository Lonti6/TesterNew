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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //привязываю к кнопке открытие окна в котором выбираем папку с инп и аут
            OpenFileDialog opf = new OpenFileDialog();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //тут задаём нужные колонки
            List<string> columnsNames= new List<string> { "Input", "Output", "Result",  "Memory", "Time" };
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                string path = fbd.SelectedPath;
                int countLen = File.ReadAllLines(path+"/input.txt").Length;
                //генерирую таблицу
                GenerateTable.GenerataTable(countLen, columnsNames, dataGridView1);
                //изменяю данные таблицы считывая по очереди каждую строку из инпута
                StreamReader sr1 = new StreamReader(path + "/input.txt");
                for (int i = 0; i<countLen; i++) 
                {
                    GenerateTable.ReValue(i, 0, dataGridView1, sr1.ReadLine());
                }
                sr1.Close(); //вырубаю чтение инпута
                //изменяю данные таблицы считывая по очереди каждую строку из инпута
                StreamReader sr2 = new StreamReader(path + "/output.txt");
                for (int i = 0; i < countLen; i++)
                {
                    GenerateTable.ReValue(i, 1, dataGridView1, sr2.ReadLine());
                }
                sr2.Close(); //вырубаю чтение аутпута
            }
        }
    }
}
