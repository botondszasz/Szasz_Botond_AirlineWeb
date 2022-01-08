using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Data
{
    public class Szasz_Botond_AirlineWebContext : DbContext
    {
        public Szasz_Botond_AirlineWebContext (DbContextOptions<Szasz_Botond_AirlineWebContext> options)
            : base(options)
        {
        }

        public DbSet<Szasz_Botond_AirlineWeb.Models.Reservation> Reservation { get; set; }

        public DbSet<Szasz_Botond_AirlineWeb.Models.Airline> Airline { get; set; }

        public DbSet<Szasz_Botond_AirlineWeb.Models.Category> Category { get; set; }

        public DbSet<Szasz_Botond_AirlineWeb.Models.Destination> Destination { get; set; }

        public DbSet<Szasz_Botond_AirlineWeb.Models.Detail> Detail { get; set; }
    }
}
