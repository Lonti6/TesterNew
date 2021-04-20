namespace Tester
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьТестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортироватьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оЗУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.байтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.килобайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мегабайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.времяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.миллисекундыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.секундыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минутыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрольЦветовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(183)))), ((int)(((byte)(183)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.отображениеToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьТестToolStripMenuItem,
            this.экспортироватьТаблицуToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьТестToolStripMenuItem
            // 
            this.добавитьТестToolStripMenuItem.Name = "добавитьТестToolStripMenuItem";
            this.добавитьТестToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.добавитьТестToolStripMenuItem.Text = "Добавить тест";
            this.добавитьТестToolStripMenuItem.Click += new System.EventHandler(this.добавитьТестToolStripMenuItem_Click);
            // 
            // экспортироватьТаблицуToolStripMenuItem
            // 
            this.экспортироватьТаблицуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вWordToolStripMenuItem,
            this.вExcelToolStripMenuItem});
            this.экспортироватьТаблицуToolStripMenuItem.Name = "экспортироватьТаблицуToolStripMenuItem";
            this.экспортироватьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.экспортироватьТаблицуToolStripMenuItem.Text = "Экспортировать таблицу";
            // 
            // вWordToolStripMenuItem
            // 
            this.вWordToolStripMenuItem.Name = "вWordToolStripMenuItem";
            this.вWordToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.вWordToolStripMenuItem.Text = "В word";
            this.вWordToolStripMenuItem.Click += new System.EventHandler(this.вWordToolStripMenuItem_Click);
            // 
            // вExcelToolStripMenuItem
            // 
            this.вExcelToolStripMenuItem.Name = "вExcelToolStripMenuItem";
            this.вExcelToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.вExcelToolStripMenuItem.Text = "В excel";
            this.вExcelToolStripMenuItem.Click += new System.EventHandler(this.вExcelToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // отображениеToolStripMenuItem
            // 
            this.отображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оЗУToolStripMenuItem,
            this.времяToolStripMenuItem,
            this.контрольЦветовToolStripMenuItem});
            this.отображениеToolStripMenuItem.Name = "отображениеToolStripMenuItem";
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.отображениеToolStripMenuItem.Text = "Отображение";
            // 
            // оЗУToolStripMenuItem
            // 
            this.оЗУToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.байтыToolStripMenuItem,
            this.килобайтыToolStripMenuItem,
            this.мегабайтыToolStripMenuItem});
            this.оЗУToolStripMenuItem.Name = "оЗУToolStripMenuItem";
            this.оЗУToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.оЗУToolStripMenuItem.Text = "ОЗУ";
            // 
            // байтыToolStripMenuItem
            // 
            this.байтыToolStripMenuItem.Name = "байтыToolStripMenuItem";
            this.байтыToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.байтыToolStripMenuItem.Text = "Байты";
            this.байтыToolStripMenuItem.Click += new System.EventHandler(this.байтыToolStripMenuItem_Click);
            // 
            // килобайтыToolStripMenuItem
            // 
            this.килобайтыToolStripMenuItem.Name = "килобайтыToolStripMenuItem";
            this.килобайтыToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.килобайтыToolStripMenuItem.Text = "Килобайты";
            this.килобайтыToolStripMenuItem.Click += new System.EventHandler(this.килобайтыToolStripMenuItem_Click);
            // 
            // мегабайтыToolStripMenuItem
            // 
            this.мегабайтыToolStripMenuItem.Name = "мегабайтыToolStripMenuItem";
            this.мегабайтыToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.мегабайтыToolStripMenuItem.Text = "Мегабайты";
            this.мегабайтыToolStripMenuItem.Click += new System.EventHandler(this.мегабайтыToolStripMenuItem_Click);
            // 
            // времяToolStripMenuItem
            // 
            this.времяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.миллисекундыToolStripMenuItem,
            this.секундыToolStripMenuItem,
            this.минутыToolStripMenuItem});
            this.времяToolStripMenuItem.Name = "времяToolStripMenuItem";
            this.времяToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.времяToolStripMenuItem.Text = "Время";
            // 
            // миллисекундыToolStripMenuItem
            // 
            this.миллисекундыToolStripMenuItem.Name = "миллисекундыToolStripMenuItem";
            this.миллисекундыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.миллисекундыToolStripMenuItem.Text = "Миллисекунды";
            this.миллисекундыToolStripMenuItem.Click += new System.EventHandler(this.миллисекундыToolStripMenuItem_Click);
            // 
            // секундыToolStripMenuItem
            // 
            this.секундыToolStripMenuItem.Name = "секундыToolStripMenuItem";
            this.секундыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.секундыToolStripMenuItem.Text = "Секунды";
            this.секундыToolStripMenuItem.Click += new System.EventHandler(this.секундыToolStripMenuItem_Click);
            // 
            // минутыToolStripMenuItem
            // 
            this.минутыToolStripMenuItem.Name = "минутыToolStripMenuItem";
            this.минутыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.минутыToolStripMenuItem.Text = "Минуты";
            this.минутыToolStripMenuItem.Click += new System.EventHandler(this.минутыToolStripMenuItem_Click);
            // 
            // контрольЦветовToolStripMenuItem
            // 
            this.контрольЦветовToolStripMenuItem.Name = "контрольЦветовToolStripMenuItem";
            this.контрольЦветовToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.контрольЦветовToolStripMenuItem.Text = "Контроль цветов";
            this.контрольЦветовToolStripMenuItem.Click += new System.EventHandler(this.контрольЦветовToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(204, 32);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(532, 358);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(32, 397);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть папку с тестами";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 32);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 358);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(662, 397);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Выбрать файл с кодом\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.Location = new System.Drawing.Point(580, 400);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox2.Location = new System.Drawing.Point(414, 400);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 401);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Макс. памяти:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 402);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Макс. времени:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 401);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Правильно 0 из 0";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::Tester.Properties.Resources.refresh;
            this.pictureBox1.Location = new System.Drawing.Point(9, 397);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(75, 19);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(19, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(204, 32);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(551, 362);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(813, 429);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(829, 468);
            this.MinimumSize = new System.Drawing.Size(829, 468);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автотестер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьТестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem экспортироватьТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вExcelToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem отображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оЗУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem байтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem килобайтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мегабайтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem миллисекундыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem секундыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минутыToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem контрольЦветовToolStripMenuItem;
    }
}

