using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public int AddressID { get; set; }

        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }
}