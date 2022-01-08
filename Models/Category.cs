﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szasz_Botond_AirlineWeb.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ReservationCategory> ReservationCategories { get; set; }
    }
}
