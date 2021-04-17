using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        //названия столбцов и то, в каком порядке они будут распологаться в таблице
        List<string> columnsNames = new List<string> { "№", "Input", "Output", "Result", "Memory (Byte)", "Time (MiliSecond)" };
        //путь к data
        string pathData = Environment.CurrentDirectory + @"\data\";
        string taskName;
        Button prevButton = new Button();
        int countLen;
        List<string>[] outputPrgoram;
        private void ProcGenTable(string path, DataGridView dgv)
        {
            if (File.ReadAllLines(path + @"\input.txt").Length != File.ReadAllLines(path + @"\output.txt").Length)
            {
                MessageBox.Show("Кол-во входных и выходных данных теста не равно.");
                return;
            }
            countLen = File.ReadAllLines(path + @"\input.txt").Length;
            //генерируем таблицу
            GenerateTable.GenerataTable(countLen, columnsNames, dgv);

            StreamReader streamInput = new StreamReader(path + @"\input.txt");
            StreamReader streamOutput = new StreamReader(path + @"\output.txt");
            Inform.pathOut = path + @"\output.txt";
            Inform.pathInp = path + @"\input.txt";
            //записываем входные и выходные данные. А также заполняем поле с нумерацией теста
            for (int i = 0; i < countLen; i++)
            {
                dgv[0, i].Value = (i + 1).ToString();
                dgv[1, i].Value = streamInput.ReadLine();
                dgv[2, i].Value = streamOutput.ReadLine();
            }

            streamInput.Close(); //вырубаю чтение инпута
            streamOutput.Close(); //вырубаю чтение аутпута
        }
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            flowLayoutPanel1.Height = this.Height - 110;
            dataGridView1.Width = this.Width - 290;
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
            ExportTable.ExportToExcel(flowLayoutPanel2.Controls);
        }

        private void вWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTable.ExportToWord(flowLayoutPanel2.Controls);
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }
        private void RefreshTree()
        {
            flowLayoutPanel2.Controls.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            var dirs = Directory.GetDirectories(pathData, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            for (int i = 0; i < countElems; i++)
            {
                Button but = new Button();
                but.Width = flowLayoutPanel1.Width - 30;
                but.Height = 50;
                but.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                but.Click += ClickOnButTheme;
                but.Tag = false;
                but.BackColor = Properties.Settings.Default.ButThemeColor;
                but.ForeColor = Color.White;
                using (Graphics cg = this.CreateGraphics())
                {
                    SizeF size = cg.MeasureString("Aaaaaa aaaaaa aa aaaa aaaa", but.Font);
                    but.Padding = Padding.Empty;
                    but.Width = (int)size.Width;
                }
                but.FlatAppearance.BorderSize = 0;
                but.FlatStyle = FlatStyle.Flat;
                flowLayoutPanel1.Controls.Add(but);
            }
        }

        private void ClickOnButTheme(object sender, EventArgs e)
        {
            var but = (Button)sender;
            var dirs = Directory.GetDirectories(pathData + "\\" + but.Text, "*.*", SearchOption.TopDirectoryOnly);
            int countElems = dirs.Length;
            if (but.Tag.ToString() == false.ToString())
            {
                for (int i = 0; i < countElems; i++)
                {
                    Button butDown = new Button();
                    butDown.Height = 50;
                    butDown.Text = dirs[i].Substring(dirs[i].LastIndexOf("\\") + 1);
                    butDown.Click += ButTasksClick;
                    butDown.Tag = false;
                    butDown.Name = "\\" + but.Text + "\\" + butDown.Text;
                    butDown.FlatAppearance.BorderSize = 0;
                    butDown.FlatStyle = FlatStyle.Flat;
                    butDown.ForeColor = Color.White;
                    using (Graphics cg = this.CreateGraphics())
                    {
                        SizeF size = cg.MeasureString("Aaaaaa aaaaaa aa aaaa aaaa", butDown.Font);
                        butDown.Padding = Padding.Empty;
                        butDown.Width = (int)size.Width;
                    }
                    butDown.Width = flowLayoutPanel1.Width - 50;
                    butDown.BackColor = Properties.Settings.Default.ButTaskColor;
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
            flowLayoutPanel2.Controls.Clear();
            dataGridView1.Visible = true;
            if (!flowLayoutPanel2.Controls.Contains(dataGridView1)) flowLayoutPanel2.Controls.Clear();
            button2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            var but = (Button)sender;
            if (but.Tag.ToString() == false.ToString())
            {
                but.Tag = true;
                prevButton.Tag = false;
                but.BackColor = Properties.Settings.Default.PickButColor;
                prevButton.BackColor = Properties.Settings.Default.ButTaskColor;
                prevButton = but;
            }
            taskName = pathData + but.Name;
            ProcGenTable(taskName, dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Font = new Font("Segoe UI Semibold", 7F);
            button2.Font = new Font("Segoe UI Semibold", 7F);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/data");
            RefreshTree();
            байтыToolStripMenuItem.Checked = true;
            миллисекундыToolStripMenuItem.Checked = true;
            button1.BackColor = Properties.Settings.Default.DownButsColor;
            button2.BackColor = Properties.Settings.Default.DownButsColor;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            OpenFileDialog opf = new OpenFileDialog();
            opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            opf.Filter = "All files (*.*)|*.*|C# (*.cs)|*.cs|Python (*.py)|*.py|Java (*.java)|*.java";
            opf.Multiselect = true;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                dataGridView1.Visible = false;
                foreach (string file in opf.FileNames)
                {
                    DataGridView dgv = new DataGridView();
                    flowLayoutPanel2.ControlAdded += FlowLayoutPanel2_ControlAdded;
                    flowLayoutPanel2.Controls.Add(dgv);
                    Label lab = new Label();
                    lab.Text = file.Substring(file.LastIndexOf("\\") + 1);
                    lab.Font = new Font(lab.Font.FontFamily, 10, FontStyle.Bold);
                    flowLayoutPanel2.Controls.Add(lab);
                    flowLayoutPanel2.Controls[i].Margin = new Padding(0, 30, 0, 0);
                    i += 2;
                    GenerateTable.GenerataTable(countLen, columnsNames, dgv);
                    dgv.RowHeadersVisible = false;
                    dgv.AllowUserToAddRows = false;
                    dgv.Width = flowLayoutPanel2.Width - 20;
                    dgv.Height = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dataGridView1.ColumnHeadersHeight;
                    dgv.Tag = taskName.Substring(taskName.LastIndexOf('\\') + 1) + " Имя файла:" + file.Substring(file.LastIndexOf("\\") + 1);
                    ProcGenTable(taskName, dgv);
                    //создаёшь экземпляр класса
                    TestProject test = new TestProject(file, taskName + "\\input.txt", ref dgv);
                    //метод возвращает List<string> с данными которые вывела прога. первое - путь на cs файл, второе путь к входным данным.
                    test.start();
                    //label3.Text = "Правильно " + countTrue.ToString() + " из " + dgv.Rows.Count.ToString();
                    //countTrue = 0;
                }
            }
        }

        private void FlowLayoutPanel2_ControlAdded(object sender, ControlEventArgs e)
        {
            var flp = (FlowLayoutPanel)sender;
            flp.Controls.SetChildIndex(e.Control, 0);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void байтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w += 2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    байтыToolStripMenuItem.Checked = true;
                    килобайтыToolStripMenuItem.Checked = false;
                    мегабайтыToolStripMenuItem.Checked = false;
                    dgv.Columns[4].HeaderText = "Memoty (Byte)";
                    if (dgv.Rows[0].Cells[4].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 4, dgv, outputPrgoram[1][i]);
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void килобайтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w+=2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    байтыToolStripMenuItem.Checked = false;
                    килобайтыToolStripMenuItem.Checked = true;
                    мегабайтыToolStripMenuItem.Checked = false;
                    dgv.Columns[4].HeaderText = "Memoty (KB)";
                    if (dgv.Rows[0].Cells[4].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 4, dgv, (double.Parse(outputPrgoram[1][i]) / 1024).ToString());
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void мегабайтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w += 2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    байтыToolStripMenuItem.Checked = false;
                    килобайтыToolStripMenuItem.Checked = false;
                    мегабайтыToolStripMenuItem.Checked = true;
                    dgv.Columns[4].HeaderText = "Memoty (MB)";
                    if (dgv.Rows[0].Cells[4].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 4, dgv, (double.Parse(outputPrgoram[1][i]) / 1024 / 1024).ToString());
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void миллисекундыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w += 2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    миллисекундыToolStripMenuItem.Checked = true;
                    секундыToolStripMenuItem.Checked = false;
                    минутыToolStripMenuItem.Checked = false;
                    dgv.Columns[5].HeaderText = "Time(MiliSeconds)";
                    if (dgv.Rows[0].Cells[5].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 5, dgv, outputPrgoram[2][i]);
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void секундыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w += 2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    миллисекундыToolStripMenuItem.Checked = false;
                    секундыToolStripMenuItem.Checked = true;
                    минутыToolStripMenuItem.Checked = false;
                    dgv.Columns[5].HeaderText = "Time(Seconds)";
                    if (dgv.Rows[0].Cells[5].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 5, dgv, (double.Parse(outputPrgoram[2][i]) / 1000).ToString());
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void минутыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int w = 1; w < flowLayoutPanel2.Controls.Count; w += 2)
            {
                DataGridView dgv = (DataGridView)flowLayoutPanel2.Controls[w];
                if (dgv.Columns.Count > 0)
                {
                    миллисекундыToolStripMenuItem.Checked = false;
                    секундыToolStripMenuItem.Checked = false;
                    минутыToolStripMenuItem.Checked = true;
                    dgv.Columns[5].HeaderText = "Time(Minutes)";
                    if (dgv.Rows[0].Cells[5].Value != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            GenerateTable.ReValue(i, 5, dgv, (double.Parse(outputPrgoram[2][i]) / 1000 / 60).ToString());
                        }
                    }
                }
                else MessageBox.Show("Вначале выберите тест!");
            }
        }

        private void контрольЦветовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorsSettings programm = new ColorsSettings();
            programm.ShowDialog();
            button1.BackColor = Properties.Settings.Default.DownButsColor;
            button2.BackColor = Properties.Settings.Default.DownButsColor;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            flowLayoutPanel1.Height = form.Height - 110;
            dataGridView1.Width = form.Width - 290;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }
    }
}