using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Truck
    {
        public int TruckID { get; set; }
        public int SemitrailerID { get; set; }
        public String RegistrationNr { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public DateTime ProductionYear { get; set; }
        public int Mileage { get; set; }
        public String VIN { get; set; }

        public virtual Route Route { get; set; }
        public virtual Transport Transport { get; set; }
        [Required]
        public virtual ICollection<Semitrailer> Semitrailers { get; set; }
    }
}