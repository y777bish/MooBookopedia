using MooBookopedia.Data;
using System.ComponentModel.DataAnnotations;

namespace MooBookopedia.Models
{
    public class Books
    {
        [Key]
        public int BooksID { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookPictureURL { get; set; }
        public string BookReview { get; set; }
        public string BookNotes { get; set; }
        public BooksCategory BooksCategory { get; set; }
    }
}
