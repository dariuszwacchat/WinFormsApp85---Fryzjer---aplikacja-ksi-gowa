using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usluga
    {
        [Key]
        public string UslugaId { get; set; } 
        public double CenaNetto { get; set; }
        public double Vat8 { get; set; }
        public double Vat22 { get; set; }
        public double ZyskBrutto8 { get; set; }
        public double ZyskBrutto22 { get; set; }
        public DateTime DataWykonania { get; set; }
        public DateTime DataDodania { get; set; }


        public string RodzajUslugiId { get; set; }
        public RodzajUslugi RodzajUslugi { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
