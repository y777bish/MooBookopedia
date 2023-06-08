using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class AddMovieVM
    {
        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Movie name is required")]
        public string Name { get; set; }

        [Display(Name = "Director name")]
        [Required(ErrorMessage = "Director name is required")]
        public string Director { get; set; }

        [Display(Name = "Actors (use commas)")]
        [Required(ErrorMessage = "At least one actor is required")]
        public string Actors { get; set; }

        [Display(Name = "Year of production")]
        [Required(ErrorMessage = "Year of production is required")]
        public string Year { get; set; }

        [Display(Name = "Desctiption")]
        [Required(ErrorMessage = "Desctiption is required")]
        public string Desctiption { get; set; }
    }
}
