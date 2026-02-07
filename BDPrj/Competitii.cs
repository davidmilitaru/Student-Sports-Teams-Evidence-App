using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BDPrj
{
    public partial class Competitii : Form
    {
        public Competitii()
        {
            InitializeComponent();
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            dataGridView1.Rows.Clear();
            con.Open();
            string query = "SELECT C.Nume, S.NumeSport, C.AnDesfasurare, C.NumarEchipe, E.Nume AS Castigator FROM Competitii C INNER JOIN Sporturi S ON C.SportID = S.SportID INNER JOIN Echipe E ON (SELECT EC.EchipaID FROM EchipeCompetitii EC WHERE EC.RezultatFinal = 'Locul 1' AND EC.CompetitieID = C.CompetitieID) = E.EchipaID\r\n";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), "Rezultate");
            }
            reader.Close();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Info newForm = new Info();
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
            if (e.ColumnIndex == dataGridView1.Columns["Rezultate"].Index && e.RowIndex >= 0) // e.RowIndex >= 0 to ensure it's not a header row
            {
                string parameter1 = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                string query = "SELECT E1.Nume AS Echipa1, E2.Nume AS Echipa2, R.Rezultat, R.DataMeci FROM [Rezultate Echipe] R INNER JOIN Echipe E1 ON R.Echipa1ID = E1.EchipaID INNER JOIN Echipe E2 ON R.Echipa2ID = E2.EchipaID INNER JOIN Competitii C ON R.CompetitieID = C.CompetitieID WHERE C.Nume = @Param";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Param", parameter1);
                        List<string> results = new List<string>();
                        List<string> dates = new List<string>();
                        List<string> home_teams = new List<string>();
                        List<string> away_teams = new List<string>();
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            home_teams.Add(reader.GetValue(0).ToString());
                            away_teams.Add(reader.GetValue(1).ToString());
                            results.Add(reader.GetValue(2).ToString());
                            dates.Add(reader.GetValue(3).ToString());
                        }
                        VariableCompetitieForm dispForm = new VariableCompetitieForm(parameter1, home_teams, away_teams, results, dates);
                        dispForm.Show();
                        this.Close();
                        con.Close();
                    }
                }

                //dataGridView1.Refresh();
            }
        }
    }
}
