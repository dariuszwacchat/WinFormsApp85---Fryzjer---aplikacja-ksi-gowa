using Business;
using Domain;
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
    public partial class UslugaCreate : Form
    {
        private ApplicationDbContext _context;
        private RodzajUslugi RodzajUslugi { get; set; }

        public UslugaCreate ()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            comboBoxRodzajUslugi.DataSource = _context.RodzajeUslug.Select(s=>s.Nazwa).ToList();
            textBoxWykonawca.Text = $"{LoginService.ZalogowanyUser.Imie} {LoginService.ZalogowanyUser.Nazwisko}"; 
            
        }

        private void UslugaCreate_Load (object sender, EventArgs e)
        {

        }

        private void buttonZapisz_Click (object sender, EventArgs e)
        {
            try
            {
                if (RodzajUslugi != null)
                {
                    double cn = RodzajUslugi.CenaNetto;
                    Usluga usluga = new Usluga ()
                    {
                        UslugaId = Guid.NewGuid ().ToString (),
                        RodzajUslugiId = RodzajUslugi.RodzajUslugiId,
                        CenaNetto = RodzajUslugi.CenaNetto,
                        Vat8 = S.BruttoVat8(cn),
                        Vat22 = S.BruttoVat22(cn),
                        ZyskBrutto8 = S.ZyskBruttoVat8(cn),
                        ZyskBrutto22 = S.ZyskBruttoVat22(cn),
                        DataWykonania = DateTime.Now,
                        UserId = _context.Users.FirstOrDefault().Id,
                        DataDodania = DateTime.Now
                    };
                    _context.Uslugi.Add(usluga);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void buttonAnuluj_Click (object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxRodzajUslugi_SelectedIndexChanged (object sender, EventArgs e)
        {
            RodzajUslugi = _context.RodzajeUslug.FirstOrDefault(f => f.Nazwa == comboBoxRodzajUslugi.SelectedItem.ToString()); 
            double cn = RodzajUslugi.CenaNetto; 

            textBoxCenaNetto.Text = RodzajUslugi.CenaNetto.ToString ();
            textBoxPodatekVat8.Text = S.BruttoVat8 (cn).ToString ();
            textBoxPodatekVat22.Text = S.BruttoVat22 (cn).ToString ();
            textBoxZyskBrutto8.Text = S.ZyskBruttoVat8 (cn).ToString ();
            textBoxZyskBrutto22.Text = S.BruttoVat22 (cn).ToString ();
        }

        private void textBoxCenaNetto_MouseDoubleClick (object sender, MouseEventArgs e)
        {
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
