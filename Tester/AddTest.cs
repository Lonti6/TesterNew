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
            string dataDir = @"data\"+textBox2.Text; ; //получаем текущую директорию                
            Directory.CreateDirectory(dataDir);
            dataDir += "\\" + textBox3.Text;
            Directory.CreateDirectory(dataDir);
            int countFiles = new DirectoryInfo(dataDir).GetFiles().Length;
            if (countFiles==0) 
            {
                //создание инпута/аутпута
                File.AppendAllText(dataDir + "\\input.txt", dataGridView1.Rows[0].Cells[1].Value + "");
                File.AppendAllText(dataDir + "\\output.txt", dataGridView1.Rows[0].Cells[2].Value + "");
                for (int i = 1; i< dataGridView1.Rows.Count - 1 ; i++) 
                {
                    File.AppendAllText(dataDir + "\\input.txt", "\n" + dataGridView1.Rows[i].Cells[1].Value);
                    File.AppendAllText(dataDir + "\\output.txt", "\n" + dataGridView1.Rows[i].Cells[2].Value);
                }
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("ПЕРЕЗАПИСАТЬ?", "Перезапись", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.WriteAllText(dataDir + "\\input.txt", dataGridView1.Rows[0].Cells[1].Value + "");
                    File.WriteAllText(dataDir + "\\output.txt", dataGridView1.Rows[0].Cells[2].Value + "");
                    for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        File.AppendAllText(dataDir + "\\input.txt", "\n" + dataGridView1.Rows[i].Cells[1].Value);
                        File.AppendAllText(dataDir + "\\output.txt", "\n" + dataGridView1.Rows[i].Cells[2].Value);
                    }
                }
            }
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
            button2.Font = new Font("Segoe UI Semibold", 7F);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
