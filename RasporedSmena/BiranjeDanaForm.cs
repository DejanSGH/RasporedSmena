using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RasporedSmena
{
    public partial class BiranjeDanaForm : Form
    {
        private Radnik[] sviRadnici;
        private Smena[] sveSmene;
        private GroupBox[] izboriRadnika;
        private Button btnDalje;
        private TextBox textBox;
        private Button btnPrikaziRaspored;

        public BiranjeDanaForm()
        {
            InitializeComponent();
        }
        public BiranjeDanaForm(Radnik[] radnici, Smena[] smene)
        {


            this.sviRadnici = radnici;
            this.sveSmene = smene;
            InitializeComponent();
            Panel container = new Panel();
            container.Size = new Size((int)(this.Width * 0.75), this.Height);

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.Size = new Size(500, 500);
            container.Controls.Add(panel);
            this.Controls.Add(container);

            dodajIzboreRadnika(panel);
            btnDalje = new Button();
            btnDalje.Size = new Size(100, 100);
            btnDalje.Text = "Dalje";
            btnDalje.Location = new Point(Right - 200, Bottom - 200);
            btnDalje.Click += new EventHandler(popuniDomene);
            this.Controls.Add(btnDalje);

            btnDalje.Click += new EventHandler(DaljeButton_Clicked);

            btnPrikaziRaspored = new Button();
            btnPrikaziRaspored.Size = new Size(100, 100);
            btnPrikaziRaspored.Text = "Prikazi Raspored";
            btnPrikaziRaspored.Location = new Point(btnDalje.Left, btnDalje.Top - 150);
            btnPrikaziRaspored.Enabled = false;
            btnPrikaziRaspored.Click += new EventHandler(PrikaziRasporedButton_Clicked);
            this.Controls.Add(btnPrikaziRaspored);

            textBox = new TextBox();
            textBox.Multiline = true; // Enable multiline mode
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Width = 200; // Set the width of the TextBox
            textBox.Height = 500; // Set the desired height of the TextBox
            textBox.Location = new Point(btnDalje.Right + 10, 15); // Set location to the top of the form
            this.Controls.Add(textBox);
        }

        public void onemoguciCheckBox(GroupBox gb)
        {
            foreach (Control c in gb.Controls)
            {
                if (c is CheckBox)
                {
                    c.Enabled = false;
                }
            }

        }

        public void omoguciCheckBox(GroupBox gb)
        {
            foreach (Control c in gb.Controls)
            {
                if (c is CheckBox)
                {
                    c.Enabled = true;
                }
            }

        }

        public void DaljeButton_Clicked(object sender, EventArgs e)
        {
            btnPrikaziRaspored.Enabled = true;
        }

        private void PrikaziRasporedButton_Clicked(object sender, EventArgs e)
        {
            RasporedForm rasporedForm = new RasporedForm(resenje, sveSmene, sviRadnici);
            rasporedForm.Show();
        }

        public void dodajDugmice(int k)
        {
            for (int i = 0; i < k; i++)
            {
                Button button = new Button();
                button.Text = "Dugme " + i;
                button.Location = new Point(15, 5 + (20 * i));
                button.Size = new Size(80, 15);
                this.Controls.Add(button);
            }
        }

        public void dodajIzboreRadnika(Control roditelj)
        {
            int gbSirina = (int)(roditelj.Size.Width * 0.80);
            int gbVisina = 60;

            izboriRadnika = new GroupBox[sviRadnici.Length];

            for (int i = 0; i < sviRadnici.Length; i++)
            {
                GroupBox gb = new GroupBox();
                gb.Tag = sviRadnici[i];
                gb.Text = sviRadnici[i].punoIme();
                gb.Location = new Point(50, 50 + i * (gbVisina + 20));
                gb.Size = new Size(gbSirina, gbVisina);
                //roditelj.Controls.Add(gb);
                izboriRadnika[i] = gb;
                gb.Parent = roditelj;


                int br = 0;
                foreach (Dan dan in (Dan[])Enum.GetValues(typeof(Dan)))
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = dan.ToString();
                    cb.Location = new Point(20 + br * 50, 20);
                    cb.Size = new Size(45, 20);
                    gb.Controls.Add(cb);
                    br++;
                }

                Button btnDetaljnije = new Button();
                btnDetaljnije.Text = "Detaljnije";
                btnDetaljnije.Location = new Point(25 + br * 50, 20);
                btnDetaljnije.Size = new Size(70, 30);
                btnDetaljnije.Click += new EventHandler(DetaljnijeButton_Clicked);
                gb.Controls.Add(btnDetaljnije);
                br++;

                Button btnOdustani = new Button();
                btnOdustani.Text = "Odustani";
                btnOdustani.Location = new Point(btnDetaljnije.Right + 10, 20);
                btnOdustani.Size = new Size(70, 30);
                btnOdustani.Enabled = false;
                btnOdustani.Click += new EventHandler(OdustaniButton_Clicked);
                gb.Controls.Add(btnOdustani);

            }

        }

        public void OdustaniButton_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            GroupBox parentGroupBox = (GroupBox)clickedButton.Parent;
            Radnik r = (Radnik)parentGroupBox.Tag;

            r.obrisiListuIzabranihSmena();

            omoguciCheckBox(parentGroupBox);
            clickedButton.Enabled = false;

        }


        public void DetaljnijeButton_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            GroupBox parentGroupBox = (GroupBox)clickedButton.Parent;
            Radnik r = (Radnik)parentGroupBox.Tag;

            FormDetaljnije detaljnijeForm = new FormDetaljnije(r, sveSmene, izboriRadnika);
            detaljnijeForm.ShowDialog();
            if (detaljnijeForm.rezultat)
            {
                onemoguciCheckBox(parentGroupBox);
                foreach (Control c in parentGroupBox.Controls)
                {
                    if (c is Button && c.Text == "Odustani")
                    {

                        c.Enabled = true;
                    }
                }
            }
        }



        private void popuniDomene(object sender, EventArgs e)
        {
            ponoviIzbor();


            for (int k = 0; k < izboriRadnika.Length; k++)
            {
                Radnik r = sviRadnici[k];
                List<Dan> listaSlobodnihDana = new List<Dan>();
                GroupBox gb = izboriRadnika[k];
                Boolean radnikVecRasporedjen = false;


                foreach (Control c in gb.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if (!cb.Enabled)
                        {
                            radnikVecRasporedjen = true;
                            break;
                        }
                        if (cb.Checked)
                        {

                            listaSlobodnihDana.Add((Dan)Enum.Parse(typeof(Dan), cb.Text));

                        }
                    }
                }
                if (!radnikVecRasporedjen)
                {
                    foreach (Smena s in sveSmene)
                    {
                        if (!listaSlobodnihDana.Contains(s.getDan()))
                        {
                            s.dodajRadnikaUDomen(r);
                        }
                    }
                }
                else
                {
                    foreach (Smena s in r.getListuIzabranihSmena())
                    {
                        s.dodajRadnikaUDomen(r);
                    }
                }
            }
            if (proveriIzbor())
            {
                promesajDomene();
                if (DodelaRadnikaSmenama())
                {
                    prikaziRadnike();
                }
                else
                {
                    MessageBox.Show("Ne mogu da napravim raspored za smenu!");
                    ponoviIzbor();
                }

            }
        }

        private void promesajDomene()
        {
            foreach (Smena s in sveSmene)
            {
                s.promesajDomen();
            }
        }

        private void ponoviIzbor()
        {

            foreach (Smena s in sveSmene)
            {
                s.GetDomenRadnika().Clear();
            }
        }

        private Boolean proveriIzbor()
        {
            foreach (Smena s in sveSmene)
            {
                if (!s.mozeDaSePopuni())
                {
                    MessageBox.Show("Ne mogu da napravim raspored za smenu \n" + s.toString());

                    ponoviIzbor();
                    return false;
                }
            }

            return true;
        }

        List<Radnik>[] resenje;


        private Boolean DodelaRadnikaSmenama()
        {

            List<Radnik>[] pocetniDomeni;
            resenje = new List<Radnik>[sveSmene.Length];
            pocetniDomeni = new List<Radnik>[sveSmene.Length];
            for (int i = 0; i < sveSmene.Length; i++)
            {
                resenje[i] = new List<Radnik>();
            }
            for (int i = 0; i < sveSmene.Length; i++)
            {
                pocetniDomeni[i] = sveSmene[i].GetDomenRadnika();
            }

            //return dodeliRadnika(pocetniDomeni, 0);
            return dodeliRadnikaIterativno(pocetniDomeni);
        }

        private Boolean proveraSmene(int index)
        {
            return resenje[index].Count == sveSmene[index].GetBrojRadnika();
        }

        private int brojacRekurzije = 0;

        private int dohvatiIndeksSmeneSaNajmanjimDomenom(List<Radnik>[] noviDomeni)
        {
            int min = 99999;
            int minIndeks = -1;
            for(int i = 0;i < sveSmene.Length;i++)
            {
                if (proveraSmene(i)) continue;

                int potrebnoRadnika = sveSmene[i].GetBrojRadnika() - resenje[i].Count;
                int dostupnoRadnika = noviDomeni[i].Count;
                int x = dostupnoRadnika - potrebnoRadnika;

                if(x < 0)
                {
                    MessageBox.Show("Smena: " + sveSmene[i].toString() + " \n potrebno radnika: " + potrebnoRadnika + " \n dostupno radnika: " + dostupnoRadnika);
                    return -1;
                }
                if(x < min)
                {
                    min = x;
                    minIndeks = i;
                }

            }
            return (minIndeks < 0 ) ? 0 : minIndeks;
        }

        private Boolean dodeliRadnika(List<Radnik>[] domeni, int indexSmene)
        {
            if (proveriResenje())
            {
                return true;
            }
            Dan dan = sveSmene[indexSmene].getDan();

            while (domeni[indexSmene].Count > 0)
            {
                Radnik r = domeni[indexSmene][0];
                domeni[indexSmene].RemoveAt(0);
                resenje[indexSmene].Add(r);
                List<Radnik>[] noviDomeni = dubokaKopija(domeni);

                for (int i = 0; i < sveSmene.Length; i++)
                {
                    if (i != indexSmene && sveSmene[i].getDan() == dan)
                    {
                        noviDomeni[i].Remove(r);

                    }
                }


                
                int sledeciIndex = dohvatiIndeksSmeneSaNajmanjimDomenom(noviDomeni);
                if(sledeciIndex < 0)
                {
                    //MessageBox.Show("AAAAAA");
                    resenje[indexSmene].Remove(r);
                    return false;
                }

                if (dodeliRadnika(noviDomeni, sledeciIndex))
                {
                    return true;
                }

                resenje[indexSmene].Remove(r);
            }
            
            return false;
        }

        //------------------------------------------------

        struct Stanje
        {
            public Stanje(int inedksSmene, List<Radnik>[] domeni)
            {
                this.dodeljeniRadnik = null;
                this.indexSmene = inedksSmene;
                this.domeni = domeni;
            }
            public int indexSmene;
            public List<Radnik>[] domeni;
            public Radnik dodeljeniRadnik;


        }
        private Boolean dodeliRadnikaIterativno(List<Radnik>[] domeni)
        {
            Stack<Stanje> StackStanja = new Stack<Stanje>();
            Stanje pocetno = new Stanje(0, domeni);
            StackStanja.Push(pocetno);

            Radnik tsDodeljeniRadnik;
            List<Radnik>[] tsDomeni;
            int tsIndexSmene;

            while (StackStanja.Count > 0)
            {
                if (!resenjeSanityCheck())
                {
                    MessageBox.Show("Resenje Sanity Check Failed");
                    break;
                }

                if (proveriResenje())
                {
                    return true;
                }

                Stanje trenutnoStanje = StackStanja.Peek();
                tsDodeljeniRadnik = trenutnoStanje.dodeljeniRadnik;
                tsDomeni = trenutnoStanje.domeni;
                tsIndexSmene = trenutnoStanje.indexSmene;

                if (!domainSanityCheck(tsDomeni))
                {
                    MessageBox.Show("Domeni Sanity Check Failed");
                    break;
                }

                if (tsDodeljeniRadnik != null)
                {
                    resenje[tsIndexSmene].Remove(tsDodeljeniRadnik);
                }
                if (tsDomeni[tsIndexSmene].Count == 0)
                {
                    StackStanja.Pop();
                    continue;
                    //Ovaj pop je kao kada rekurzija vrati false, tj vracamo se korak unazad
                }

                tsDodeljeniRadnik = tsDomeni[tsIndexSmene][0];
                trenutnoStanje.dodeljeniRadnik = tsDodeljeniRadnik;
                tsDomeni[tsIndexSmene].RemoveAt(0);
                resenje[tsIndexSmene].Add(tsDodeljeniRadnik);

                Dan dan = sveSmene[tsIndexSmene].getDan();
                List<Radnik>[] noviDomeni = dubokaKopija(tsDomeni);//bug
                for (int i = 0; i < sveSmene.Length; i++)
                {
                    if (i != tsIndexSmene && sveSmene[i].getDan() == dan)
                    {
                        noviDomeni[i].Remove(tsDodeljeniRadnik);
                    }
                }

                int sledeciIndex = dohvatiIndeksSmeneSaNajmanjimDomenom(noviDomeni);
                if (sledeciIndex < 0)
                {
                    trenutnoStanje.dodeljeniRadnik = null;
                    resenje[tsIndexSmene].Remove(tsDodeljeniRadnik);
                    continue;
                }

                Stanje novoStanje = new Stanje(sledeciIndex, noviDomeni);
                StackStanja.Push(novoStanje);

            }
            return false;
        }

        Boolean domainSanityCheck (List<Radnik>[] TrenutniDomeni)
        {
            for(int i = 0; i < sveSmene.Length; i++)
            {
                foreach(Radnik r in resenje[i])
                {
                    Dan dan = sveSmene[i].getDan();

                    for(int k = 0; k < sveSmene.Length; k++)
                    {
                        if(sveSmene[k].getDan() == dan)
                        {
                            if (TrenutniDomeni[k].Contains(r))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        Boolean resenjeSanityCheck()
        {
            for (int i = 0; i < sveSmene.Length; i++)
            {
                foreach (Radnik r in resenje[i])
                {
                    Dan dan = sveSmene[i].getDan();

                    for (int k = 0; k < sveSmene.Length; k++)
                    {
                        if (i != k && sveSmene[k].getDan() == dan)
                        {
                            if (resenje[k].Contains(r))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private List<Radnik>[] dubokaKopija(List<Radnik>[] domeni)
        {
            List<Radnik>[] kopijaDomena = new List<Radnik>[domeni.Length];
            for (int i = 0; i < domeni.Length; i++)
            {
                kopijaDomena[i] = new List<Radnik>(domeni[i]);
            }
            return kopijaDomena;
        }

        private Boolean proveriResenje()
        {
            for (int i = 0; i < sveSmene.Length; i++)
            {
                if (resenje[i].Count() < sveSmene[i].GetBrojRadnika())
                {
                    return false;
                }
            }
            return true;
        }

        private void prikaziRadnike()
        {
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < resenje.Length; i++)
            {
                List<Radnik> dodeljeniRadnici = resenje[i];
                resultBuilder.AppendLine(sveSmene[i].toString());

                if (dodeljeniRadnici.Count == 0)
                {
                    resultBuilder.AppendLine("No workers assigned");
                }
                else
                {
                    foreach (Radnik worker in dodeljeniRadnici)
                    {
                        resultBuilder.AppendLine(worker.punoIme());
                    }
                }

                resultBuilder.AppendLine();
            }

            textBox.Text = resultBuilder.ToString();
        }



        private void BiranjeDanaForm_Load(object sender, EventArgs e)
        {
            //dodajIzboreRadnika(this);
        }


    }

}
