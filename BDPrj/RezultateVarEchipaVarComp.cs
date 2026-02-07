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
    public partial class RezultateVarEchipaVarComp : Form
    {
        List<string> comps;
        List<string> res;
        List<string> cat;
        string team;
        public RezultateVarEchipaVarComp(string comp, string team, List<string> home_teams, List<string> away_teams, List<string> results, List<string> dates, List<string> comps, List<string> res, List<string> cat)
        {
            InitializeComponent();
            this.Text = comp + " - " + team;
            this.team = team;
            this.comps = comps;
            this.res = res;
            this.cat = cat;
            textBox1.Text = comp + " - " + team;
            for (int i = 0; i < home_teams.Count; i++)
            {
                dataGridView1.Rows.Add(home_teams[i], results[i], away_teams[i], dates[i]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            EchipeCompetitii newForm = new EchipeCompetitii(team, comps, res, cat);
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
    }
}
