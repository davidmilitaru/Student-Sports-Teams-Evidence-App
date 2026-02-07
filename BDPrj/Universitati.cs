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
    public partial class Universitati : Form
    {
        public Universitati()
        {
            InitializeComponent();
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            dataGridView1.Rows.Clear();
            con.Open();
            string query = "SELECT U.Nume, COUNT(DISTINCT E.EchipaID) AS NumarEchipe, COUNT(DISTINCT S.StudentID) AS NumarStudenti\r\nFROM Universitati U INNER JOIN Echipe E ON E.UniversitateID = U.UniversitateID\r\n\t\t\t\t\tLEFT JOIN Studenti S ON S.EchipaID = E.EchipaID\r\nGROUP BY U.Nume";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    "Performante");
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (e.ColumnIndex == dataGridView1.Columns["Performante"].Index && e.RowIndex >= 0)
            {
                string parameter1 = dataGridView1.Rows[e.RowIndex].Cells["Universitate"].Value.ToString();
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                string query = "SELECT C.Nume, S.NumeSport, EC.RezultatFinal, EC.Categorie\r\nFROM EchipeCompetitii EC INNER JOIN Competitii C ON EC.CompetitieID = C.CompetitieID INNER JOIN Sporturi S ON S.SportID = C.SportID\r\nWHERE EC.EchipaID IN (SELECT E.EchipaID FROM Echipe E INNER JOIN Universitati U ON E.UniversitateID = U.UniversitateID WHERE U.Nume = @Param)";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Param", parameter1);
                        List<string> comps = new List<string>();
                        List<string> sports = new List<string>();
                        List<string> results = new List<string>();
                        List<string> cat = new List<string>();
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comps.Add(reader.GetValue(0).ToString());
                            sports.Add(reader.GetValue(1).ToString());
                            results.Add(reader.GetValue(2).ToString());
                            cat.Add(reader.GetValue(3).ToString());
                        }
                        UniversitatiCompetitii dispForm = new UniversitatiCompetitii(parameter1, comps, sports, results, cat);
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
