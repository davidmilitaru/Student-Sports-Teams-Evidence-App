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
    public partial class Loturi : Form
    {
        public Loturi(string team, List<string> nume, List<string> prenume, List<string> cnp, List<string> sex)
        {
            InitializeComponent();
            label2.Text = team;
            this.Text = team;
            for (int i = 0; i < nume.Count; i++)
            {
                dataGridView1.Rows.Add(nume[i], prenume[i], cnp[i], sex[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Echipe newForm = new Echipe();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
