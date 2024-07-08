using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string Pesel { get; set; }
        public string Miejscowosc { get; set; }
        public double Wydajnosc { get; set; }
        public double PlacaNetto { get; set; }
        public double PlacaBrutto23 { get; set; }
        public string Uwagi { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public DateTime DataDodania { get; set; }



        public List<UserRegister> UserRegisters { get; set; } 
        public List<Placa> Place { get; set; }
        public List<Usluga> Uslugi { get; set; } 

    }
}
