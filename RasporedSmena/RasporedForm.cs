using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasporedSmena
{
    public class RasporedForm : Form
    {

        struct Polje
        {
            int red;
            int kolona;
            string vreme;
        }
        private List<Radnik>[] resenje;
        private Radnik[] sviRadnici;
        private Smena[] sveSmene;
        private TextBox textBox2;
        private DataGridView tabela;


        public RasporedForm(List<Radnik>[] resenje, Smena[] sveSmene, Radnik[] sviRadnici)
        {
            this.resenje = resenje;
            this.sveSmene = sveSmene;
            this.sviRadnici = sviRadnici;

            popuniIndekseRadnika();
            napraviTabelu();
            popuniTabelu();
        }

        private void popuniTabelu()
        {
            int ukupnoRedova = sviRadnici.Length + 1;
            int ukupnoKolona = 8;
            tabela.RowCount = ukupnoRedova;
            tabela.ColumnCount = ukupnoKolona;
            string[,] podaci = new string[ukupnoRedova,ukupnoKolona];

            podaci[0, 0] = "*";
            for (int i = 1; i < ukupnoKolona; i++)
            { 
                podaci[0,i] = ((Dan)(i-1)).ToString();
            }
            for (int i = 1;i < ukupnoRedova; i++)
            {
                podaci[i, 0] = sviRadnici[i - 1].punoIme();
            }

            for(int indeksSmene = 0; indeksSmene < resenje.Length; indeksSmene++)
            {
                for (int k = 0; k < resenje[indeksSmene].Count; k++)
                {
                    Radnik r = resenje[indeksSmene][k];
                    Smena s = sveSmene[indeksSmene];
                    podaci[r.GetIndeks() + 1, (int)s.getDan() + 1] = s.vremeString();
                }
            }

            for (int r = 0; r < ukupnoRedova; r++)
            {
                for (int k = 0; k < ukupnoKolona; k++)
                {
                    tabela.Rows[r].Cells[k].Value = podaci[r, k];
                }
            }
        }

        private void popuniIndekseRadnika()
        {
            for(int i = 0; i < sviRadnici.Length; i++)
            {
                sviRadnici[i].SetIndeks(i);
            }
        }

        private void napraviTabelu()
        {
            // Create a DataGridView control
            tabela = new DataGridView();
            tabela.Dock = DockStyle.Fill;
            tabela.ReadOnly = true;
            tabela.RowHeadersVisible = false;
            tabela.AllowUserToAddRows = false;

            Controls.Add(tabela);
            }
        }











    
}
