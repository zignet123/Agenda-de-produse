using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Agenda_de_produse.Models
{
    public class Familie
    {
        public int ID { get; set; }
        [Display(Name = "Familia de produse")]
        public string NumeFamilie { get; set; }

        public ICollection<Produs>? Produse { get; set; } //navigation property
    }
}
