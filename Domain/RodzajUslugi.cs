﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RodzajUslugi
    {
        [Key]
        public string RodzajUslugiId { get; set; }
        public string Nazwa { get; set; }
        public double CenaNetto { get; set; }


        public List <Usluga> Uslugi { get; set; }
    }
}
