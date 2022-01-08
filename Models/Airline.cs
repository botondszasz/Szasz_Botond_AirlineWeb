using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class Airline
    {
        public int ID { get; set; }
        public string AirlineName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
