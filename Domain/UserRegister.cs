using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRegister
    {
        [Key]
        public string UserRegisterId { get; set; }
        public DateTime DataZalogowania { get; set; }
        public DateTime DataWylogowania { get; set; }
        public TimeSpan CzasPracy { get; set; }
        public string Uwagi { get; set; }



        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public List <Przerwa> Przerwy { get; set; } 
    }
}
