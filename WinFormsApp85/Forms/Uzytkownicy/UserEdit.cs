using Domain;
using Microsoft.AspNetCore.Identity;
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

namespace WinFormsApp85.Forms.Uzytkownicy
{
    public partial class UserEdit : Form
    {
        private ApplicationDbContext _context;
        private ApplicationUser User { get; set; }
        private string UserId { get; set; }


        public UserEdit (string userId)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            UserId = userId;
            User = _context.Users.FirstOrDefault(f => f.Id == UserId);

            pictureBox1.Paint += (s, e) => e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height)));
        }

        private void UserEdit_Load (object sender, EventArgs e)
        {
            if (User != null)
            {
                textBoxImie.Text = User.Imie;
                textBoxNazwisko.Text = User.Nazwisko;
                textBoxUlica.Text = User.Ulica;
                textBoxPesel.Text = User.Pesel;
                textBoxMiejscowosc.Text = User.Miejscowosc;
                dateTimePickerDataUrodzenia.Value = User.DataUrodzenia;
                textBoxUwagi.Text = User.Uwagi;

                textBoxLogin.Text = User.UserName;
                textBoxPassword.Text = User.PasswordHash;
            }
        }

        private void buttonZapisz_Click (object sender, EventArgs e)
        {
            PasswordHasher <ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser> ();
            if (User != null)
            {
                try
                {
                    User.Imie = textBoxImie.Text;
                    User.Nazwisko = textBoxNazwisko.Text;
                    User.Ulica = textBoxUlica.Text;
                    User.Pesel = textBoxPesel.Text;
                    User.Miejscowosc = textBoxMiejscowosc.Text;
                    User.DataUrodzenia = dateTimePickerDataUrodzenia.Value;
                    User.Uwagi = textBoxUwagi.Text;

                    User.UserName = textBoxLogin.Text;
                    User.PasswordHash = passwordHasher.HashPassword(User, textBoxPassword.Text);

                    _context.Entry(User).State = EntityState.Modified;
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
        }

        private void buttonAnuluj_Click (object sender, EventArgs e)
        {
            Close();
        }
    }
}
