namespace RasporedSmena
{
    partial class DodajRadnikaForm
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
            cbAktivan = new CheckBox();
            btnOdustani = new Button();
            btnDodaj = new Button();
            tbPrezime = new TextBox();
            lblPrezime = new Label();
            tbIme = new TextBox();
            lblIme = new Label();
            SuspendLayout();
            // 
            // cbAktivan
            // 
            cbAktivan.AutoSize = true;
            cbAktivan.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cbAktivan.Location = new Point(97, 175);
            cbAktivan.Name = "cbAktivan";
            cbAktivan.RightToLeft = RightToLeft.Yes;
            cbAktivan.Size = new Size(112, 36);
            cbAktivan.TabIndex = 18;
            cbAktivan.Text = "Aktivan";
            cbAktivan.UseVisualStyleBackColor = true;
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(259, 217);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(86, 37);
            btnOdustani.TabIndex = 17;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(97, 217);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(86, 37);
            btnDodaj.TabIndex = 16;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(202, 140);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(143, 23);
            tbPrezime.TabIndex = 15;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrezime.Location = new Point(97, 131);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(99, 32);
            lblPrezime.TabIndex = 14;
            lblPrezime.Text = "Prezime";
            // 
            // tbIme
            // 
            tbIme.Location = new Point(202, 92);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(143, 23);
            tbIme.TabIndex = 13;
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblIme.Location = new Point(97, 83);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(54, 32);
            lblIme.TabIndex = 12;
            lblIme.Text = "Ime";
            // 
            // DodajRadnikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 373);
            Controls.Add(cbAktivan);
            Controls.Add(btnOdustani);
            Controls.Add(btnDodaj);
            Controls.Add(tbPrezime);
            Controls.Add(lblPrezime);
            Controls.Add(tbIme);
            Controls.Add(lblIme);
            Name = "DodajRadnikaForm";
            Text = "DodajRadnikaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbAktivan;
        private Button btnOdustani;
        private Button btnDodaj;
        private TextBox tbPrezime;
        private Label lblPrezime;
        private TextBox tbIme;
        private Label lblIme;
    }
}