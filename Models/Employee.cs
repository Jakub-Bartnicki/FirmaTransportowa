using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Employee
    {
        public Int32 EmployeeID { get; set; }
        public Int32 ManagerID { get; set; }
        public Int32 PersonDetailsID { get; set; }
        public Int32 AccountID { get; set; }
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