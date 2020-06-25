using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public TextBox TextBoxText { get => textBox1; set => textBox1 = value; }
        public Form1()
        {
            InitializeComponent();
            Text = "Безымянный";
            if (textBox1.TextLength > 0)
            Text = "*Безымянный";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                DialogResult res;
                res = MessageBox.Show($"Файл не сохранен.\nХотите сохранить его?", "Сохранить файл?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "";
                    sfd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                }
                if (res == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked == true)
            {
                textBox1.WordWrap = true;
            }
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                textBox1.WordWrap = false;
            }
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font fnt = new Font(textBox1.Font.FontFamily, textBox1.Font.Size + 1);
            textBox1.Font = fnt;

        }

        private void zoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Font fnt = new Font(textBox1.Font.FontFamily, textBox1.Font.Size - 1);
            textBox1.Font = fnt;
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form a = new About();
            a.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/dotnet/csharp/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                Text = "*Безымянный";

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            toolStripButton3.Visible = false;
            toolStripButton4.Visible = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            toolStripButton4.Visible = false;
            toolStripButton3.Visible = true;
        }

        private void editStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (editStripToolStripMenuItem.Checked == false)
                toolStrip2.Visible = false;
            else
                toolStrip2.Visible = true;
        }

        private void projectStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectStripToolStripMenuItem.Checked == false)
                toolStrip1.Visible = false;
            else
                toolStrip1.Visible = true;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(textBox1.SelectedText);
                int pos = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(pos, Clipboard.GetText().Length);
                textBox1.SelectionStart = pos;
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(textBox1.SelectedText);
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            //int pos = textBox1.SelectionStart;
            //textBox1.Text = textBox1.Text.Insert(pos, Clipboard.GetText());
            //textBox1.SelectionStart = pos + Clipboard.GetText().Length;
            textBox1.Paste();

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fd = new SaveFileDialog())
            {
                string docPath = @".\New.txt";
                
                //fd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //fd.FilterIndex = 1;
                //fd.RestoreDirectory = true;
                //File.WriteAllText(fd.FileName, textBox1.Text);
                //if (fd.ShowDialog()==DialogResult.OK)
                //{
                //    File.WriteAllText(fd.FileName, textBox1.Text);
                //}
                FileStream file = new FileStream(docPath, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file, Encoding.Default);
                writer.Write(textBox1.Text);
                writer.Close();
                Text = file.Name;

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
                
            {
                DialogResult res;
                res = MessageBox.Show($"Файл не сохранен.\nХотите сохранить его?", "Сохранить файл?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "";
                    sfd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                }
                if (res == DialogResult.No)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        ofd.FilterIndex = 1;
                        ofd.RestoreDirectory = true;
                        
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {

                            string s = File.ReadAllText(ofd.FileName);
                            textBox1.Text = s;
                        }
                        Text = ofd.FileName;
                    }
                }
            }
            else { 
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.RestoreDirectory = true;
                    
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {

                        string s = File.ReadAllText(ofd.FileName);
                        textBox1.Text = s;
                    }
                    Text = ofd.FileName;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@".\");
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FindWondow(this);
            f.Show();

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (textBox1.TextLength != 0)
            {
                DialogResult res;
                res = MessageBox.Show($"Файл не сохранен.\nХотите сохранить его?", "Сохранить файл?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "";
                    sfd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                   
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, textBox1.Text);
                    }
                }
                if (res == DialogResult.No)
                {
                    string path = @".\New.txt";
                    using (FileStream fs = File.Create(path))
                    {
                        textBox1.Clear();
                        Text = fs.Name;
                    }
                    
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fd = new SaveFileDialog())
            {
                fd.FileName = "";
                fd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(fd.FileName, textBox1.Text);
                }
                Text = fd.FileName;

            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

                    MessageBox.Show("Ошибка параметров печати.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         
            
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var font = new FontDialog();
            font.ShowColor = true;


            font.Font = textBox1.Font;
            font.Color = textBox1.ForeColor;

            if (font.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = font.Font;
                textBox1.ForeColor = font.Color;
            }
        }
    }
}
