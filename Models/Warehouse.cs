using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Warehouse
    {
        public Int32 WarehouseID { get; set; }
        public Int32 AddressID { get; set; }

        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        public virtual Route Route { get; set; }
    }
}