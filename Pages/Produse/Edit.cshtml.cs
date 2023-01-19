using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;
using System.Security.Policy;

namespace Agenda_de_produse.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public EditModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs =  await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);
            if (produs == null)
            {
                return NotFound();
            }
            Produs = produs;
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            ViewData["FamilieID"] = new SelectList(_context.Set<Familie>(), "ID", "NumeFamilie");
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

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.ID))
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

        private bool ProdusExists(int id)
        {
          return _context.Produs.Any(e => e.ID == id);
        }
    }
}
