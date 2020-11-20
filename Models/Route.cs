using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirmaTransportowa.Models
{
    public class Route
    {
        public Int32 RouteID { get; set; }
        public Int32 TruckID { get; set; }
        public Int32 WarehouseID { get; set; }
        public Int32 AddressID { get; set; }
        public Decimal Distance { get; set; }

        public virtual Transport Transport { get; set; }
        [Required]
        public virtual Warehouse Warehouse { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}