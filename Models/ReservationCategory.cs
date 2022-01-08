using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class ReservationCategory
    {
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
