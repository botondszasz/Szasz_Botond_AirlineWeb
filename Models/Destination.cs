using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class Destination
    {
        public int ID { get; set; }
        public string DestinationName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
