using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace RasporedSmena
{
    public partial class FormDetaljnije : Form
    {
        public Boolean rezultat = false;
        private Smena[] sveSmene;
        private GroupBox[] izboriSmena;
        private GroupBox[] izboriRadnika;
        private BiranjeDanaForm instancaForme;
        private Radnik radnik;
        private Boolean cekirano = false;
        public FormDetaljnije(Radnik radnik, Smena[] sveSmene, GroupBox[] izboriRadnika)
        {
            InitializeComponent();
            instancaForme = new BiranjeDanaForm();
            this.radnik = radnik;
            this.izboriRadnika = izboriRadnika;
            imeRadnikaLbl.Text = radnik.punoIme();
            imeRadnikaLbl.Location = new Point(0, 0);
            this.sveSmene = sveSmene;

            prikaziDetaljnoSmene(this);
        }

        private void FormDetaljnije_Load(object sender, EventArgs e)
        {

        }

        private void prikaziDetaljnoSmene(Control roditelj)
        {
            int gbSirina = (int)(roditelj.Size.Width * 0.80);
            int gbVisina = 60;
            int k = 0;

            izboriSmena = new GroupBox[7];
            int[] brojaci = new int[7];

            foreach (Dan dan in (Dan[])Enum.GetValues(typeof(Dan)))
            {
                GroupBox gb = new GroupBox();
                gb.Text = dan.ToString();
                gb.Location = new Point(50, 50 + k * (gbVisina + 20));
                gb.Size = new Size(gbSirina, gbVisina);
                //roditelj.Controls.Add(gb);
                izboriSmena[k] = gb;
                gb.Parent = roditelj;
                k++;

            }

            for (int i = 0; i < izboriSmena.Length; i++)
            {
                for (int j = 0; j < sveSmene.Length; j++)
                {
                    if (sveSmene[j].getDan().ToString().ToLower() == izboriSmena[i].Text.ToLower())
                    {
                        CheckBox cb = new CheckBox();
                        cb.Text = sveSmene[j].GetSat() + "h";
                        cb.Location = new Point(20 + brojaci[i] * 50, 20);
                        cb.Size = new Size(45, 20);


                        izboriSmena[i].Controls.Add(cb);
                        foreach(Control c in izboriSmena[i].Controls)
                        {
                            if(c is CheckBox)
                            {
                                CheckBox chbc = (CheckBox)c;
                                if (radnik.getListuIzabranihSmena() != null)
                                {
                                    for (int m = 0; m < radnik.getListuIzabranihSmena().Count; m++)
                                    {
                                        if (chbc.Text == radnik.getListuIzabranihSmena()[m].GetSat() + "h" && chbc.Parent.Text == radnik.getListuIzabranihSmena()[m].getDan().ToString())
                                        {
                                            chbc.Checked = true;
                                        }
                                    }
                                }
                            }

                        }
                        brojaci[i] += 1;
                    }
                }
            }

            for (int i = 0; i < izboriSmena.Length; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Click += new EventHandler(isChecked);
                cb.Text = "Oznaci Sve";
                cb.Location = new Point(30 + brojaci[i] * 50, 20);
                cb.Size = new Size(100, 20);
                izboriSmena[i].Controls.Add(cb);
                brojaci[i] += 1;
            }
        }

        public void isChecked(object sender, EventArgs e)
        {

            CheckBox checkedBox = (CheckBox)sender;
            GroupBox parentGroupBox = (GroupBox)checkedBox.Parent;
            string odabranDan = parentGroupBox.Text;

            if (sender is CheckBox)
            {
                CheckBox cb = (CheckBox)sender;
                if (cb.Text == "Oznaci Sve" && cb.Checked)
                {
                    for (int i = 0; i < izboriSmena.Length; i++)
                    {
                        if (izboriSmena[i].Text == odabranDan)
                        {
                            foreach (CheckBox cbs in izboriSmena[i].Controls)
                            {
                                cbs.Checked = true;
                            }
                        }
                    }
                }
                if (cb.Text == "Oznaci Sve" && !cb.Checked)
                {
                    for (int i = 0; i < izboriSmena.Length; i++)
                    {
                        if (izboriSmena[i].Text == odabranDan)
                        {
                            foreach (CheckBox cbs in izboriSmena[i].Controls)
                            {
                                cbs.Checked = false;
                            }
                        }
                    }
                }

            }

            cekirano = checkedBox.Checked;
        }


        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            rezultat = true;

            radnik.obrisiListuIzabranihSmena();

            for(int i = 0;i < izboriSmena.Length;i++)
            {
                for(int j = 0; j < sveSmene.Length; j++)
                {
                    foreach(Control c in izboriSmena[i].Controls)
                    {
                        if(c is CheckBox)
                        {
                            CheckBox chc = (CheckBox)c;
                            GroupBox gb = (GroupBox)chc.Parent;
                            string danNedelje = gb.Text;

                            if (danNedelje == sveSmene[j].getDan().ToString() &&  chc.Text == sveSmene[j].GetSat() + "h" && chc.Checked)
                            {                             
                                    radnik.dodajSmenuUBirane(sveSmene[j]);

                                    //MessageBox.Show("Dodat je radnik " + radnik.toString() + " u domen smene " + sveSmene[j].toString());
                            }
                        }

                    }
                }
            }

            //izlistajDomeneTest();

            this.Close();
        }

        private void izlistajDomeneTest()
        {
            for(int i = 0; i < sveSmene.Length; i++)
            {
                foreach(Radnik r in sveSmene[i].GetDomenRadnika())
                {
                    MessageBox.Show(r.toString());
                }
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
