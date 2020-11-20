using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Customer
    {
        public Int32 CustomerID { get; set; }
        [Required]
        public Int32 PersonDetailsID { get; set; }
        public Int32 AccountID { get; set; }
        [MaxLength(20)]
        public String Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual PersonDetails PersonDetails { get; set; }
        [Required]
        public virtual Account Account { get; set; }
    }
}