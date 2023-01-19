using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;

namespace Agenda_de_produse.Pages.Furnizori
{
    public class DetailsModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public DetailsModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

      public Furnizor Furnizor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }

            var furnizor = await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);
            if (furnizor == null)
            {
                return NotFound();
            }
            else 
            {
                Furnizor = furnizor;
            }
            return Page();
        }
    }
}
