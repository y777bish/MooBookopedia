using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class AddBookVM
    {
        [Display(Name = "Nazwa filmu")]
        [Required(ErrorMessage = "Nazwa filmu jest konieczna")]
        public string Name { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Nazwisko autora jest konieczne")]
        public string Director { get; set; }

        //[Display(Name = "Actors (use commas)")]
        //[Required(ErrorMessage = "At least one actor is required")]
        //public string Actors { get; set; }

        [Display(Name = "Link do zdjęcia")]
        [Required(ErrorMessage = "Link do zdjęcia jest konieczny")]
        public string ImageLink { get; set; }

        [Display(Name = "Rok publikacji")]
        [Required(ErrorMessage = "Rok publikacji jest konieczny")]
        public int Year { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis jest konieczny")]
        public string Desctiption { get; set; }
    }
}
