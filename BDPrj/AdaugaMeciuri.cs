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
    public partial class AdaugaMeciuri : Form
    {
        public AdaugaMeciuri()
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
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
                                comboBox3.Items.Add(numeEchipa);
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
            DateTime selectedDate = dateTimePicker1.Value;
            string sqlFormattedDate = selectedDate.ToString("yyyy-MM-dd");
            string echipa1 = comboBox2.SelectedItem.ToString();
            string echipa2 = comboBox3.SelectedItem.ToString();
            string rezultat = textBox9.Text;
            string competitie = comboBox1.SelectedItem.ToString();

            string queryInsert = "INSERT INTO [Rezultate Echipe](CompetitieID, Echipa1ID, Echipa2ID, Rezultat, DataMeci) VALUES((SELECT CompetitieID FROM Competitii WHERE Nume = @Competitie), (SELECT EchipaID FROM Echipe WHERE Nume = @Echipa1), (SELECT EchipaID FROM Echipe WHERE Nume = @Echipa2), @Rezultat, @DataMeci)";

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true"))
            {
                connection.Open();
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@Competitie", competitie);
                    cmdInsert.Parameters.AddWithValue("@Echipa1", echipa1);
                    cmdInsert.Parameters.AddWithValue("@Echipa2", echipa2);
                    cmdInsert.Parameters.AddWithValue("@Rezultat", rezultat);
                    cmdInsert.Parameters.AddWithValue("@DataMeci", sqlFormattedDate);
                    cmdInsert.ExecuteNonQuery();
                }

                connection.Close();
            }

            textBox9.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void AdaugaMeciuri_Load(object sender, EventArgs e)
        {

        }
    }
}
