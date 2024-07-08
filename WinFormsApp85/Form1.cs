using Business;
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
using WinFormsApp85.Forms.Przerwy;
using WinFormsApp85.Forms.Uslugi;
using WinFormsApp85.Forms.Uzytkownicy;

namespace WinFormsApp85
{
    public partial class Form1 : Form
    {
        private ApplicationDbContext _context;
        private string UslugaId { get; set; }
        private string RodzajUslugiId { get; set; }
        private string UserId { get; set; }
        private int Index { get; set; }


        public Form1 ()
        {
            InitializeComponent();
            _context = new ApplicationDbContext ();

            LoginService.ZalogowanyUser = _context.Users.FirstOrDefault ();
            
            dateTimePickerOd.Value = new DateTime(2019, 1, 1);
            dateTimePickerDo.Value = DateTime.Now;

            if (toolStripComboBoxPokazUslugiZ.Items.Count > 0)
                toolStripComboBoxPokazUslugiZ.SelectedIndex = 0;

            toolStripStatusLabelZalogowanyUzytkownik.Text = $"Zalogowany użytkownik: {LoginService.ZalogowanyUser.UserName}";
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            MessageBox.Show("SDF");
            this.Text = LoginService.ZalogowanyUser.Email + " " + LoginService.Rola;
        }

        private void Form1_Activated (object sender, EventArgs e)
        {
            _context = new ApplicationDbContext();
            DisplayUslugi();
            DisplayRodzajeUslug();
            DisplayUsers();
        }

        private void DisplayUslugi ()
        {
            Index = 0;
            var uslugi = _context.Uslugi
                .Include (i => i.User)
                .Include (i => i.RodzajUslugi)
                .ToList ();


            if (LoginService.Rola == "Personel")
            {
                uslugi = uslugi.Where (w=> w.UserId == LoginService.ZalogowanyUser.Id).ToList ();
            }


            if (!checkBoxWlacz.Checked)
            {
                switch (toolStripComboBoxPokazUslugiZ.SelectedItem.ToString())
                {
                    case "Dnia dzisiejszego":
                        uslugi = uslugi.Where(w => w.DataWykonania.Year >= DateTime.Now.Year &&
                                                  w.DataWykonania.Month >= DateTime.Now.Month &&
                                                  w.DataWykonania.Day >= DateTime.Now.Day).ToList();
                        break;
                    case "Miesiąca":
                        uslugi = uslugi.Where(w => w.DataWykonania.Year >= DateTime.Now.Year &&
                                                  w.DataWykonania.Month >= DateTime.Now.Month).ToList();
                        break;
                    case "Kwartału":
                        uslugi = uslugi.Where(w => w.DataWykonania.Year >= DateTime.Now.Year &&
                                                  w.DataWykonania.Month >= DateTime.Now.AddMonths(-4).Month).ToList();
                        break;
                    case "Półrocza":
                        uslugi = uslugi.Where(w => w.DataWykonania.Year >= DateTime.Now.Year &&
                                                  w.DataWykonania.Month >= DateTime.Now.AddMonths(-6).Month).ToList();
                        break;
                    case "Roku":
                        uslugi = uslugi.Where(w => w.DataWykonania.Year >= DateTime.Now.Year).ToList();
                        break;
                }
            } 
            else
            {
                uslugi = uslugi.Where(w => w.DataWykonania.Year >= dateTimePickerOd.Value.Year &&
                                          w.DataWykonania.Month >= dateTimePickerOd.Value.Month &&
                                          w.DataWykonania.Day >= dateTimePickerOd.Value.Day &&
                                          w.DataWykonania.Year <= dateTimePickerDo.Value.Year &&
                                          w.DataWykonania.Month <= dateTimePickerDo.Value.Month &&
                                          w.DataWykonania.Day <= dateTimePickerDo.Value.Day).ToList();
            } 



            dataGridViewUslugi.DataSource = (from f in uslugi
                                             select new
                                             {
                                                 UslugaId = f.UslugaId,
                                                 Lp = IndexCounter,
                                                 RodzajUslugi = f.RodzajUslugi.Nazwa,
                                                 WykonanePrzez = $"{f.User.Imie} {f.User.Nazwisko}",
                                                 CenaNetto = f.CenaNetto,
                                                 Vat8 = f.Vat8,
                                                 Vat22 = f.Vat22,
                                                 ZyskBrutto8 = f.ZyskBrutto8,
                                                 ZyskBrutto22 = f.ZyskBrutto22,
                                                 DataWykonania = f.DataWykonania
                                             }).ToList ();
        }

        private void DisplayRodzajeUslug ()
        {
            Index = 0;
            var rodzajeUslug = _context.RodzajeUslug.ToList ();
            dataGridViewRodzajeUslug.DataSource = rodzajeUslug;
        }

        private void DisplayUsers ()
        {
            Index = 0;
            var users = _context.Users
                .Include (i=> i.UserRegisters) 
                .Include (i=> i.Place)
                .Include (i=> i.Uslugi)
                .ToList ();

            dataGridViewUsers.DataSource = (from f in users
                                        select new
                                        {
                                            Id = f.Id,
                                            Lp = IndexCounter,
                                            Imie = f.Imie,
                                            Nazwisko = f.Nazwisko,
                                            Ulica = f.Ulica,
                                            Pesel = f.Pesel,
                                            Miejscowosc = f.Miejscowosc,
                                            DataUrodzenia = f.DataUrodzenia.ToShortDateString(),
                                            PlacaBrutto23 = f.PlacaBrutto23,
                                            Uslugi = f.Uslugi.Count, 
                                            UserRegisters = f.UserRegisters.Count,
                                        }).ToList();
        }
         

        private int IndexCounter
            => Index ++;

        private void dataGridViewUslugi_CellMouseClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                    UslugaId = dataGridViewUslugi.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridViewUslugi_CellMouseDoubleClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(UslugaId))
            {
                UslugaEdit ue = new UslugaEdit (UslugaId);
                ue.ShowDialog();
            }
        }

        private void dataGridViewUslugi_SelectionChanged (object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUslugi.SelectedRows.Count > 0)
                    UslugaId = dataGridViewUslugi.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridViewRodzajeUslug_CellMouseClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                    RodzajUslugiId = dataGridViewRodzajeUslug.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }
         

        private void dataGridViewRodzajeUslug_SelectionChanged (object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRodzajeUslug.SelectedRows.Count > 0)
                    RodzajUslugiId = dataGridViewRodzajeUslug.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridViewUsers_CellMouseClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                    UserId = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridViewUsers_CellMouseDoubleClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                UserEdit ue = new UserEdit (UserId);
                ue.ShowDialog();
            }
        }

        private void dataGridViewUsers_SelectionChanged (object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.SelectedRows.Count > 0)
                    UserId = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void toolStripButton1_Click (object sender, EventArgs e)
        {
            UslugaCreate uc = new UslugaCreate ();
            uc.ShowDialog ();
        }

        private void toolStripButton2_Click (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UslugaId))
            {
                var message = MessageBox.Show ("Czy na pewno chcesz usunąć wybraną pozycję?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    var usluga = _context.Uslugi.FirstOrDefault (f=> f.UslugaId == UslugaId);
                    if (usluga != null)
                    {  
                        _context.Uslugi.Remove(usluga);
                        _context.SaveChanges();

                        DisplayUsers();
                    }
                }
            }
        }

        private void toolStripButton3_Click (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UslugaId))
            {
                UslugaEdit ue = new UslugaEdit (UslugaId);
                ue.ShowDialog ();
            }
        }

        private void toolStripButton4_Click (object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RodzajUslugiId))
            {
                var message = MessageBox.Show ("Czy na pewno chcesz usunąć wybraną pozycję?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    var rodzajUslugi = _context.RodzajeUslug.FirstOrDefault (f=> f.RodzajUslugiId == RodzajUslugiId);
                    if (rodzajUslugi != null)
                    {  

                        var uslugi = _context.Uslugi.Where (w=> w.RodzajUslugiId == RodzajUslugiId).ToList();
                        if (uslugi != null)
                        {
                            foreach (var usluga in uslugi)
                            {
                                _context.Uslugi.Remove(usluga);
                                _context.SaveChanges();
                            }
                        }
                        _context.RodzajeUslug.Remove(rodzajUslugi);
                        _context.SaveChanges();

                        DisplayRodzajeUslug ();
                    }
                }
            }
        }

        private void toolStripButton6_Click (object sender, EventArgs e)
        {
            UserCreate uc = new UserCreate ();
            uc.ShowDialog ();
        }

        private void toolStripButton7_Click (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                var message = MessageBox.Show ("Czy na pewno chcesz usunąć wybraną pozycję?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    var user = _context.Users.FirstOrDefault (f=> f.Id == UserId);
                    if (user != null)
                    {

                        var userRegisters = _context.UserRegisters.Where (w=> w.UserId == UserId);
                        if (userRegisters != null)
                        {
                            foreach (var userRegister in userRegisters)
                            {
                                _context.UserRegisters.Remove(userRegister);
                                _context.SaveChanges();
                            }
                        }

                        var place = _context.Place.Where (w=> w.UserId == UserId);
                        if (place != null)
                        {
                            foreach (var placa in place)
                            {
                                _context.Place.Remove(placa);
                                _context.SaveChanges();
                            }
                        }
                        _context.Users.Remove(user);
                        _context.SaveChanges();

                        DisplayUsers ();
                    }
                }
            }
        }

        private void toolStripButton8_Click (object sender, EventArgs e)
        {

        }

        private void button5_Click (object sender, EventArgs e)
        {
            DisplayUslugi();
        }

        private void dateTimePickerOd_ValueChanged (object sender, EventArgs e)
        {
            DisplayUslugi ();
        }
         

        private void toolStripComboBoxPokazUslugiZ_SelectedIndexChanged (object sender, EventArgs e)
        {
            DisplayUslugi();
        }

        private void checkBoxWlacz_CheckedChanged (object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBoxWlacz.Checked;
            toolStripComboBoxPokazUslugiZ.Enabled = !checkBoxWlacz.Checked;
        }

        private void przerwaToolStripMenuItem_Click (object sender, EventArgs e)
        {
            PrzerwaCreate pc = new PrzerwaCreate ();
            pc.ShowDialog ();
        }
    }
}
