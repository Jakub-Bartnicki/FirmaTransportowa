﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public virtual Warehouse Warehouse { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}