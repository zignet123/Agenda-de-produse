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
    public class IndexModel : PageModel
    {
        private readonly Agenda_de_produse.Data.Agenda_de_produseContext _context;

        public IndexModel(Agenda_de_produse.Data.Agenda_de_produseContext context)
        {
            _context = context;
        }

        public IList<Furnizor> Furnizor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Furnizor != null)
            //{
                Furnizor = await _context.Furnizor
                .Include(b => b.Tara)
                .ToListAsync();
            //}
        }
    }
}
