using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Account
    {
        public Int32 AccountID { get; set; }
        [MaxLength(50)]
        public String Login { get; set; }
        public DateTime CreationDate { get; set; }
        [MaxLength(255)]
        public String PasswordHash { get; set; }
        [MaxLength(255)]
        public String Email { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Customer Customer { get; set; }
    }
}