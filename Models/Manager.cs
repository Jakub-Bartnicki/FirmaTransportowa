using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public int PersonDetailsID { get; set; }
        public int AccountID { get; set; }

        [Required]
        public virtual PersonDetails PersonDetails { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}