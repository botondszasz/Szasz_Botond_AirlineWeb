﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szasz_Botond_AirlineWeb.Data;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Pages.Airlines
{
    public class EditModel : PageModel
    {
        private readonly Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext _context;

        public EditModel(Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Airline Airline { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airline = await _context.Airline.FirstOrDefaultAsync(m => m.ID == id);

            if (Airline == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Airline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(Airline.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AirlineExists(int id)
        {
            return _context.Airline.Any(e => e.ID == id);
        }
    }
}
