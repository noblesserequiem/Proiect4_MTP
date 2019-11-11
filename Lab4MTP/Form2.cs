using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4MTP
{
    public partial class Form2 : Form
    {
        private string data, cnp;
        private string img;
        private string diag, coment;
        public Form2()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            
            
        }
        public Form2(string CNP)
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Text = CNP;
            

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            data = dateTimePicker1.Value.ToString();
            img = textBox2.Text;
            diag = textBox3.Text;
            coment = richTextBox1.Text;
            cnp = textBox1.Text;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "*.jpg|*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
            
        }
        public string Cnp
        {
            get { return cnp; }
            set { this.cnp = textBox1.Text; }
        }
        public string Data
        {
            get { return data; }
            set { this.data = dateTimePicker1.Value.ToString(); }
        }
        public string Imagine
        {
            get { return img; }
            set { this.img = textBox2.Text; }
        }
        public string Diagnostic
        {
            get { return diag; }
            set { this.diag = textBox3.Text; }
        }
        public string Comentarii
        {
            get { return coment; }
            set { this.coment = richTextBox1.Text; }
        }
    }
}
