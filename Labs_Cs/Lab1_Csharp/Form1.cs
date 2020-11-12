using System;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows.Forms;

namespace lab1_Csharp
{
    public partial class Form1 : Form
    {
        string sourcePath = "", targetPath = "", fileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private string GetPath()
        {
            if (listView_content.SelectedItems.Count == 0 || textBox_path.Text == "")
                return "";

            return Path.Combine(textBox_path.Text, listView_content.SelectedItems[0].SubItems[0].Text);
        }
        //-----------------------------------------------------------------------------------------------

        private void button_browse_Click(object sender, EventArgs e)
        {
            listView_content_MouseDoubleClick_1(null, null);
            try
            {
                ShowContent(textBox_path.Text);
            }
            catch
            {
                MessageBox.Show("INCORRECT PATH! :(");
            }
            
        }

        private void textBox_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_browse.PerformClick();
        }
        //-----------------------------------------------------------------------------------------------

        private void button_back_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_path.Text))
                return;

            if (textBox_path.Text[textBox_path.Text.Length - 1] == '\\')
            {
                textBox_path.Text = textBox_path.Text.Remove(textBox_path.Text.Length - 1, 1);

                DeleteLast();
            }
            else if (textBox_path.Text[textBox_path.Text.Length - 1] != '\\')
                DeleteLast();
            
            ShowContent(textBox_path.Text);
        }

        private void DeleteLast()
        {
            while (textBox_path.Text[textBox_path.Text.Length - 1] != '\\')
            {
                textBox_path.Text = textBox_path.Text.Remove(textBox_path.Text.Length - 1, 1);
                if (textBox_path.Text == "")
                    break;
            }
        }
        //-----------------------------------------------------------------------------------------------

        private void ShowContent(string path)
        {
            listView_content.Items.Clear();

            if (path == "")
                return;

            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo currentDir in dirs)
            {
                string[] row = { currentDir.Name, currentDir.LastWriteTime.ToLongDateString(),
                    currentDir.Extension};
                ListViewItem item = new ListViewItem(row);
                listView_content.Items.Add(item);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo currentFile in files)
            {
                string[] row = { currentFile.Name, currentFile.LastWriteTime.ToLongDateString(),
                    currentFile.Extension, currentFile.Length.ToString() + "B"};
                ListViewItem item = new ListViewItem(row);
                listView_content.Items.Add(item);
            }
        }

        private void ShowText(string path)
        {
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;
            textBox_name_save.Text = fileName;
            sourcePath = GetPath();

            richTextBox_Text.Clear();

            using (StreamReader reader = new StreamReader(path))
                richTextBox_Text.Text = reader.ReadToEnd();
        }
        //-----------------------------------------------------------------------------------------------

        private void listView_content_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (listView_content.SelectedItems.Count == 0)
                return;

            string path = GetPath();
            if (Path.GetExtension(path) == "") //очередной каталог
            {
                textBox_path.Text = path;
                ShowContent(textBox_path.Text);
            }
            else if (Path.GetExtension(path) == ".txt") //текстовый файл
                ShowText(path);
            else
                Process.Start(path);                   //файл другого типа
        }

        private void listView_content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right) //клавиша вправо
            {
                if (listView_content.SelectedItems.Count != 0)
                    listView_content_MouseDoubleClick_1(null, null);
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Escape) //влево
                button_back.PerformClick();
        }
        //-----------------------------------------------------------------------------------------------

        private void button_copy_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_copy.Text = GetPath();
            sourcePath = GetPath();
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;

            if (textBox_copy.Text != "" && textBox_paste.Text != "")
                button_OK_copy.Enabled = true;
        }

        private void button_paste_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_paste.Text = textBox_path.Text;
            targetPath = Path.Combine(textBox_path.Text, fileName);

            if (sourcePath != "" && targetPath != "")
                button_OK_copy.Enabled = true;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Copy(sourcePath, targetPath);
            textBox_copy.Clear();
            textBox_paste.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Copy(string sourcePath, string targetPath)
        {
            System.IO.File.Copy(sourcePath, targetPath, true);
            button_browse.PerformClick();
            button_OK_copy.Enabled = false;

        }
        //-----------------------------------------------------------------------------------------------

        private void button_cut_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_cut.Text = GetPath();
            sourcePath = GetPath();
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;

            if (textBox_cut.Text != "" && textBox_paste1.Text != "")
                button_OK_cut.Enabled = true;
        }

        private void button_paste1_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_paste1.Text = textBox_path.Text;
            targetPath = Path.Combine(textBox_path.Text, fileName);

            if (sourcePath != "" && targetPath != "")
                button_OK_cut.Enabled = true;
        }

        private void button_OK_cut_Click(object sender, EventArgs e)
        {
            Move(sourcePath, targetPath);
            textBox_cut.Clear();
            textBox_paste1.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Move(string sourcePath, string targetPath)
        {
            File.Move(sourcePath, targetPath);
            button_browse.PerformClick();
            button_OK_cut.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------

        private void button_source_ZIP_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_source_compress.Text = GetPath();
            sourcePath = GetPath();
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;

            if (textBox_source_compress.Text != "" && textBox_target_compress.Text != "")
                button_OK_compress.Enabled = true;
        }

        private void button_target_ZIP_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_target_compress.Text = textBox_path.Text;
            targetPath = Path.Combine(textBox_path.Text, fileName);

            if (sourcePath != "" && targetPath != "")
                button_OK_compress.Enabled = true;
        }

        private void button_OK_ZIP_Click(object sender, EventArgs e)
        {
            Compress(sourcePath, targetPath);
            textBox_source_compress.Clear();
            textBox_target_compress.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Compress(string sourcePath, string targetPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(targetPath))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        // копируем байты из одного потока в другой
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
            button_browse.PerformClick();
            button_OK_compress.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------

        private void button_source_decompress_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_source_decompress.Text = GetPath();
            sourcePath = GetPath();
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;

            if (textBox_source_decompress.Text != "" && textBox_target_decompress.Text != "")
                button_OK_decompress.Enabled = true;
        }

        private void button_target_decompress_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_target_decompress.Text = textBox_path.Text;
            targetPath = Path.Combine(textBox_path.Text, fileName);

            if (sourcePath != "" && targetPath != "")
                button_OK_decompress.Enabled = true;
        }

        private void button_OK_decompress_Click(object sender, EventArgs e)
        {
            Decompress(sourcePath, targetPath);
            textBox_source_decompress.Clear();
            textBox_target_decompress.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Decompress(string sourcePath, string targetPath)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetPath))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
            button_browse.PerformClick();
            button_OK_decompress.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;

            textBox_delete.Text = GetPath();
            sourcePath = GetPath();
            fileName = listView_content.SelectedItems[0].SubItems[0].Text;

            if (textBox_delete.Text != "")
                button_OK_delete.Enabled = true;
        }

        private void button_OK_delete_Click(object sender, EventArgs e)
        {
            Delete(sourcePath);            
            textBox_delete.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Delete(string sourcePath)
        {
            File.Delete(sourcePath);
            ShowContent(textBox_path.Text);
            button_OK_delete.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------

        private void button_folder_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text == "")
                return;
            if (String.IsNullOrEmpty(textBox_name.Text))
                MessageBox.Show("Firstly, please, NAME THE FILE! :)");
            else
            {
                fileName = textBox_name.Text;

                textBox_folder.Text = textBox_path.Text;
                targetPath = Path.Combine(textBox_path.Text, fileName);

                if (fileName != "" && targetPath != "")
                    button_OK_create.Enabled = true;
            }
        }

        private void button_OK_create_Click(object sender, EventArgs e)
        {
            Create(targetPath);
            textBox_folder.Clear();
            textBox_name.Clear();
            richTextBox_Text.Clear();
            sourcePath = "";
            targetPath = "";
        }

        private void Create(string targetPath)
        {
            using (StreamWriter writer = new StreamWriter(targetPath + ".txt"))
                writer.Write(richTextBox_Text.Text);
            ShowContent(textBox_path.Text);
            button_OK_create.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------

        private void button_OK_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_name_save.Text))
                MessageBox.Show("Firstly, please, CHOOSE A FILE!");
            else
            {
                targetPath = sourcePath;

                Save(targetPath);
                textBox_name_save.Clear();
                textBox_name.Clear();
                richTextBox_Text.Clear();
                sourcePath = "";
                targetPath = "";
            }
        }

        private void Save(string targetPath)
        {
            using (StreamWriter writer = new StreamWriter(targetPath))
                writer.Write(richTextBox_Text.Text);
            ShowContent(textBox_path.Text);
            button_OK_save.Enabled = false;
        }
    }
}
