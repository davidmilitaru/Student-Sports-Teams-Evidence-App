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
    public partial class AdaugaRezultat : Form
    {
        public AdaugaRezultat()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            string query = "SELECT Nume FROM Competitii";
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

            using (SqlConnection con = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string numeComp = reader.GetValue(0).ToString();
                            comboBox1.Items.Add(numeComp);
                        }
                    }
                    con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            textBox9.Text = "";
            if (comboBox1.SelectedItem != null)
            {
                string competitie = comboBox1.SelectedItem.ToString();
                string query = "SELECT E.Nume FROM Echipe E INNER JOIN EchipeCompetitii EC ON E.EchipaID = EC.EchipaID WHERE EC.CompetitieID = (SELECT C.CompetitieID FROM Competitii C WHERE C.Nume = @Competitie)";
                string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";

                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Competitie", competitie);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string numeEchipa = reader.GetValue(0).ToString();
                                comboBox2.Items.Add(numeEchipa);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            string echipa = comboBox2.SelectedItem.ToString();
            string rezultat = textBox9.Text;
            string competitie = comboBox1.SelectedItem.ToString();
            string cat = comboBox3.SelectedItem.ToString();

            string queryInsert = "Update EchipeCompetitii SET RezultatFinal = @Rezultat WHERE CompetitieID = (SELECT CompetitieID FROM Competitii WHERE Nume = @Competitie) AND EchipaID = (SELECT EchipaID FROM Echipe WHERE Nume = @Echipa) AND Categorie = @Categorie";

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true"))
            {
                connection.Open();
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@Competitie", competitie);
                    cmdInsert.Parameters.AddWithValue("@Echipa", echipa);
                    cmdInsert.Parameters.AddWithValue("@Rezultat", rezultat);
                    cmdInsert.Parameters.AddWithValue("@Categorie", cat);
                    cmdInsert.ExecuteNonQuery();
                }

                connection.Close();
            }

            textBox9.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
        }
    }
}
