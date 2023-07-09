using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class AddMovieVM
    {
        [Display(Name = "Nazwa filmu")]
        [Required(ErrorMessage = "Nazwa filmu jest konieczna")]
        public string Name { get; set; }

        [Display(Name = "Reżyser")]
        [Required(ErrorMessage = "Reżyser jest konieczny")]
        public string Director { get; set; }

        [Display(Name = "Aktorzy")]
        [Required(ErrorMessage = "Przynajmniej jeden aktor jest wymagany")]
        public string Actors { get; set; }

        [Display(Name = "Link do zdjęcia")]
        [Required(ErrorMessage = "Link do zdjęcia jest konieczny")]
        public string ImageLink { get; set; }

        [Display(Name = "Rok produkcji")]
        [Required(ErrorMessage = "Rok produkcji jest konieczny")]
        public int Year { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest konieczny")]
        public string Desctiption { get; set; }
    }
}
