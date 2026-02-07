using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPrj
{
    public partial class EchipeCompetitii : Form
    {
        string form_team;
        List<string> comps;
        List<string> res;
        List<string> cat;
        public EchipeCompetitii(string team, List<string> comps, List<string> results, List<string> cat)
        {
            InitializeComponent();
            this.form_team = team;
            this.comps = comps;
            this.res = results;
            this.cat = cat;
            this.Text = team;
            label2.Text = team;
            for (int i = 0; i < comps.Count; i++)
            {
                dataGridView1.Rows.Add(comps[i], results[i], cat[i], "Meciuri Disputate");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["MeciuriDisputate"].Index && e.RowIndex >= 0)
            {
                string parameter1 = dataGridView1.Rows[e.RowIndex].Cells["NumeCompetitie"].Value.ToString();
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                string query = "SELECT E1.nume AS Echipa1, E2.nume AS Echipa2, RE.Rezultat, RE.DataMeci FROM [Rezultate Echipe] RE INNER JOIN Echipe E1 ON RE.Echipa1ID = E1.EchipaID INNER JOIN Echipe E2 ON RE.Echipa2ID = E2.EchipaID WHERE RE.CompetitieID = (SELECT C.CompetitieID FROM Competitii C WHERE C.Nume = @Param1) AND (E1.nume = @Param2 OR E2.nume = @Param2)";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Param1", parameter1);
                        command.Parameters.AddWithValue("@Param2", this.form_team);
                        List<string> Echipa1 = new List<string>();
                        List<string> Echipa2 = new List<string>();
                        List<string> Rezultat = new List<string>();
                        List<string> DataMeci = new List<string>();
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Echipa1.Add(reader.GetValue(0).ToString());
                            Echipa2.Add(reader.GetValue(1).ToString());
                            Rezultat.Add(reader.GetValue(2).ToString());
                            DataMeci.Add(reader.GetValue(3).ToString());
                        }
                        RezultateVarEchipaVarComp dispForm = new RezultateVarEchipaVarComp(parameter1, this.form_team, Echipa1, Echipa2, Rezultat, DataMeci, this.comps, this.res, this.cat);
                        dispForm.Show();
                        this.Close();
                        con.Close();
                    }
                }

                //dataGridView1.Refresh();
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
    }
}
