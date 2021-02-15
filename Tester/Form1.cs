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
    public partial class Form1 : Form
    {
        public List<GenerateTable> people { get; set; }
        public int CountLen; 
        public Form1()
        {
            people = GetPeople(CountLen);
            InitializeComponent();
        }
        private List<GenerateTable> GetPeople(int Count) 
        {
            var list = new List<GenerateTable>();
            for (int i = 0; i<Count; i++) 
            {
                list.Add(new GenerateTable() { });
            }
            return list;
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
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                var people = this.people;
                dataGridView1.DataSource = people;
                int countLen = System.IO.File.ReadAllLines(opf.FileName).Length;
                MessageBox.Show(countLen.ToString());
            }
        }
    }
}
