using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Przerwa
    {
        [Key]
        public string PrzerwaId { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public TimeSpan Lacznie { get; set; }



        public string UserRegisterId { get; set; }
        public UserRegister UserRegister { get; set; }
         
    }
}
