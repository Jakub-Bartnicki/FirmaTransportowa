using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
        public int PersonDetailsID { get; set; }
        public int AccountID { get; set; }
        [MaxLength(100)]
        public String JobTitle { get; set; }
        public Decimal Salary { get; set; }

        [Required]
        public virtual Account Account { get; set; }
        public virtual Transport Transport { get; set; }
        [Required]
        public virtual PersonDetails PersonDetails { get; set; }
        [Required]
        public virtual Manager Manager { get; set; }
    }
}