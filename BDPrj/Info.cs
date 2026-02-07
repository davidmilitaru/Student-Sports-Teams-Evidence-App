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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Competitii compInfo = new Competitii();
            compInfo.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Echipe newForm = new Echipe();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Universitati newForm = new Universitati();
            newForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MainMenu newForm = new MainMenu();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
