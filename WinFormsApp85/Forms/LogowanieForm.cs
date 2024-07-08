using Business;
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

namespace WinFormsApp85.Forms
{
    public partial class LogowanieForm : Form
    {
        private ApplicationDbContext _context;
        private LoginService _loginService;
        public LogowanieForm ()
        {
            InitializeComponent();
            _context = new ApplicationDbContext ();
            _loginService = new LoginService ();

            comboBox1.DataSource = _context.Users.Select(s=> s.UserName).ToList ();
        }


        private void button1_Click (object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;

            if (!string.IsNullOrEmpty(textBoxHaslo.Text))
            {
                try
                {
                    if (_loginService.Zaloguj(comboBox1.SelectedItem.ToString(), textBoxHaslo.Text))
                    {
                        Visible = false;

                        // Sprawdzenie roli zalogowanego użytkownika i skierowanie go w odpowiednie miejsce
                        Form1 form = new Form1 ();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Błędny login lub hasło");
                        textBoxHaslo.Text = "";
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Wprowadź dane do logowania");
            }

            button1.Enabled = true;
            Cursor = Cursors.Default;

        }

        private void button2_Click (object sender, EventArgs e)
        {
            Close();
        }

        private void LogowanieForm_Load (object sender, EventArgs e)
        {

        }
    }
}
