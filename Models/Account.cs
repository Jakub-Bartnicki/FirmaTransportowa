using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public String Login { get; set; }
        public DateTime CreationDate { get; set; }
        public String PasswordHash { get; set; }
        public String Email { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Customer Customer { get; set; }
    }
}