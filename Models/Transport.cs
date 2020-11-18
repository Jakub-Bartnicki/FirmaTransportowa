using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Transport
    {
        public int TransportID { get; set; }
        public int RouteID { get; set; }
        public int TruckID { get; set; }
        public int EmployeeID { get; set; }
        public int OrderID { get; set; }
        public DateTime DepartureDay { get; set; }

        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual ICollection<Truck> Trucks { get; set; }
        [Required]
        public virtual ICollection<Employee> Employees { get; set; }
        [Required]
        public virtual Route Route { get; set; }
    }
}