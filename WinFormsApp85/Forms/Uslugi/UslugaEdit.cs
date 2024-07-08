using Business;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp84.Data;

namespace WinFormsApp85.Forms.Uslugi
{
    public partial class UslugaEdit : Form
    {
        private ApplicationDbContext _context;
        private Usluga Usluga { get; set; }
        public string UslugaId { get; set; }



        public UslugaEdit (string uslugaId)
        {
            InitializeComponent();
            _context = new ApplicationDbContext ();
            UslugaId = uslugaId;
            Usluga = _context.Uslugi
                .Include(i => i.User)
                .Include(i => i.RodzajUslugi)
                .FirstOrDefault (f=> f.UslugaId == UslugaId);

            comboBoxRodzajUslugi.DataSource = _context.RodzajeUslug.Select(s=> s.Nazwa).ToList();
        }

        private void UslugaEdit_Load (object sender, EventArgs e)
        {
            try
            {
                if (Usluga != null)
                {
                    comboBoxRodzajUslugi.SelectedItem = Usluga.RodzajUslugi.Nazwa;
                    textBoxWykonawca.Text = $"{Usluga.User.Imie} {Usluga.User.Nazwisko}";
                    textBoxCenaNetto.Text = Usluga.CenaNetto.ToString ();
                    textBoxPodatekVat8.Text = Usluga.Vat8.ToString ();
                    textBoxPodatekVat22.Text = Usluga.Vat22.ToString();
                    textBoxZyskBrutto8.Text = Usluga.ZyskBrutto8.ToString ();
                    textBoxZyskBrutto22.Text = Usluga.ZyskBrutto22.ToString ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void buttonZapisz_Click (object sender, EventArgs e)
        {

        }

        private void buttonAnuluj_Click (object sender, EventArgs e)
        {
            Close ();
        }

        private void textBoxCenaNetto_TextChanged (object sender, EventArgs e)
        {
            try
            {
                string cena = textBoxCenaNetto.Text;
                double cn = double.Parse (cena);
                textBoxPodatekVat8.Text = S.BruttoVat8(cn).ToString();
                textBoxPodatekVat22.Text = S.BruttoVat22(cn).ToString();
                textBoxZyskBrutto8.Text = S.ZyskBruttoVat8(cn).ToString();
                textBoxZyskBrutto22.Text = S.BruttoVat22(cn).ToString();
            }
            catch { }
        }
    }
}
