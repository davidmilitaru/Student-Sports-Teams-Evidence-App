using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPrj
{
    public partial class UniversitatiCompetitii : Form
    {
        public UniversitatiCompetitii(string uni, List<string> comps, List<string> sports, List<string> results, List<string> cat)
        {
            InitializeComponent();
            this.Text = uni;
            label2.Text = uni;
            for (int i = 0; i < comps.Count; i++)
            {
                dataGridView1.Rows.Add(comps[i], sports[i], results[i], cat[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Universitati newForm = new Universitati();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult res;
            res = MessageBox.Show("Sunteti sigur?", "Exit", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
