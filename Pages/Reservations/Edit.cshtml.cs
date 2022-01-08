using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szasz_Botond_AirlineWeb.Data;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Pages.Reservations
{
    public class EditModel : ReservationCategoriesPageModel, ReservationDetailsPageModel
    {
        private readonly Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext _context;

        public EditModel(Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservation
                .Include(b => b.Airline)
                .Include(b => b.ReservationCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Reservation);
            ViewData["AirlineID"] = new SelectList(_context.Set<Airline>(), "ID", "AirlineName");
            ViewData["DestinationID"] = new SelectList(_context.Set<Destination>(), "ID", "DestinationName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservationToUpdate = await _context.Reservation
            .Include(i => i.Airline)
            .Include(i => i.ReservationCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (reservationToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Reservation>(
            reservationToUpdate,
            "Reservation",
            i => i.first_name, i => i.last_name,
            i => i.nationality, i => i.DepartureDate, i => i.ArrivalDate, i => i.Airline))
            {
                UpdateReservationCategories(_context, selectedCategories, reservationToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateReservationCategories(_context, selectedCategories, reservationToUpdate);
            PopulateAssignedCategoryData(_context, reservationToUpdate);
            return Page();
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ID == id);
        }
    }
}
