using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;

namespace Agenda_de_produse.Pages.Familii
{
    public class DeleteModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public DeleteModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Familie Familie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Familie == null)
            {
                return NotFound();
            }

            var familie = await _context.Familie.FirstOrDefaultAsync(m => m.ID == id);

            if (familie == null)
            {
                return NotFound();
            }
            else 
            {
                Familie = familie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Familie == null)
            {
                return NotFound();
            }
            var familie = await _context.Familie.FindAsync(id);

            if (familie != null)
            {
                Familie = familie;
                _context.Familie.Remove(Familie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
