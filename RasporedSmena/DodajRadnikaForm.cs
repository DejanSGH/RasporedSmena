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
    public partial class DodajRadnikaForm : Form
    {
        protected string aktivan;
        public Boolean rezultat = false;
        public Radnik noviRadnik;
        public DodajRadnikaForm()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (tbIme.Text.Length > 0 && tbPrezime.Text.Length > 0)
            {
                noviRadnik = new Radnik(tbIme.Text, tbPrezime.Text, aktivan = cbAktivan.Checked ? "1" : "0" );
                rezultat = true;
            }
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
