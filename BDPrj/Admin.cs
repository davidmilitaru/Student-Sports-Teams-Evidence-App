using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPrj
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaugaCompetitie newForm = new AdaugaCompetitie();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdaugaMeciuri newForm = new AdaugaMeciuri();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdaugaRezultat newForm = new AdaugaRezultat();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StergeStudent newForm = new StergeStudent();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StergeAntrenor newForm = new StergeAntrenor();
            newForm.Show();
        }
    }
}
