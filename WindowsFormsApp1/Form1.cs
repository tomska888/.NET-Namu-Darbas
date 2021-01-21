using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\zioma\Desktop\CatsInfo.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value?.ToString() + "\t" + "|");
                }
                writer.WriteLine("");
                writer.WriteLine("------------------------------------------------------------");
            }
            writer.Close();
        }

        //private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = saveFileDialog.ShowDialog();
        //    if (result == DialogResult.Cancel)
        //        return;

        //    //50:00 video
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.thecatapi.com/");
            HttpResponseMessage response = client.GetAsync("v1/breeds").Result;
            var bre = response.Content.ReadAsAsync<IEnumerable<Breeds>>().Result;
            dataGridView1.DataSource = bre;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\zioma\Desktop\CatsInfo.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value?.ToString() + "\t" + "|");
                }
                writer.WriteLine("");
                writer.WriteLine("------------------------------------------------------------");
            }
            writer.Close();
            MessageBox.Show("Data Exported");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                Id_txt.Text = row.Cells["Id"].Value.ToString();
                Name_txt.Text = row.Cells["Name"].Value.ToString();
                Origin_txt.Text = row.Cells["Origin"].Value.ToString();
                //tbMain.Text = row.Cells["Description"].Value.ToString();
                //tbMain.Text = row.Cells["Wikipedia_Url"].Value.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program about cat breeds");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = Color.Red;
        }

        private void cellsColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Blue;
        }

        private void defaultColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Black;
            dataGridView1.BackgroundColor = Color.Gray;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            Id_txt.Clear();
            Name_txt.Clear();
            Origin_txt.Clear();

        }
    }
}
