using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class Detail
    {
        public int ID { get; set; }
        public string DetailName { get; set; }
        public ICollection<ReservationDetail> ReservationDetails { get; set; }
    }
}
