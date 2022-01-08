using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szasz_Botond_AirlineWeb.Data;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext _context;

        public IndexModel(Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }
        public ReservationData ReservationD { get; set; }
        public int ReservationID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ReservationD = new ReservationData();

            ReservationD.Reservations = await _context.Reservation
            .Include(b => b.Airline)
            .Include(b => b.Destination)
            .Include(b => b.ReservationCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.first_name)
            .ToListAsync();
            if (id != null)
            {
                ReservationID = id.Value;
                Reservation reservation = ReservationD.Reservations
                .Where(i => i.ID == id.Value).Single();
                ReservationD.Categories = reservation.ReservationCategories.Select(s => s.Category);
            }
        }
    }
}

