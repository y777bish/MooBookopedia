using System.ComponentModel.DataAnnotations;

namespace MooBookopedia.Models
{
    public class MovieProducer
    {
        [Key]
        public int ProducerId { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Movies> Movies { get; set; }
    }
}
