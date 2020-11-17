using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class WarehouseProduct
    {
        public int WarehouseProductID { get; set; }
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int QuantityInStock { get; set; }
        public int MaxQuantity { get; set; }
        
        public virtual Warehouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
    }
}