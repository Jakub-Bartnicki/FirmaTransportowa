using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class PersonDetails
    {
        public int PersonDetailsID { get; set; }
        public int AddressID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Phone { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Employee Employee { get; set; }
    }
}