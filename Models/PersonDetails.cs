using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class PersonDetails
    {
        public Int32 PersonDetailsID { get; set; }
        public Int32 AddressID { get; set; }
        [MaxLength(60)]
        public String FirstName { get; set; }
        [MaxLength(60)]
        public String LastName { get; set; }
        public Int32 Phone { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Employee Employee { get; set; }
    }
}