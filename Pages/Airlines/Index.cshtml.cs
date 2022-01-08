﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szasz_Botond_AirlineWeb.Data;
using Szasz_Botond_AirlineWeb.Models;

namespace Szasz_Botond_AirlineWeb.Pages.Airlines
{
    public class IndexModel : PageModel
    {
        private readonly Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext _context;

        public IndexModel(Szasz_Botond_AirlineWeb.Data.Szasz_Botond_AirlineWebContext context)
        {
            _context = context;
        }

        public IList<Airline> Airline { get;set; }

        public async Task OnGetAsync()
        {
            Airline = await _context.Airline.ToListAsync();
        }
    }
}