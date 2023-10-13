using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using TextBox = System.Windows.Forms.TextBox;

namespace RasporedSmena
{
    public enum Dan
    {
        Pondeljak,
        Utorak,
        Sreda,
        Cetvrtak,
        Petak,
        Subota,
        Nedelja
    }
    public class Smena
    {

        protected string sat;
        protected string minut;
        protected Dan dan;
        protected string tip;
        protected List<Radnik> domenRadnika;
        protected int brojRadnika;

        public Smena(string sat, string minut, string dan, int brojRadnika)
        {   
            this.sat = sat;
            this.minut = minut;
            this.brojRadnika = brojRadnika;
            switch (dan.ToUpper())
            {
                case "PON":
                    this.dan = Dan.Pondeljak;
                    break;
                case "UTO":
                    this.dan = Dan.Utorak;
                    break;
                case "SRE":
                    this.dan = Dan.Sreda;
                    break;
                case "CET":
                    this.dan = Dan.Cetvrtak;
                    break;
                case "PET":
                    this.dan = Dan.Petak;
                    break;
                case "SUB":
                    this.dan = Dan.Subota;
                    break;
                case "NED":
                    this.dan = Dan.Nedelja;
                    break;
                default:
                    throw new ArgumentException("NEPOZNAT DAN");
            }
        }


        public Smena(string podaci)
        {
            string[] delovi = podaci.Split(',');
            if (delovi.Length != 4) throw new ArgumentException();
            switch (delovi[0].ToUpper())
            {
                case "PON":
                    dan = Dan.Pondeljak;
                    break;
                case "UTO":
                    dan = Dan.Utorak;
                    break;
                case "SRE":
                    dan = Dan.Sreda;
                    break;
                case "CET":
                    dan = Dan.Cetvrtak;
                    break;
                case "PET":
                    dan = Dan.Petak;
                    break;
                case "SUB":
                    dan = Dan.Subota;
                    break;
                case "NED":
                    dan = Dan.Nedelja;
                    break;
                default:
                    throw new ArgumentException("NEPOZNAT DAN");
            }
            this.sat = delovi[1].Trim();
            this.minut = delovi[2].Trim();
            this.brojRadnika = int.Parse(delovi[3].Trim());
            this.domenRadnika = new List<Radnik>();

        }

        public static Smena[] ucitajSmene(String putanja)
        {
            int index = 0;

            if (File.Exists(putanja))
            {

                string[] linije = File.ReadAllLines(putanja);
                List<Smena> ucitaneSmene = new List<Smena>();
                foreach (string linija in linije)
                {
                    try
                    {
                        Smena smena = new Smena(linija);
                        ucitaneSmene.Add(smena);

                    }
                    catch 
                    {
                        MessageBox.Show("Losi podaci na liniji " + linija);
                    }
                }
                return ucitaneSmene.ToArray();
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        public string GetSat()
        {
            return this.sat;
        }

        public int GetBrojRadnika()
        {
            return this.brojRadnika;
        }

        public Radnik pronadjiRadnika(int index)
        {
            return domenRadnika[index];
        }

        public Dan getDan()
        {
            return dan;
        }


        public Boolean mozeDaSePopuni()
        {
            return domenRadnika.Count >= this.brojRadnika;
        }

        public void dodajRadnikaUDomen(Radnik radnik)
        {
            domenRadnika.Add(radnik);
        }

        public List<Radnik> GetDomenRadnika()
        {
            return domenRadnika;
        }

        public void SetDomenRadnika(List<Radnik> lista)
        {
            this.domenRadnika = lista;
        }

        public void promesajDomen()
        {
            Random random = new Random();
            int k = random.Next(10);
            for(int i = 0; i < domenRadnika.Count; i++)
            {
                k = random.Next(domenRadnika.Count-1);
                Radnik r = domenRadnika[i];
                domenRadnika[i] = domenRadnika[k];
                domenRadnika[k] = r;
                 
            }
        }


        public String toString()
        {
            string s;
            switch (dan)
            {
                case Dan.Pondeljak:
                    s = "PON";
                    break;
                case Dan.Utorak:
                    s = "UTO";
                    break;
                case Dan.Sreda:
                    s = "SRE";
                    break;
                case Dan.Cetvrtak:
                    s = "CET";
                    break;
                case Dan.Petak:
                    s = "PET";
                    break;
                case Dan.Subota:
                    s = "SUB";
                    break;
                case Dan.Nedelja:
                    s = "NED";
                    break;
                default:
                    throw new ArgumentException("NEPOZNAT DAN");
            }

            return s + ", " + this.sat + ", " + this.minut + ", " + this.brojRadnika;//ne radi
        }

        public String vremeString()
        {
            return sat + ":" + minut; 
        }

    }
}
