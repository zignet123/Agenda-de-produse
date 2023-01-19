using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda_de_produse.Data;
using Agenda_de_produse.Models;

namespace Agenda_de_produse.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public IndexModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Produs != null)
            //{
            Produs = await _context.Produs
            .Include(b => b.Furnizor)
            .ToListAsync();

            Produs = await _context.Produs
            .Include(b => b.Familie)
            .ToListAsync();
            //}
        }
    }
}
