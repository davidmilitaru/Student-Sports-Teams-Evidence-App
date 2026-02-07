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
    public partial class StergeAntrenor : Form
    {
        public StergeAntrenor()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            string query = "SELECT (Nume + ' ' + Prenume) AS NumeAntrenor FROM Antrenori WHERE AntrenorID NOT IN (SELECT AntrenorID FROM Echipe)";
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
                            string nume = reader.GetValue(0).ToString();
                            comboBox1.Items.Add(nume);
                        }
                    }
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Sunteti sigur?", "Exit", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                    string nume_intreg = comboBox1.Text;
                    string[] parts = nume_intreg.Split(' ');
                    string nume = parts[0];
                    string prenume = parts[1];

                    string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
                    string query = "DELETE FROM Antrenori WHERE Nume = @Nume AND Prenume = @Prenume";
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@Nume", nume);
                            command.Parameters.AddWithValue("@Prenume", prenume);
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                query = "SELECT (Nume + ' ' + Prenume) AS NumeAntrenor FROM Antrenori WHERE AntrenorID NOT IN (SELECT AntrenorID FROM Echipe)";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nume_nou = reader.GetValue(0).ToString();
                                comboBox1.Items.Add(nume_nou);
                            }
                        }
                        con.Close();
                    }
                }
            }
            else
            {
                this.Show();
            }
        }
    }
}
