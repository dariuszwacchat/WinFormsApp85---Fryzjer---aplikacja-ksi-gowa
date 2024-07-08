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

namespace WinFormsApp85.Forms.Przerwy
{
    public partial class PrzerwaCreate : Form
    {
        private ApplicationDbContext _context;
        private Random _rand = new Random ();


        public PrzerwaCreate ()
        {
            InitializeComponent();
            _context = new ApplicationDbContext ();
        }

        private void buttonZapisz_Click (object sender, EventArgs e)
        {
            Przerwa przerwa = new Przerwa()
            {
                PrzerwaId = Guid.NewGuid ().ToString (),
                Od = DateTime.Now,
                Do = DateTime.Now.AddMinutes (_rand.Next (10,20)),
                Lacznie = new TimeSpan (0,_rand.Next(10,30), _rand.Next(1,59)),
                UserRegisterId = LoginService.UserRegister.UserRegisterId
            };
            _context.Przerwy.Add (przerwa);
            _context.SaveChanges (); 
        }
    }
}
