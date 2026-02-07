using System.Data.SqlClient;
using System.Windows.Forms;

namespace BDPrj
{
    public partial class DisponibilitatiForm : Form
    {
        private List<string> messages;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private ListBox listBox;

        public DisponibilitatiForm()
        {
            InitializeComponent();
        }

        private void DisplayMessages()
        {
            listBox.Items.Clear();
            foreach (string message in messages)
            {
                listBox.Items.Add(message);
            }
        }

        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(284, 62);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(488, 184);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Inapoi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(678, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Inchide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Fotbal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 29);
            this.button4.TabIndex = 4;
            this.button4.Text = "Baschet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(53, 187);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "Handbal";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(53, 250);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 29);
            this.button6.TabIndex = 6;
            this.button6.Text = "Tenis de masa";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(53, 313);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 29);
            this.button7.TabIndex = 7;
            this.button7.Text = "Rugby";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // DisponibilitatiForm
            // 
            this.ClientSize = new System.Drawing.Size(831, 415);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox);
            this.Name = "DisponibilitatiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisponibilitatiEchipe";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu newForm = new MainMenu();
            newForm.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            string query = "SELECT E.Nume, E.LocuriDisponibileMasculin, E.LocuriDisponibileFeminin FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE (LocuriDisponibileMasculin > 0 OR LocuriDisponibileFeminin > 0) AND S.NumeSport = 'Fotbal'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> messages = new List<string>();
            while (reader.Read())
            {
                string output = "Locuri disponibile " + reader.GetValue(0) + " - " + reader.GetValue(1) + " masculin, " + reader.GetValue(2) + " feminin";
                messages.Add(output);
            }
            reader.Close();
            con.Close();
            this.messages = messages;
            DisplayMessages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            string query = "SELECT E.Nume, E.LocuriDisponibileMasculin, E.LocuriDisponibileFeminin FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE (LocuriDisponibileMasculin > 0 OR LocuriDisponibileFeminin > 0) AND S.NumeSport = 'Baschet'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> messages = new List<string>();
            while (reader.Read())
            {
                string output = "Locuri disponibile " + reader.GetValue(0) + " - " + reader.GetValue(1) + " masculin, " + reader.GetValue(2) + " feminin";
                messages.Add(output);
            }
            reader.Close();
            con.Close();
            this.messages = messages;
            DisplayMessages();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            string query = "SELECT E.Nume, E.LocuriDisponibileMasculin, E.LocuriDisponibileFeminin FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE (LocuriDisponibileMasculin > 0 OR LocuriDisponibileFeminin > 0) AND S.NumeSport = 'Handbal'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> messages = new List<string>();
            while (reader.Read())
            {
                string output = "Locuri disponibile " + reader.GetValue(0) + " - " + reader.GetValue(1) + " masculin, " + reader.GetValue(2) + " feminin";
                messages.Add(output);
            }
            reader.Close();
            con.Close();
            this.messages = messages;
            DisplayMessages();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            string query = "SELECT E.Nume, E.LocuriDisponibileMasculin, E.LocuriDisponibileFeminin FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE (LocuriDisponibileMasculin > 0 OR LocuriDisponibileFeminin > 0) AND S.NumeSport = 'Tenis de masa'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> messages = new List<string>();
            while (reader.Read())
            {
                string output = "Locuri disponibile " + reader.GetValue(0) + " - " + reader.GetValue(1) + " masculin, " + reader.GetValue(2) + " feminin";
                messages.Add(output);
            }
            reader.Close();
            con.Close();
            this.messages = messages;
            DisplayMessages();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string con_string = "Data Source = DESKTOP-PJGB503\\SQLEXPRESS; Initial Catalog = Evidenta echipelor sportive; Integrated security = true";
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            string query = "SELECT E.Nume, E.LocuriDisponibileMasculin, E.LocuriDisponibileFeminin FROM Echipe E INNER JOIN Sporturi S ON E.SportID = S.SportID WHERE (LocuriDisponibileMasculin > 0 OR LocuriDisponibileFeminin > 0) AND S.NumeSport = 'Rugby'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> messages = new List<string>();
            while (reader.Read())
            {
                string output = "Locuri disponibile " + reader.GetValue(0) + " - " + reader.GetValue(1) + " masculin, " + reader.GetValue(2) + " feminin";
                messages.Add(output);
            }
            reader.Close();
            con.Close();
            this.messages = messages;
            DisplayMessages();
        }
    }

}