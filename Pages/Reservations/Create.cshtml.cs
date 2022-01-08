using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szasz_Botond_AirlineWeb.Data;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Pages.Reservations
{
    public class CreateModel : ReservationCategoriesPageModel
    {
        private readonly Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext _context;

        public CreateModel(Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DestinationID"] = new SelectList(_context.Set<Destination>(), "ID", "DestinationName");
            ViewData["AirlineID"] = new SelectList(_context.Set<Airline>(), "ID", "AirlineName");
            var reservation = new Reservation();
            reservation.ReservationCategories = new List<ReservationCategory>();
            PopulateAssignedCategoryData(_context, reservation);
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newReservation = new Reservation();
            if (selectedCategories != null)
            {
                newReservation.ReservationCategories = new List<ReservationCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ReservationCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newReservation.ReservationCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Reservation>(
                newReservation,
                "Reservation",
                i => i.first_name, i => i.last_name,
                i => i.nationality, i => i.DepartureDate, i => i.ArrivalDate, i => i.AirlineID))
            {
                _context.Reservation.Add(newReservation);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newReservation);
            return Page();
        }
    }
}
