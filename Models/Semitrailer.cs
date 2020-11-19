using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Semitrailer
    {
        public Int32 SemitrailerID { get; set; }
        [MaxLength(10)]
        public String RegistrationNr { get; set; }
        public Decimal Capacity { get; set; }

        public virtual Truck Truck { get; set; }
    }
}