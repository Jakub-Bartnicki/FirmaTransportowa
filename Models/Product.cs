using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Product
    {
        public Int32 ProductID { get; set; }
        [MaxLength(60)]
        public String Name { get; set; }
        [MaxLength(255)]
        public String Description { get; set; }
        public Decimal BuyPrice { get; set; }
        public Decimal Weight { get; set; }

        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}