using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class ReservationData
    {
        public IEnumerable<Reservation> Reservations{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ReservationCategory> ReservationCategories { get; set; }
    }
}
