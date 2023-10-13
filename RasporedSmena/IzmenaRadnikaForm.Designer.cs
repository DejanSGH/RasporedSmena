namespace RasporedSmena
{
    partial class IzmenaRadnikaForm
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
            lblIme = new Label();
            tbIme = new TextBox();
            tbPrezime = new TextBox();
            lblPrezime = new Label();
            btnIzmeni = new Button();
            btnOdustani = new Button();
            cbAktivan = new CheckBox();
            SuspendLayout();
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblIme.Location = new Point(87, 108);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(54, 32);
            lblIme.TabIndex = 0;
            lblIme.Text = "Ime";
            // 
            // tbIme
            // 
            tbIme.Location = new Point(192, 117);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(143, 23);
            tbIme.TabIndex = 1;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(192, 165);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(143, 23);
            tbPrezime.TabIndex = 3;
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrezime.Location = new Point(87, 156);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(99, 32);
            lblPrezime.TabIndex = 2;
            lblPrezime.Text = "Prezime";
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(87, 242);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(86, 37);
            btnIzmeni.TabIndex = 4;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(249, 242);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(86, 37);
            btnOdustani.TabIndex = 5;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // cbAktivan
            // 
            cbAktivan.AutoSize = true;
            cbAktivan.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cbAktivan.Location = new Point(87, 200);
            cbAktivan.Name = "cbAktivan";
            cbAktivan.RightToLeft = RightToLeft.Yes;
            cbAktivan.Size = new Size(112, 36);
            cbAktivan.TabIndex = 6;
            cbAktivan.Text = "Aktivan";
            cbAktivan.UseVisualStyleBackColor = true;
            // 
            // IzmenaRadnikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 373);
            Controls.Add(cbAktivan);
            Controls.Add(btnOdustani);
            Controls.Add(btnIzmeni);
            Controls.Add(tbPrezime);
            Controls.Add(lblPrezime);
            Controls.Add(tbIme);
            Controls.Add(lblIme);
            Name = "IzmenaRadnikaForm";
            Text = "IzmenaRadnikaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIme;
        private TextBox tbIme;
        private TextBox tbPrezime;
        private Label lblPrezime;
        private Button btnIzmeni;
        private Button btnOdustani;
        private CheckBox cbAktivan;
    }
}