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
        int count0 = 0;
        public AddTest()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //создание инпута/аутпута
            string dataDir = AppDomain.CurrentDomain.BaseDirectory+ "/data/"+textBox2.Text; ; //получаем текущую директорию
            Directory.CreateDirectory(dataDir);
            dataDir += "/" + textBox3.Text;
            Directory.CreateDirectory(dataDir);
            for (int i = 0; i<dataGridView1.Rows.Count-2; i++) 
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null) File.AppendAllText(dataDir + "/input.txt", dataGridView1.Rows[i].Cells[1].Value + "\n");
                else File.AppendAllText(dataDir + "/input.txt", "\n");
                if (dataGridView1.Rows[i].Cells[2].Value != null) File.AppendAllText(dataDir + "/output.txt", dataGridView1.Rows[i].Cells[2].Value + "\n");
                else File.AppendAllText(dataDir + "/output.txt", "\n");
            }
            if (dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value != null) File.AppendAllText(dataDir + "/input.txt", dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value + "");
            else File.AppendAllText(dataDir + "/input.txt", "");
            if (dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value != null) File.AppendAllText(dataDir + "/output.txt", dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value + "");
            else File.AppendAllText(dataDir + "/output.txt", "");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddTest_Load(object sender, EventArgs e)
        {
            string[] names = new string[] { "№", "Input", "Output" };
            dataGridView1.RowHeadersVisible = false;

            var column0 = new DataGridViewTextBoxColumn();
            column0.Width = 30;
            column0.HeaderText = names[0];
            dataGridView1.Columns.Add(column0);

            for (int i =1; i<names.Length; i++) 
            {
                dataGridView1.RowHeadersVisible = false;
                var column = new DataGridViewTextBoxColumn();
                column.Width = 136;
                column.HeaderText = names[i];
                dataGridView1.Columns.Add(column);
            }
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            count0++;
            dataGridView1.Rows[count0-1].Cells[0].Value = count0;
            
        }
    }
}
