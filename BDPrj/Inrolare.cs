using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace BDPrj
{
    public partial class Inrolare : Form
    {
        public Inrolare()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport AND E.LocuriDisponibileMasculin > 0";
                }
                else
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport AND E.LocuriDisponibileFeminin > 0";
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
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport AND E.LocuriDisponibileMasculin > 0";
                }
                else
                {
                    query = "SELECT E.Nume FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE S.NumeSport = @Sport AND E.LocuriDisponibileFeminin > 0";
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nume = textBox2.Text;
            string prenume = textBox4.Text;
            string cnp = textBox9.Text;
            string gen = comboBox2.SelectedItem.ToString();
            string echipa = comboBox3.SelectedItem.ToString();

            string queryInsert = "INSERT INTO Studenti(Nume, Prenume, Sex, CNP, EchipaID) VALUES(@Nume, @Prenume, @Gen, @CNP, (SELECT EchipaID FROM Echipe WHERE Nume = @Echipa))";
            string queryUpdate;

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true"))
            {
                connection.Open();
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@Nume", nume);
                    cmdInsert.Parameters.AddWithValue("@Prenume", prenume);
                    cmdInsert.Parameters.AddWithValue("@CNP", cnp);
                    cmdInsert.Parameters.AddWithValue("@Gen", gen);
                    cmdInsert.Parameters.AddWithValue("@Echipa", echipa);
                    cmdInsert.ExecuteNonQuery();
                }
                if (gen == "M")
                {
                    queryUpdate = "UPDATE Echipe SET LocuriDisponibileMasculin = LocuriDisponibileMasculin - 1 WHERE Nume = @Echipa";
                }
                else
                {
                    queryUpdate = "UPDATE Echipe SET LocuriDisponibileFeminin = LocuriDisponibileFeminin - 1 WHERE Nume = @Echipa";
                }

                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@Echipa", echipa);
                    cmdUpdate.ExecuteNonQuery();
                }

                connection.Close();
            }

            textBox2.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
