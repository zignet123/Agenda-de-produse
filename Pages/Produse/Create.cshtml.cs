using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;
using System.Security.Policy;

namespace Agenda_de_produse.Pages.Produse
{
    public class CreateModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public CreateModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            ViewData["FamilieID"] = new SelectList(_context.Set<Familie>(), "ID", "NumeFamilie");
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
