using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agenda_de_produse.Models;

namespace Agenda_de_produse.Data
{
    public class Agenda_de_produseContext : DbContext
    {
        public Agenda_de_produseContext (DbContextOptions<Agenda_de_produseContext> options)
            : base(options)
        {
        }

        public DbSet<Agenda_de_produse.Models.Produs> Produs { get; set; } = default!;

        public DbSet<Agenda_de_produse.Models.Furnizor> Furnizor { get; set; }

        public DbSet<Agenda_de_produse.Models.Tara> Tara { get; set; }

        public DbSet<Agenda_de_produse.Models.Familie> Familie { get; set; }
    }
}
