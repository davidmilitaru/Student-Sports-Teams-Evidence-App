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
    public partial class AdaugaCompetitie : Form
    {
        public AdaugaCompetitie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Sunteti sigur?", "Exit", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                string sportSelectat = comboBox1.SelectedItem.ToString();
                string genSelectat = comboBox2.SelectedItem.ToString();
                string query;
                if (genSelectat == "M")
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport";
                }
                else
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport";
                }
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Sport", sportSelectat);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string numeEchipa = reader.GetValue(0).ToString();
                                comboBox3.Items.Add(numeEchipa);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                string sportSelectat = comboBox1.SelectedItem.ToString();
                string genSelectat = comboBox2.SelectedItem.ToString();
                string query;
                if (genSelectat == "M")
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport";
                }
                else
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport";
                }
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Sport", sportSelectat);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string numeEchipa = reader.GetValue(0).ToString();
                                comboBox3.Items.Add(numeEchipa);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nume = textBox2.Text;
            int an = int.Parse(textBox4.Text);
            int numar = int.Parse(textBox9.Text);
            string sport = comboBox1.SelectedItem.ToString();

            string queryInsert = "INSERT INTO Competitii(Nume, SportID, AnDesfasurare, NumarEchipe) VALUES(@Nume, (SELECT SportID FROM Sporturi WHERE NumeSport = @Sport), @An, @NumarEchipe)";

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true"))
            {
                connection.Open();
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@Nume", nume);
                    cmdInsert.Parameters.AddWithValue("@Sport", sport);
                    cmdInsert.Parameters.AddWithValue("@An", an);
                    cmdInsert.Parameters.AddWithValue("@NumarEchipe", numar);
                    cmdInsert.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string numeComp = textBox2.Text;
            string numeEchipa = comboBox3.SelectedItem.ToString();
            string genSelectat = comboBox2.SelectedItem.ToString();


            string queryInsert = "INSERT INTO EchipeCompetitii(EchipaID, CompetitieID, Categorie) VALUES((SELECT EchipaID FROM Echipe WHERE Nume = @Echipa), (SELECT CompetitieID FROM Competitii WHERE Nume = @Competitie), @Gen)";

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true"))
            {
                connection.Open();
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@Echipa", numeEchipa);
                    cmdInsert.Parameters.AddWithValue("@Competitie", numeComp);
                    cmdInsert.Parameters.AddWithValue("@Gen", genSelectat);
                    cmdInsert.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
