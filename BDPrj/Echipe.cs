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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace BDPrj
{
    public partial class Echipe : Form
    {
        public Echipe()
        {
            InitializeComponent();
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            dataGridView1.Rows.Clear();
            con.Open();
            string query = "SELECT E.Nume, U.Nume AS Universitate, S.NumeSport AS Sport, (A.Nume + ' ' + A.Prenume) AS [Nume Antrenor]\r\nFROM Echipe E INNER JOIN Universitati U ON E.UniversitateID = U.UniversitateID\r\n\t\t\t  INNER JOIN Sporturi S ON E.SportID = S.SportID\r\n\t\t\t  INNER JOIN Antrenori A ON E.AntrenorID = A.AntrenorID";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), "Competitii", "Lot");
            }
            reader.Close();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                this.Close();
                Info newForm = new Info();
                newForm.Show();
            }
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
            if (e.ColumnIndex == dataGridView1.Columns["Competitii"].Index && e.RowIndex >= 0)
            {
                string parameter1 = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                string query = "SELECT C.Nume AS NumeCompetitie, EC.RezultatFinal AS RezultatFinal, EC.Categorie AS Categorie FROM EchipeCompetitii EC INNER JOIN Competitii C ON EC.CompetitieID = C.CompetitieID INNER JOIN Echipe E ON EC.EchipaID = E.EchipaID WHERE E.Nume = @Param";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Param", parameter1);
                        List<string> comps = new List<string>();
                        List<string> results = new List<string>();
                        List<string> cat = new List<string>();
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comps.Add(reader.GetValue(0).ToString());
                            results.Add(reader.GetValue(1).ToString());
                            cat.Add(reader.GetValue(2).ToString());
                        }
                        EchipeCompetitii dispForm = new EchipeCompetitii(parameter1, comps, results, cat);
                        dispForm.Show();
                        this.Close();
                        con.Close();
                    }
                }

                //dataGridView1.Refresh();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Lot"].Index && e.RowIndex >= 0)
            {
                string parameter1 = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                string query = "SELECT S.Nume, S.Prenume, S.CNP, S.Sex FROM Studenti S JOIN Echipe E ON S.EchipaID = E.EchipaID WHERE E.EchipaID = (SELECT E.EchipaID FROM Echipe E WHERE E.Nume = @Param)";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Param", parameter1);
                        List<string> nume = new List<string>();
                        List<string> prenume = new List<string>();
                        List<string> cnp = new List<string>();
                        List<string> sex = new List<string>();
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            nume.Add(reader.GetValue(0).ToString());
                            prenume.Add(reader.GetValue(1).ToString());
                            cnp.Add(reader.GetValue(2).ToString());
                            sex.Add(reader.GetValue(3).ToString());
                        }
                        Loturi dispForm = new Loturi(parameter1, nume, prenume, cnp, sex);
                        dispForm.Show();
                        this.Close();
                        con.Close();
                    }
                }
            }
        }
    }
}
