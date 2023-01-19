using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Xml.Linq;

namespace Agenda_de_produse.Models
{
    public class Furnizor
    {
        public int ID { get; set; }
        [Display(Name = "Numele furnizorului")]
        public string NumeFurnizor { get; set; }
        public ICollection<Produs>? Produse { get; set; } //navigation property
        [Display(Name = "Tara de origine")]

        public int? TaraID { get; set; }
        public Tara? Tara { get; set; }
    }
}
