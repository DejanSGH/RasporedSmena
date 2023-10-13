namespace RasporedSmena
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnIspisiSmene = new Button();
            btnIspisiRadnike = new Button();
            btnIzaberiFileSmene = new Button();
            btnIzaberiFileRadnici = new Button();
            button1 = new Button();
            lbRadnici = new ListBox();
            cmsRadnici = new ContextMenuStrip(components);
            cmsRadniciIzmeni = new ToolStripMenuItem();
            cmsRadniciDodaj = new ToolStripMenuItem();
            lbSmene = new ListBox();
            cbAktivni = new CheckBox();
            cmsRadnici.SuspendLayout();
            SuspendLayout();
            // 
            // btnIspisiSmene
            // 
            btnIspisiSmene.Location = new Point(441, 537);
            btnIspisiSmene.Name = "btnIspisiSmene";
            btnIspisiSmene.Size = new Size(75, 23);
            btnIspisiSmene.TabIndex = 4;
            btnIspisiSmene.Text = "Smene";
            btnIspisiSmene.UseVisualStyleBackColor = true;
            btnIspisiSmene.Click += btnIspisiSmene_Click_1;
            // 
            // btnIspisiRadnike
            // 
            btnIspisiRadnike.Location = new Point(118, 537);
            btnIspisiRadnike.Name = "btnIspisiRadnike";
            btnIspisiRadnike.Size = new Size(75, 23);
            btnIspisiRadnike.TabIndex = 2;
            btnIspisiRadnike.Text = "Radnici";
            btnIspisiRadnike.UseVisualStyleBackColor = true;
            btnIspisiRadnike.Click += btnIspisiRadnike_Click_1;
            // 
            // btnIzaberiFileSmene
            // 
            btnIzaberiFileSmene.Location = new Point(522, 538);
            btnIzaberiFileSmene.Name = "btnIzaberiFileSmene";
            btnIzaberiFileSmene.Size = new Size(75, 23);
            btnIzaberiFileSmene.TabIndex = 7;
            btnIzaberiFileSmene.Text = "Izaberi File";
            btnIzaberiFileSmene.UseVisualStyleBackColor = true;
            btnIzaberiFileSmene.Click += btnIzaberiFileSmene_Click;
            // 
            // btnIzaberiFileRadnici
            // 
            btnIzaberiFileRadnici.Location = new Point(208, 537);
            btnIzaberiFileRadnici.Name = "btnIzaberiFileRadnici";
            btnIzaberiFileRadnici.Size = new Size(75, 23);
            btnIzaberiFileRadnici.TabIndex = 8;
            btnIzaberiFileRadnici.Text = "Izaberi File";
            btnIzaberiFileRadnici.UseVisualStyleBackColor = true;
            btnIzaberiFileRadnici.Click += btnIzaberiFileRadnici_Click;
            // 
            // button1
            // 
            button1.Location = new Point(726, 265);
            button1.Name = "button1";
            button1.Size = new Size(115, 50);
            button1.TabIndex = 9;
            button1.Text = "Dalje";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lbRadnici
            // 
            lbRadnici.ContextMenuStrip = cmsRadnici;
            lbRadnici.FormattingEnabled = true;
            lbRadnici.ItemHeight = 15;
            lbRadnici.Location = new Point(28, 17);
            lbRadnici.Name = "lbRadnici";
            lbRadnici.Size = new Size(255, 514);
            lbRadnici.TabIndex = 10;
            // 
            // cmsRadnici
            // 
            cmsRadnici.Items.AddRange(new ToolStripItem[] { cmsRadniciIzmeni, cmsRadniciDodaj });
            cmsRadnici.Name = "cmsRadnici";
            cmsRadnici.Size = new Size(185, 70);
            // 
            // cmsRadniciIzmeni
            // 
            cmsRadniciIzmeni.Name = "cmsRadniciIzmeni";
            cmsRadniciIzmeni.Size = new Size(180, 22);
            cmsRadniciIzmeni.Text = "Izmeni";
            cmsRadniciIzmeni.Click += cmsRadniciIzmeni_Click;
            // 
            // cmsRadniciDodaj
            // 
            cmsRadniciDodaj.Name = "cmsRadniciDodaj";
            cmsRadniciDodaj.Size = new Size(184, 22);
            cmsRadniciDodaj.Text = "Dodaj novog radnika";
            cmsRadniciDodaj.Click += cmsRadniciDodaj_Click;
            // 
            // lbSmene
            // 
            lbSmene.FormattingEnabled = true;
            lbSmene.ItemHeight = 15;
            lbSmene.Location = new Point(351, 18);
            lbSmene.Name = "lbSmene";
            lbSmene.Size = new Size(255, 514);
            lbSmene.TabIndex = 11;
            // 
            // cbAktivni
            // 
            cbAktivni.AutoSize = true;
            cbAktivni.Checked = true;
            cbAktivni.CheckState = CheckState.Checked;
            cbAktivni.Location = new Point(28, 540);
            cbAktivni.Name = "cbAktivni";
            cbAktivni.Size = new Size(63, 19);
            cbAktivni.TabIndex = 12;
            cbAktivni.Text = "Aktivni";
            cbAktivni.UseVisualStyleBackColor = true;
            cbAktivni.CheckedChanged += cbAktivni_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1438, 792);
            Controls.Add(cbAktivni);
            Controls.Add(lbSmene);
            Controls.Add(lbRadnici);
            Controls.Add(button1);
            Controls.Add(btnIzaberiFileRadnici);
            Controls.Add(btnIzaberiFileSmene);
            Controls.Add(btnIspisiSmene);
            Controls.Add(btnIspisiRadnike);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            cmsRadnici.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnIspisiRadnike;
        private Button btnIspisiSmene;
        private Button btnIzaberiFileSmene;
        private Button btnIzaberiFileRadnici;
        private Button button1;
        private ListBox lbRadnici;
        private ListBox lbSmene;
        private ContextMenuStrip cmsRadnici;
        private ToolStripMenuItem cmsRadniciIzmeni;
        private ToolStripMenuItem cmsRadniciDodaj;
        private CheckBox cbAktivni;
    }
}