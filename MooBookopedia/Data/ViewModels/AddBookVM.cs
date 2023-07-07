using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MooBookopedia.Data.ViewModels
{
    public class AddBookVM
    {
        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Movie name is required")]
        public string Name { get; set; }

        [Display(Name = "Authors name")]
        [Required(ErrorMessage = "Director name is required")]
        public string Director { get; set; }

        //[Display(Name = "Actors (use commas)")]
        //[Required(ErrorMessage = "At least one actor is required")]
        //public string Actors { get; set; }

        [Display(Name = "Image link")]
        [Required(ErrorMessage = "Image link is required")]
        public string ImageLink { get; set; }

        [Display(Name = "Publication date")]
        [Required(ErrorMessage = "Year of production is required")]
        public int Year { get; set; }

        [Display(Name = "Desctiption")]
        [Required(ErrorMessage = "Desctiption is required")]
        public string Desctiption { get; set; }
    }
}
