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

namespace Agenda_de_produse.Pages.Furnizori
{
    public class EditModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public EditModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Furnizor Furnizor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }

            var furnizor =  await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);
            if (furnizor == null)
            {
                return NotFound();
            }
            Furnizor = furnizor;
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID", "NumeTara");
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

            _context.Attach(Furnizor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnizorExists(Furnizor.ID))
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

        private bool FurnizorExists(int id)
        {
          return _context.Furnizor.Any(e => e.ID == id);
        }
    }
}
