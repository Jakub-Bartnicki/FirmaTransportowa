using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public String Status { get; set; }
        public String Comments { get; set; }
        public Decimal Price { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Transport Transport { get; set; }
    }
}