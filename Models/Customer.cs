using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int PersonDetailsID { get; set; }
        public int AccountID { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        [Required]
        public virtual PersonDetails PersonDetails { get; set; }
        [Required]
        public virtual Account Account { get; set; }
    }
}