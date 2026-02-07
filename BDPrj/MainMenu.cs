using System.Data.SqlClient;
using System.Numerics;

namespace BDPrj
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisponibilitatiForm dispForm = new DisponibilitatiForm();
            dispForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inrolare inrolare = new Inrolare();
            inrolare.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Info infoForm = new Info();
            infoForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginAdmin newForm = new LoginAdmin();
            newForm.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }

}