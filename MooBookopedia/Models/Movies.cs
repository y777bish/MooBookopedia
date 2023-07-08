using MooBookopedia.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooBookopedia.Models
{
    public class Movies
    {
        [Key]
        public int MoviesID { get; set; }

        [Display(Name = "Picture")]
        public string MoviePictureURL { get; set; }

        [Display(Name = "Name")]
        public string MovieName { get; set; }

        [Display(Name = "Description")]
        public string MovieDescription { get; set; }
        
        public string MovieReview { get; set; }
        public string MovieNotes { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Movies_Producer> Movies_Producers { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public MovieProducer MovieProducer { get; set; }

        public string Director { get; set; }
        public string Actors { get; set; }
        public int Year { get; set; }

        public string borm { get; set; }
    }
}
