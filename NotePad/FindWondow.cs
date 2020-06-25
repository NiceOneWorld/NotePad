using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class FindWondow : Form
    {
        Form1 mainForm;
        public FindWondow()
        {
            InitializeComponent();
            
            
        }
        public FindWondow(Form1 f)
        {
            InitializeComponent();
            mainForm = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos = mainForm.TextBoxText.Text.IndexOf(FindBox1.Text);
            if (pos == -1)
                return;
            mainForm.TextBoxText.SelectionStart = pos;
            mainForm.TextBoxText.SelectionLength = FindBox1.Text.Length;
            mainForm.Activate();

        }

        private void FindBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
