namespace BDPrj
{
    partial class Echipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Universitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Antrenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competitii = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Lot = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 59);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Inchide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(25, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Inapoi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(356, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Echipe";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nume,
            this.Universitate,
            this.Sport,
            this.Antrenor,
            this.Competitii,
            this.Lot});
            this.dataGridView1.Location = new System.Drawing.Point(0, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(768, 371);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nume
            // 
            this.Nume.HeaderText = "Nume";
            this.Nume.MinimumWidth = 6;
            this.Nume.Name = "Nume";
            this.Nume.ReadOnly = true;
            this.Nume.Width = 170;
            // 
            // Universitate
            // 
            this.Universitate.HeaderText = "Universitate";
            this.Universitate.MinimumWidth = 6;
            this.Universitate.Name = "Universitate";
            this.Universitate.ReadOnly = true;
            this.Universitate.Width = 160;
            // 
            // Sport
            // 
            this.Sport.HeaderText = "Sport";
            this.Sport.MinimumWidth = 6;
            this.Sport.Name = "Sport";
            this.Sport.ReadOnly = true;
            this.Sport.Width = 125;
            // 
            // Antrenor
            // 
            this.Antrenor.HeaderText = "Antrenor";
            this.Antrenor.MinimumWidth = 6;
            this.Antrenor.Name = "Antrenor";
            this.Antrenor.ReadOnly = true;
            this.Antrenor.Width = 143;
            // 
            // Competitii
            // 
            this.Competitii.HeaderText = "Competitii";
            this.Competitii.MinimumWidth = 6;
            this.Competitii.Name = "Competitii";
            this.Competitii.ReadOnly = true;
            this.Competitii.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Competitii.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Competitii.Width = 125;
            // 
            // Lot
            // 
            this.Lot.HeaderText = "Lot";
            this.Lot.MinimumWidth = 6;
            this.Lot.Name = "Lot";
            this.Lot.ReadOnly = true;
            // 
            // Echipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 437);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Echipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Echipe";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nume;
        private DataGridViewTextBoxColumn Universitate;
        private DataGridViewTextBoxColumn Sport;
        private DataGridViewTextBoxColumn Antrenor;
        private DataGridViewButtonColumn Competitii;
        private DataGridViewButtonColumn Lot;
    }
}