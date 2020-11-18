using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}