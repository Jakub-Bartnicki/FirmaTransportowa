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
        [MaxLength(10)]
        public String RegistrationNr { get; set; }
        [MaxLength(40)]
        public String Brand { get; set; }
        [MaxLength(40)]
        public String Model { get; set; }
        public DateTime ProductionYear { get; set; }
        public int Mileage { get; set; }
        [MaxLength(17)]
        public String VIN { get; set; }

        public virtual Route Route { get; set; }
        public virtual Transport Transport { get; set; }
        [Required]
        public virtual ICollection<Semitrailer> Semitrailers { get; set; }
    }
}