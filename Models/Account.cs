using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Account
    {
        public Int32 AccountID { get; set; }
        [Required]
        [MaxLength(50)]
        public String Login { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        [MaxLength(255)]
        public String PasswordHash { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public String Email { get; set; }

        [NotMapped]
        [Required]
        [Compare("PasswordHash")]
        public string ConfirmPassword { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
