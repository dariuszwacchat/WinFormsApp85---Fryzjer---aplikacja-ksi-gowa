using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Placa
    {
        public string PlacaId { get; set; }
        private double PlacaNetto { get; set; } 
        private double PlacaPodatek8 { get; set; }
        private double PlacaPodatek22 { get; set; }
        private double PlacaBruttoVat8 { get; set; }
        private double PlacaBruttoVat22 { get; set; }

        private double PremiaNetto { get; set; }
        private double PremiaPodatek8 { get; set; }
        private double PremiaPodatek22 { get; set; }
        private double PremiaBruttoVat8 { get; set; }
        private double PremiaBruttoVat22 { get; set; }
         

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
