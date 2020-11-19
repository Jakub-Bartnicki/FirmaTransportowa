using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [MaxLength(40)]
        public String Country { get; set; }
        [MaxLength(40)]
        public String PostalCode { get; set; }
        [MaxLength(100)]
        public String City { get; set; }
        [MaxLength(100)]
        public String Street { get; set; }

        public virtual PersonDetails PersonDetails { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Route Route { get; set; }
    }
}