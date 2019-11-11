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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            richTextBox1.Enabled = false;
            richTextBox1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lab4DataBDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.lab4DataBDataSet.Radiografii);
            // TODO: This line of code loads data into the 'lab4DataBDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.lab4DataBDataSet.Pacienti);

        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.lab4DataBDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.lab4DataBDataSet);
        }

        private void ImageCreator(object sender, DataGridViewCellMouseEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRowView data in radiografiiBindingSource.List)
            {
                DataGridView pacient = pacientiDataGridView;
                string cnp_rad = (string)data["CNP"];
                string cnp_pac = "";
                if (pacient.SelectedRows.Count > 0)
                {
                    cnp_pac = (string)pacient.SelectedRows[0].Cells[0].Value.ToString();
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
                if (cnp_rad == cnp_pac)
                {
                    string img = (string)data["Imagine"];
                    PictureBox pic = new PictureBox();
                    pic.SetBounds(0, 0, 100, 100);
                    pic.BackColor = Color.Black;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Image = Bitmap.FromFile(img);
                    pic.Tag = "Data: " + data["Data"] + "\nDiagnostic: " + (string)data["Diagnostic"] + "\nComentarii: " + (string)data["Comentarii"];
                    flowLayoutPanel1.Controls.Add(pic);
                    pic.Click += Pic_Click;
                }
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            richTextBox1.Show();
            richTextBox1.Text = pic.Tag.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridView pacient = pacientiDataGridView;
            string cnp_pac = (string)pacient.SelectedRows[0].Cells[0].Value.ToString();
            Form2 f = new Form2(cnp_pac);

            if (f.ShowDialog() == DialogResult.OK)
            {
                radiografiiTableAdapter.Insert(f.Cnp, f.Imagine, DateTime.Parse(f.Data), f.Diagnostic, f.Comentarii);                tableAdapterManager.UpdateAll(lab4DataBDataSet);
                radiografiiTableAdapter.Fill(lab4DataBDataSet.Radiografii);
            }
        }
    }
}
