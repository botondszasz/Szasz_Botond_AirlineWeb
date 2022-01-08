using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime ArrivalDate { get; set; }
        public int AirlineID { get; set; }
        public Airline Airline { get; set; }
        [Display(Name = "Category")]
        public ICollection<ReservationCategory> ReservationCategories { get; set; }
        public ICollection<ReservationDetail> ReservationDetails { get; set; }

    }
}
