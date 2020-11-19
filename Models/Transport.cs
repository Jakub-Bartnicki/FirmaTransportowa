using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Transport
    {
        public Int32 TransportID { get; set; }
        public Int32 RouteID { get; set; }
        public Int32 TruckID { get; set; }
        public Int32 EmployeeID { get; set; }
        public Int32 OrderID { get; set; }
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