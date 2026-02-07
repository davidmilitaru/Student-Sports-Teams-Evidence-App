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
    public partial class StergeStudent : Form
    {
        public StergeStudent()
        {
            InitializeComponent();
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            dataGridView1.Rows.Clear();
            con.Open();
            string query = "SELECT S.Nume, S.Prenume, S.Sex, E.Nume FROM Studenti S INNER JOIN Echipe E ON E.EchipaID = S.EchipaID";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    "Sterge");
            }
            reader.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Sunteti sigur?", "Exit", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Sterge"].Index && e.RowIndex >= 0)
                {
                    string nume = dataGridView1.Rows[e.RowIndex].Cells["Nume"].Value.ToString();
                    string prenume = dataGridView1.Rows[e.RowIndex].Cells["Prenume"].Value.ToString();
                    string echipa = dataGridView1.Rows[e.RowIndex].Cells["Echipa"].Value.ToString();
                    string gen = dataGridView1.Rows[e.RowIndex].Cells["Gen"].Value.ToString();
                    string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
                    string queryUpdate;
                    string query = "DELETE FROM Studenti WHERE Nume = @Nume AND Prenume = @Prenume and EchipaID = (SELECT EchipaID FROM Echipe WHERE Nume = @Echipa)";
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@Nume", nume);
                            command.Parameters.AddWithValue("@Prenume", prenume);
                            command.Parameters.AddWithValue("@Echipa", echipa);
                            command.ExecuteNonQuery();
                        }
                        if (gen == "M")
                        {
                            queryUpdate = "UPDATE Echipe SET LocuriDisponibileMasculin = LocuriDisponibileMasculin + 1 WHERE Nume = @Echipa";
                        }
                        else
                        {
                            queryUpdate = "UPDATE Echipe SET LocuriDisponibileFeminin = LocuriDisponibileFeminin + 1 WHERE Nume = @Echipa";
                        }

                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Echipa", echipa);
                            cmdUpdate.ExecuteNonQuery();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            dataGridView1.Rows.Clear();
            con.Open();
            string query = "SELECT S.Nume, S.Prenume, S.Sex, E.Nume FROM Studenti S INNER JOIN Echipe E ON E.EchipaID = S.EchipaID WHERE S.Nume LIKE @Nume + '%'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nume", nume);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    "Sterge");
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
