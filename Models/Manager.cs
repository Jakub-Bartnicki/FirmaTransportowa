using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Manager
    {
        public Int32 ManagerID { get; set; }
        public Int32 PersonDetailsID { get; set; }
        public Int32 AccountID { get; set; }

        [Required]
        public virtual PersonDetails PersonDetails { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}