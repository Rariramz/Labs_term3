namespace lab1_Csharp
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
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.listView_content = new System.Windows.Forms.ListView();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox_Text = new System.Windows.Forms.RichTextBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_paste = new System.Windows.Forms.Button();
            this.textBox_copy = new System.Windows.Forms.TextBox();
            this.textBox_paste = new System.Windows.Forms.TextBox();
            this.button_OK_copy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_cut = new System.Windows.Forms.Button();
            this.button_OK_cut = new System.Windows.Forms.Button();
            this.button_paste1 = new System.Windows.Forms.Button();
            this.textBox_paste1 = new System.Windows.Forms.TextBox();
            this.textBox_cut = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_source_compress = new System.Windows.Forms.Button();
            this.button_OK_compress = new System.Windows.Forms.Button();
            this.button_target_compress = new System.Windows.Forms.Button();
            this.textBox_target_compress = new System.Windows.Forms.TextBox();
            this.textBox_source_compress = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_source_decompress = new System.Windows.Forms.Button();
            this.button_OK_decompress = new System.Windows.Forms.Button();
            this.button_target_decompress = new System.Windows.Forms.Button();
            this.textBox_target_decompress = new System.Windows.Forms.TextBox();
            this.textBox_source_decompress = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_OK_delete = new System.Windows.Forms.Button();
            this.textBox_delete = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK_create = new System.Windows.Forms.Button();
            this.button_folder = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_OK_save = new System.Windows.Forms.Button();
            this.textBox_name_save = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(69, 11);
            this.textBox_path.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(430, 20);
            this.textBox_path.TabIndex = 1;
            this.textBox_path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_path_KeyDown);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(503, 11);
            this.button_browse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(56, 19);
            this.button_browse.TabIndex = 2;
            this.button_browse.Text = "Go!";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(9, 11);
            this.button_back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(56, 19);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // listView_content
            // 
            this.listView_content.AutoArrange = false;
            this.listView_content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_content.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name,
            this.columnHeader_date,
            this.columnHeader_type,
            this.columnHeader_size});
            this.listView_content.FullRowSelect = true;
            this.listView_content.GridLines = true;
            this.listView_content.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_content.HideSelection = false;
            this.listView_content.Location = new System.Drawing.Point(9, 34);
            this.listView_content.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView_content.MaximumSize = new System.Drawing.Size(550, 500);
            this.listView_content.MinimumSize = new System.Drawing.Size(550, 82);
            this.listView_content.MultiSelect = false;
            this.listView_content.Name = "listView_content";
            this.listView_content.ShowGroups = false;
            this.listView_content.Size = new System.Drawing.Size(550, 197);
            this.listView_content.TabIndex = 4;
            this.listView_content.UseCompatibleStateImageBehavior = false;
            this.listView_content.View = System.Windows.Forms.View.Details;
            this.listView_content.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_content_KeyDown);
            this.listView_content.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_content_MouseDoubleClick_1);
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Name";
            this.columnHeader_name.Width = 200;
            // 
            // columnHeader_date
            // 
            this.columnHeader_date.Text = "Date";
            this.columnHeader_date.Width = 150;
            // 
            // columnHeader_type
            // 
            this.columnHeader_type.Text = "Type";
            this.columnHeader_type.Width = 100;
            // 
            // columnHeader_size
            // 
            this.columnHeader_size.Text = "Size";
            this.columnHeader_size.Width = 100;
            // 
            // richTextBox_Text
            // 
            this.richTextBox_Text.Location = new System.Drawing.Point(564, 11);
            this.richTextBox_Text.Name = "richTextBox_Text";
            this.richTextBox_Text.Size = new System.Drawing.Size(473, 611);
            this.richTextBox_Text.TabIndex = 5;
            this.richTextBox_Text.Text = "";
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(6, 19);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 6;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_paste
            // 
            this.button_paste.Location = new System.Drawing.Point(6, 48);
            this.button_paste.Name = "button_paste";
            this.button_paste.Size = new System.Drawing.Size(75, 23);
            this.button_paste.TabIndex = 7;
            this.button_paste.Text = "Paste";
            this.button_paste.UseVisualStyleBackColor = true;
            this.button_paste.Click += new System.EventHandler(this.button_paste_Click);
            // 
            // textBox_copy
            // 
            this.textBox_copy.Enabled = false;
            this.textBox_copy.Location = new System.Drawing.Point(87, 19);
            this.textBox_copy.Name = "textBox_copy";
            this.textBox_copy.Size = new System.Drawing.Size(177, 20);
            this.textBox_copy.TabIndex = 8;
            // 
            // textBox_paste
            // 
            this.textBox_paste.Enabled = false;
            this.textBox_paste.Location = new System.Drawing.Point(87, 48);
            this.textBox_paste.Name = "textBox_paste";
            this.textBox_paste.Size = new System.Drawing.Size(177, 20);
            this.textBox_paste.TabIndex = 9;
            // 
            // button_OK_copy
            // 
            this.button_OK_copy.Enabled = false;
            this.button_OK_copy.Location = new System.Drawing.Point(87, 74);
            this.button_OK_copy.Name = "button_OK_copy";
            this.button_OK_copy.Size = new System.Drawing.Size(100, 23);
            this.button_OK_copy.TabIndex = 10;
            this.button_OK_copy.Text = "OK";
            this.button_OK_copy.UseVisualStyleBackColor = true;
            this.button_OK_copy.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.button_copy);
            this.groupBox1.Controls.Add(this.button_OK_copy);
            this.groupBox1.Controls.Add(this.button_paste);
            this.groupBox1.Controls.Add(this.textBox_paste);
            this.groupBox1.Controls.Add(this.textBox_copy);
            this.groupBox1.Location = new System.Drawing.Point(9, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 107);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COPY";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.button_cut);
            this.groupBox2.Controls.Add(this.button_OK_cut);
            this.groupBox2.Controls.Add(this.button_paste1);
            this.groupBox2.Controls.Add(this.textBox_paste1);
            this.groupBox2.Controls.Add(this.textBox_cut);
            this.groupBox2.Location = new System.Drawing.Point(288, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 107);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CUT";
            // 
            // button_cut
            // 
            this.button_cut.Location = new System.Drawing.Point(6, 19);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new System.Drawing.Size(75, 23);
            this.button_cut.TabIndex = 6;
            this.button_cut.Text = "Cut";
            this.button_cut.UseVisualStyleBackColor = true;
            this.button_cut.Click += new System.EventHandler(this.button_cut_Click);
            // 
            // button_OK_cut
            // 
            this.button_OK_cut.Enabled = false;
            this.button_OK_cut.Location = new System.Drawing.Point(87, 74);
            this.button_OK_cut.Name = "button_OK_cut";
            this.button_OK_cut.Size = new System.Drawing.Size(100, 23);
            this.button_OK_cut.TabIndex = 10;
            this.button_OK_cut.Text = "OK";
            this.button_OK_cut.UseVisualStyleBackColor = true;
            this.button_OK_cut.Click += new System.EventHandler(this.button_OK_cut_Click);
            // 
            // button_paste1
            // 
            this.button_paste1.Location = new System.Drawing.Point(6, 48);
            this.button_paste1.Name = "button_paste1";
            this.button_paste1.Size = new System.Drawing.Size(75, 23);
            this.button_paste1.TabIndex = 7;
            this.button_paste1.Text = "Paste";
            this.button_paste1.UseVisualStyleBackColor = true;
            this.button_paste1.Click += new System.EventHandler(this.button_paste1_Click);
            // 
            // textBox_paste1
            // 
            this.textBox_paste1.Enabled = false;
            this.textBox_paste1.Location = new System.Drawing.Point(87, 48);
            this.textBox_paste1.Name = "textBox_paste1";
            this.textBox_paste1.Size = new System.Drawing.Size(177, 20);
            this.textBox_paste1.TabIndex = 9;
            // 
            // textBox_cut
            // 
            this.textBox_cut.Enabled = false;
            this.textBox_cut.Location = new System.Drawing.Point(87, 19);
            this.textBox_cut.Name = "textBox_cut";
            this.textBox_cut.Size = new System.Drawing.Size(177, 20);
            this.textBox_cut.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Controls.Add(this.button_source_compress);
            this.groupBox3.Controls.Add(this.button_OK_compress);
            this.groupBox3.Controls.Add(this.button_target_compress);
            this.groupBox3.Controls.Add(this.textBox_target_compress);
            this.groupBox3.Controls.Add(this.textBox_source_compress);
            this.groupBox3.Location = new System.Drawing.Point(9, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 107);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "COMPRESS";
            // 
            // button_source_compress
            // 
            this.button_source_compress.Location = new System.Drawing.Point(6, 19);
            this.button_source_compress.Name = "button_source_compress";
            this.button_source_compress.Size = new System.Drawing.Size(75, 23);
            this.button_source_compress.TabIndex = 6;
            this.button_source_compress.Text = "Source File";
            this.button_source_compress.UseVisualStyleBackColor = true;
            this.button_source_compress.Click += new System.EventHandler(this.button_source_ZIP_Click);
            // 
            // button_OK_compress
            // 
            this.button_OK_compress.Enabled = false;
            this.button_OK_compress.Location = new System.Drawing.Point(87, 74);
            this.button_OK_compress.Name = "button_OK_compress";
            this.button_OK_compress.Size = new System.Drawing.Size(100, 23);
            this.button_OK_compress.TabIndex = 10;
            this.button_OK_compress.Text = "OK";
            this.button_OK_compress.UseVisualStyleBackColor = true;
            this.button_OK_compress.Click += new System.EventHandler(this.button_OK_ZIP_Click);
            // 
            // button_target_compress
            // 
            this.button_target_compress.Location = new System.Drawing.Point(6, 48);
            this.button_target_compress.Name = "button_target_compress";
            this.button_target_compress.Size = new System.Drawing.Size(75, 23);
            this.button_target_compress.TabIndex = 7;
            this.button_target_compress.Text = "Place";
            this.button_target_compress.UseVisualStyleBackColor = true;
            this.button_target_compress.Click += new System.EventHandler(this.button_target_ZIP_Click);
            // 
            // textBox_target_compress
            // 
            this.textBox_target_compress.Enabled = false;
            this.textBox_target_compress.Location = new System.Drawing.Point(87, 48);
            this.textBox_target_compress.Name = "textBox_target_compress";
            this.textBox_target_compress.Size = new System.Drawing.Size(177, 20);
            this.textBox_target_compress.TabIndex = 9;
            // 
            // textBox_source_compress
            // 
            this.textBox_source_compress.Enabled = false;
            this.textBox_source_compress.Location = new System.Drawing.Point(87, 19);
            this.textBox_source_compress.Name = "textBox_source_compress";
            this.textBox_source_compress.Size = new System.Drawing.Size(177, 20);
            this.textBox_source_compress.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.button_source_decompress);
            this.groupBox4.Controls.Add(this.button_OK_decompress);
            this.groupBox4.Controls.Add(this.button_target_decompress);
            this.groupBox4.Controls.Add(this.textBox_target_decompress);
            this.groupBox4.Controls.Add(this.textBox_source_decompress);
            this.groupBox4.Location = new System.Drawing.Point(288, 349);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(271, 107);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DECOMPRESS";
            // 
            // button_source_decompress
            // 
            this.button_source_decompress.Location = new System.Drawing.Point(6, 19);
            this.button_source_decompress.Name = "button_source_decompress";
            this.button_source_decompress.Size = new System.Drawing.Size(75, 23);
            this.button_source_decompress.TabIndex = 6;
            this.button_source_decompress.Text = "Source File";
            this.button_source_decompress.UseVisualStyleBackColor = true;
            this.button_source_decompress.Click += new System.EventHandler(this.button_source_decompress_Click);
            // 
            // button_OK_decompress
            // 
            this.button_OK_decompress.Enabled = false;
            this.button_OK_decompress.Location = new System.Drawing.Point(87, 74);
            this.button_OK_decompress.Name = "button_OK_decompress";
            this.button_OK_decompress.Size = new System.Drawing.Size(100, 23);
            this.button_OK_decompress.TabIndex = 10;
            this.button_OK_decompress.Text = "OK";
            this.button_OK_decompress.UseVisualStyleBackColor = true;
            this.button_OK_decompress.Click += new System.EventHandler(this.button_OK_decompress_Click);
            // 
            // button_target_decompress
            // 
            this.button_target_decompress.Location = new System.Drawing.Point(6, 48);
            this.button_target_decompress.Name = "button_target_decompress";
            this.button_target_decompress.Size = new System.Drawing.Size(75, 23);
            this.button_target_decompress.TabIndex = 7;
            this.button_target_decompress.Text = "Place";
            this.button_target_decompress.UseVisualStyleBackColor = true;
            this.button_target_decompress.Click += new System.EventHandler(this.button_target_decompress_Click);
            // 
            // textBox_target_decompress
            // 
            this.textBox_target_decompress.Enabled = false;
            this.textBox_target_decompress.Location = new System.Drawing.Point(87, 48);
            this.textBox_target_decompress.Name = "textBox_target_decompress";
            this.textBox_target_decompress.Size = new System.Drawing.Size(177, 20);
            this.textBox_target_decompress.TabIndex = 9;
            // 
            // textBox_source_decompress
            // 
            this.textBox_source_decompress.Enabled = false;
            this.textBox_source_decompress.Location = new System.Drawing.Point(87, 19);
            this.textBox_source_decompress.Name = "textBox_source_decompress";
            this.textBox_source_decompress.Size = new System.Drawing.Size(177, 20);
            this.textBox_source_decompress.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox5.Controls.Add(this.button_delete);
            this.groupBox5.Controls.Add(this.button_OK_delete);
            this.groupBox5.Controls.Add(this.textBox_delete);
            this.groupBox5.Location = new System.Drawing.Point(9, 462);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(271, 77);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DELETE";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(6, 19);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 6;
            this.button_delete.Text = "Select";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_OK_delete
            // 
            this.button_OK_delete.Enabled = false;
            this.button_OK_delete.Location = new System.Drawing.Point(87, 45);
            this.button_OK_delete.Name = "button_OK_delete";
            this.button_OK_delete.Size = new System.Drawing.Size(100, 23);
            this.button_OK_delete.TabIndex = 10;
            this.button_OK_delete.Text = "OK";
            this.button_OK_delete.UseVisualStyleBackColor = true;
            this.button_OK_delete.Click += new System.EventHandler(this.button_OK_delete_Click);
            // 
            // textBox_delete
            // 
            this.textBox_delete.Enabled = false;
            this.textBox_delete.Location = new System.Drawing.Point(87, 19);
            this.textBox_delete.Name = "textBox_delete";
            this.textBox_delete.Size = new System.Drawing.Size(177, 20);
            this.textBox_delete.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Bisque;
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.button_OK_create);
            this.groupBox6.Controls.Add(this.button_folder);
            this.groupBox6.Controls.Add(this.textBox_folder);
            this.groupBox6.Controls.Add(this.textBox_name);
            this.groupBox6.Location = new System.Drawing.Point(288, 462);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(271, 107);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CREATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "File name:";
            // 
            // button_OK_create
            // 
            this.button_OK_create.Enabled = false;
            this.button_OK_create.Location = new System.Drawing.Point(87, 74);
            this.button_OK_create.Name = "button_OK_create";
            this.button_OK_create.Size = new System.Drawing.Size(100, 23);
            this.button_OK_create.TabIndex = 10;
            this.button_OK_create.Text = "OK";
            this.button_OK_create.UseVisualStyleBackColor = true;
            this.button_OK_create.Click += new System.EventHandler(this.button_OK_create_Click);
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(6, 48);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(75, 23);
            this.button_folder.TabIndex = 7;
            this.button_folder.Text = "Folder";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.Enabled = false;
            this.textBox_folder.Location = new System.Drawing.Point(87, 48);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(177, 20);
            this.textBox_folder.TabIndex = 9;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(87, 19);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(177, 20);
            this.textBox_name.TabIndex = 8;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.button_OK_save);
            this.groupBox7.Controls.Add(this.textBox_name_save);
            this.groupBox7.Location = new System.Drawing.Point(9, 545);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(271, 77);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SAVE CHANGES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "File name:";
            // 
            // button_OK_save
            // 
            this.button_OK_save.Location = new System.Drawing.Point(87, 45);
            this.button_OK_save.Name = "button_OK_save";
            this.button_OK_save.Size = new System.Drawing.Size(100, 23);
            this.button_OK_save.TabIndex = 10;
            this.button_OK_save.Text = "OK";
            this.button_OK_save.UseVisualStyleBackColor = true;
            this.button_OK_save.Click += new System.EventHandler(this.button_OK_save_Click);
            // 
            // textBox_name_save
            // 
            this.textBox_name_save.Enabled = false;
            this.textBox_name_save.Location = new System.Drawing.Point(87, 19);
            this.textBox_name_save.Name = "textBox_name_save";
            this.textBox_name_save.Size = new System.Drawing.Size(177, 20);
            this.textBox_name_save.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(288, 576);
            this.label3.MaximumSize = new System.Drawing.Size(271, 45);
            this.label3.MinimumSize = new System.Drawing.Size(271, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 45);
            this.label3.TabIndex = 15;
            this.label3.Text = "1) Select file or directory\r\n2) Click on the corresponding button\r\n3) Confirm the" +
    " action by clicking on the \"OK\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 627);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox_Text);
            this.Controls.Add(this.listView_content);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.textBox_path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1061, 666);
            this.MinimumSize = new System.Drawing.Size(1061, 666);
            this.Name = "Form1";
            this.Text = "FILE MANAGER";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.ListView listView_content;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_date;
        private System.Windows.Forms.ColumnHeader columnHeader_type;
        private System.Windows.Forms.ColumnHeader columnHeader_size;
        private System.Windows.Forms.RichTextBox richTextBox_Text;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_paste;
        private System.Windows.Forms.TextBox textBox_copy;
        private System.Windows.Forms.TextBox textBox_paste;
        private System.Windows.Forms.Button button_OK_copy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_cut;
        private System.Windows.Forms.Button button_OK_cut;
        private System.Windows.Forms.Button button_paste1;
        private System.Windows.Forms.TextBox textBox_paste1;
        private System.Windows.Forms.TextBox textBox_cut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_source_compress;
        private System.Windows.Forms.Button button_OK_compress;
        private System.Windows.Forms.Button button_target_compress;
        private System.Windows.Forms.TextBox textBox_target_compress;
        private System.Windows.Forms.TextBox textBox_source_compress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_source_decompress;
        private System.Windows.Forms.Button button_OK_decompress;
        private System.Windows.Forms.Button button_target_decompress;
        private System.Windows.Forms.TextBox textBox_target_decompress;
        private System.Windows.Forms.TextBox textBox_source_decompress;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_OK_delete;
        private System.Windows.Forms.TextBox textBox_delete;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK_create;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_OK_save;
        private System.Windows.Forms.TextBox textBox_name_save;
        private System.Windows.Forms.Label label3;
    }
}

