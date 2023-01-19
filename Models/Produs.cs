using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Agenda_de_produse.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Display(Name = "Denumirea produsului")]
        public string Denumire { get; set; }
        [Display(Name = "Pret unitar")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PretUnitar { get; set; }
        [Display(Name = "Data de expirare")]
        [DataType(DataType.Date)]
        public DateTime DataExp { get; set; }
        public int? FurnizorID { get; set; }
        public Furnizor? Furnizor { get; set; } //navigation property
        public int? FamilieID { get; set; }
        public Familie? Familie { get; set; }
    }
}

