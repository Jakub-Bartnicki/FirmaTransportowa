using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class OrderProduct
    {
        public Int32 OrderProductID { get; set; }
        public Int32 OrderID { get; set; }
        public Int32 ProductID { get; set; }
        public Int32 Quantity { get; set; }

        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}