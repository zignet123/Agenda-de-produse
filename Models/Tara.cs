using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Agenda_de_produse.Models
{
    public class Tara
    {
        public int ID { get; set; }
        [Display(Name = "Denumirea tarii")]
        public string NumeTara { get; set; }

        public ICollection<Furnizor>? Furnizori { get; set; } //navigation property
    }
}
