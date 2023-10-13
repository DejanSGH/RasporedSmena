using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RasporedSmena
{
    public partial class Form1 : Form
    {
        private Radnik[] sviRadnici;
        private Radnik[] sviNeaktivniRadnici;
        private Smena[] sveSmene;
        private string putanjaSmene;
        private string putanjaRadnika;
        private BindingList<String> radniciListaStringova;
        private BindingList<String> radniciNeaktivniListaStringova;
        private BindingList<String> smeneListaStringova;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string procitajPutanju(string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filterTekst;
            if (filter != null)
            {
                filterTekst = "Text files (*.txt)|" + filter + "*.txt";
            }
            else
            {
                filterTekst = "Text files (*.txt)|*.txt";
            }
            openFileDialog.Filter = filterTekst;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;

            }
            else
            {
                return null;
            }
        }

        private void btnIspisiRadnike_Click_1(object sender, EventArgs e)
        {
            Boolean procitanRadnik = false;
            Radnik[] obeGrupeRadnika = new Radnik[2];
            radniciListaStringova = new BindingList<String>();
            radniciNeaktivniListaStringova = new BindingList<String>();
            if (string.IsNullOrEmpty(putanjaRadnika))
            {
                putanjaRadnika = "C:\\Users\\Dejan\\source\\repos\\RasporedSmena\\RasporedSmena\\konobari.txt";
            }

            while (!procitanRadnik)
            {
                try
                {
                    sviRadnici = Radnik.ucitajRadnike(putanjaRadnika)[0];
                    sviNeaktivniRadnici = Radnik.ucitajRadnike(putanjaRadnika)[1];
                    procitanRadnik = true;
                    foreach (Radnik r in sviRadnici)
                    {
                        radniciListaStringova.Add(r.toString());
                    }
                    foreach (Radnik r in sviNeaktivniRadnici)
                    {
                        radniciNeaktivniListaStringova.Add(r.toString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri citanju iz fajla");
                    putanjaRadnika = procitajPutanju("konobari");
                }
            }

            lbRadnici.DataSource = cbAktivni.Checked ? radniciListaStringova : radniciNeaktivniListaStringova;

        }

        private void btnIspisiSmene_Click_1(object sender, EventArgs e)
        {
            Boolean procitanSmena = false;
            smeneListaStringova = new BindingList<String>();

            if (string.IsNullOrEmpty(putanjaSmene))
            {
                putanjaSmene = "C:\\Users\\Dejan\\source\\repos\\RasporedSmena\\RasporedSmena\\smene.txt";
            }
            while (!procitanSmena)
            {
                try
                {
                    sveSmene = Smena.ucitajSmene(putanjaSmene);
                    procitanSmena = true;
                    foreach (Smena s in sveSmene)
                    {
                        smeneListaStringova.Add(s.toString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri citanju iz fajla");
                    putanjaSmene = procitajPutanju("smene");
                }
            }

            lbSmene.DataSource = smeneListaStringova;
        }

        private void btnIzaberiFileRadnici_Click(object sender, EventArgs e)
        {
            putanjaRadnika = procitajPutanju("konobari");
        }

        private void btnIzaberiFileSmene_Click(object sender, EventArgs e)
        {
            putanjaSmene = procitajPutanju("smene");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BiranjeDanaForm bdf = new BiranjeDanaForm(sviRadnici, sveSmene);
            bdf.Show();
        }

        private void cmsRadniciIzmeni_Click(object sender, EventArgs e)
        {
            Radnik radnikIzabrani = null;
            Boolean grupaRadnika = false;
            int indeks = lbRadnici.SelectedIndex;
            if (cbAktivni.Checked)
            {
                grupaRadnika = true;
                radnikIzabrani = sviRadnici[indeks];
            }
            else if (!cbAktivni.Checked)
            {
                radnikIzabrani = sviNeaktivniRadnici[indeks];
            }
            //MessageBox.Show(radnikIzabrani.toString());

            IzmenaRadnikaForm irf = new IzmenaRadnikaForm(radnikIzabrani, putanjaRadnika);
            irf.ShowDialog();
            if (irf.rezultat)
            {
                MessageBox.Show(radnikIzabrani.toString());
                if (grupaRadnika)
                {
                    radniciListaStringova[indeks] = radnikIzabrani.toString();
                }
                else if (!grupaRadnika)
                {
                    radniciNeaktivniListaStringova[indeks] = radnikIzabrani.toString();
                }

                string putanja = putanjaRadnika;
                Radnik[] obeGrupeRadnika = sviRadnici.ToArray().Concat(sviNeaktivniRadnici.ToArray()).ToArray();
                string[] noviFajl = new string[obeGrupeRadnika.Length];

                for (int i = 0; i < obeGrupeRadnika.Length; i++)
                {
                    noviFajl[i] = obeGrupeRadnika[i].toStringStatus();
                }

                Array.Sort(noviFajl);
                File.WriteAllLines(putanja, noviFajl);
                btnIspisiRadnike_Click_1(sender, e);
                lbRadnici.Refresh();
            }
        }

        private void cmsRadniciDodaj_Click(object sender, EventArgs e)
        {
            DodajRadnikaForm drf = new DodajRadnikaForm();
            drf.ShowDialog();
            if (drf.rezultat)
            {

                string putanja = putanjaRadnika;

                File.AppendAllText(putanja, drf.noviRadnik.toStringStatus() + "\n");
                btnIspisiRadnike_Click_1(sender, e);
                lbRadnici.Refresh();
            }
        }

        private void cbAktivni_CheckedChanged(object sender, EventArgs e)
        {
            btnIspisiRadnike_Click_1(sender, e);
        }
    }
}