namespace RasporedSmena
{
    partial class FormDetaljnije
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
            imeRadnikaLbl = new Label();
            btnPotvrdi = new Button();
            btnOdustani = new Button();
            SuspendLayout();
            // 
            // imeRadnikaLbl
            // 
            imeRadnikaLbl.AutoSize = true;
            imeRadnikaLbl.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            imeRadnikaLbl.Location = new Point(32, 18);
            imeRadnikaLbl.Name = "imeRadnikaLbl";
            imeRadnikaLbl.Size = new Size(90, 37);
            imeRadnikaLbl.TabIndex = 0;
            imeRadnikaLbl.Text = "label1";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(12, 621);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(110, 37);
            btnPotvrdi.TabIndex = 1;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(141, 621);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(110, 37);
            btnOdustani.TabIndex = 2;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // FormDetaljnije
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 670);
            Controls.Add(btnOdustani);
            Controls.Add(btnPotvrdi);
            Controls.Add(imeRadnikaLbl);
            Name = "FormDetaljnije";
            Text = "FormDetaljnije";
            Load += FormDetaljnije_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label imeRadnikaLbl;
        private Button btnPotvrdi;
        private Button btnOdustani;
    }
}