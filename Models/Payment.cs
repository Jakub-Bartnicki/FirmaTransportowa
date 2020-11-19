using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Payment
    {
        [MaxLength(255)]
        public String PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public Decimal Amount { get; set; }

        [Required]
        public virtual Order Order { get; set; }
    }
}