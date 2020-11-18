using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public int TruckID { get; set; }
        public int LoadingAddressID { get; set; }
        public int DestinationAddressID { get; set; }
        public Decimal Distance { get; set; }

        public virtual Transport Transport { get; set; }
        [Required]
        public virtual ICollection<Address> Addresses { get; set; }
        [Required]
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}