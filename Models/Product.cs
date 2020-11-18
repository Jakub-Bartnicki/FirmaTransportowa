using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal BuyPrice { get; set; }
        public Decimal Weight { get; set; }

        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}