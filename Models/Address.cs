using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public String Country { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }
        public String Street { get; set; }

        public virtual PersonDetails PersonDetails { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Route Route { get; set; }
    }
}