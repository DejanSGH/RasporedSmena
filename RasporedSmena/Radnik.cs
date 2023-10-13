using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace RasporedSmena
{
    public class Radnik
    {
        //protected Radnik[] listaRadnika;
        protected List<Smena> biraneSmene;
        protected string ime;
        protected string prezime;
        protected string aktivan;
        protected string[] slobodniDani;
        protected int indeks;
        public Radnik(string ime, string prezime, string aktivan)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.aktivan = aktivan;
        }
        public Radnik(string podaci)
        {
            string[] delovi = podaci.Split(',');
            this.ime = delovi[0].Trim();
            this.prezime = delovi[1].Trim();
            this.aktivan = delovi[2].Trim();
            this.slobodniDani = new string[2];
        }

        public void dodajSmenuUBirane(Smena s)
        {
            if (biraneSmene == null)
            {
                biraneSmene = new List<Smena>();
            }
            biraneSmene.Add(s);
        }

        public List<Smena> getListuIzabranihSmena()
        {
            return biraneSmene;
        }

        public void obrisiListuIzabranihSmena()
        {
            biraneSmene = null;
            
        }


        public static Radnik[][] ucitajRadnike(String putanja)
        {
            int index = 0;

            if (File.Exists(putanja))
            {

                string[] linije = File.ReadAllLines(putanja);
                List<Radnik> ucitaniAktivniRadnici = new List<Radnik>();
                List<Radnik> ucitaniNeaktivniRadnici = new List<Radnik>();
                foreach (string linija in linije)
                {
                    try
                    {
                        Radnik radnik = new Radnik(linija);
                        if(radnik.getAktivan() == "1")
                        {
                            ucitaniAktivniRadnici.Add(radnik);
                        }
                        else if(radnik.getAktivan() == "0")
                        {
                            ucitaniNeaktivniRadnici.Add(radnik);
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Losi podaci na liniji " + linija);
                    }
                }
                Radnik[][] rezultat = new Radnik[2][];
                rezultat[0] = ucitaniAktivniRadnici.ToArray();
                rezultat[1] = ucitaniNeaktivniRadnici.ToArray();
                return rezultat;
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        public string getAktivan()
        {
            return this.aktivan;
        }
         public void setAktivan(Boolean aktivan)
        {
            this.aktivan = aktivan ? "1" : "0";
        }

        public string getIme()
        {
            return ime;
        }
        public string getPrezime()
        {
            return prezime;
        }
        public void setIme(String ime)
        {
            this.ime = ime;
        }
        public void setPrezime(String prezime)
        {
            this.prezime = prezime;
        }
        public void SetIndeks(int indeks)
        {
            this.indeks = indeks;
        }
        public int GetIndeks()
        {
            return this.indeks;
        }
        public void SetSlobodniDani(int index, string vrednost)
        {
            slobodniDani[index] = vrednost;
        }
        public string[] GetSlobodniDani()
        {
            return slobodniDani;
        }

        public string toString()
        {
            return ime + ", " + prezime;
        }
        public string toStringStatus()
        {
            return ime + ", " + prezime + ", " + aktivan;
        }
        public string punoIme()
        {
            return ime +  ' ' + prezime;
        }
        public void ispisUFormi(TextBox ispis)
        {
            ispis.AppendText(this.ime + " " + this.prezime);
        }
    }

}
