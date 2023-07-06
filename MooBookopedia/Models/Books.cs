using MooBookopedia.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooBookopedia.Models
{
    public class Books
    {
        [Key]
        public int BooksID { get; set; }

        [Display(Name = "Name")]
        public string BookName { get; set; }

        [Display(Name = "Description")]
        public string BookDescription { get; set; }

        [Display(Name = "Picture")]
        public string BookPictureURL { get; set; }
        public string BookReview { get; set; }
        public string BookNotes { get; set; }
        public BooksCategory BooksCategory { get; set; }

        //Relationships
        public List<Books_Publisher> Books_Publishers { get; set; }

        //Producer
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public BookPublisher BookPublisher { get; set; }
    }
}
