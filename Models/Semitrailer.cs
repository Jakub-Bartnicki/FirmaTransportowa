using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Semitrailer
    {
        public int SemitrailerID { get; set; }
        public String RegistrationNr { get; set; }
        public Decimal Capacity { get; set; }

        public virtual Truck Truck { get; set; }
    }
}