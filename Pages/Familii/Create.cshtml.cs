using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;

namespace Agenda_de_produse.Pages.Familii
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
            return Page();
        }

        [BindProperty]
        public Familie Familie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Familie.Add(Familie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
