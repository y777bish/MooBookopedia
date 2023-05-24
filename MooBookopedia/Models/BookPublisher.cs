using System.ComponentModel.DataAnnotations;

namespace MooBookopedia.Models
{
    public class BookPublisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Books> Books { get; set; }
    }
}
