using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class WarehouseProduct
    {
        public Int32 WarehouseProductID { get; set; }
        public Int32 WarehouseID { get; set; }
        public Int32 ProductID { get; set; }
        public Int32 QuantityInStock { get; set; }
        public Int32 MaxQuantity { get; set; }

        [Required]
        public virtual Warehouse Warehouse { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}