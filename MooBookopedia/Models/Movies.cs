using MooBookopedia.Data;
using System.ComponentModel.DataAnnotations;

namespace MooBookopedia.Models
{
    public class Movies
    {
        [Key]
        public int MoviesID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MoviePictureURL { get; set; }
        public string MovieReview { get; set; }
        public string MovieNotes { get; set; }
        public MovieCategory MovieCategory { get; set; }
    }
}
