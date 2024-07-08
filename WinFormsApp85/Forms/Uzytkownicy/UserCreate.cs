using Domain;
using Microsoft.AspNetCore.Identity;
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

namespace WinFormsApp85.Forms.Uzytkownicy
{
    public partial class UserCreate : Form
    {
        private ApplicationDbContext _context;


        public UserCreate ()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

            pictureBox1.Paint += (s, e) => e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height)));
        }
         

        private void buttonZapisz_Click (object sender, EventArgs e)
        {
            try
            {
                PasswordHasher <ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser> ();
                ApplicationUser user = new ApplicationUser ()
                {
                    Id = Guid.NewGuid ().ToString (),
                    UserName = textBoxLogin.Text,
                    NormalizedUserName = textBoxLogin.Text.ToUpper(),
                    Imie = textBoxImie.Text,
                    Nazwisko = textBoxNazwisko.Text,
                    Ulica = textBoxUlica.Text,
                    Pesel = textBoxPesel.Text,
                    Miejscowosc = textBoxMiejscowosc.Text,
                    DataUrodzenia = dateTimePickerDataUrodzenia.Value,
                    DataDodania = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, textBoxPassword.Text);
                _context.Users.Add(user);
                _context.SaveChanges();
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
    }
}
