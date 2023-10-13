using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasporedSmena
{
    public partial class IzmenaRadnikaForm : Form
    {
        private Radnik radnik;
        private string putanjaRadnika;
        public Boolean rezultat = false;
        public IzmenaRadnikaForm(Radnik radnik, string putanjaRadnika)
        {
            this.radnik = radnik;
            this.putanjaRadnika = putanjaRadnika;
            InitializeComponent();
            tbIme.Text = radnik.getIme();
            tbPrezime.Text = radnik.getPrezime();
            cbAktivan.Checked = radnik.getAktivan() == "1" ? true : false;

        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            rezultat = true;
            radnik.setIme(tbIme.Text);
            radnik.setPrezime(tbPrezime.Text);
            radnik.setAktivan(cbAktivan.Checked);
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
