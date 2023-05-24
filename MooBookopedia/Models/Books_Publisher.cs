namespace MooBookopedia.Models
{
    public class Books_Publisher
    {
        public int BooksId { get; set; }

        public Books Books { get; set; }

        public int PublisherId { get; set; }
        
        public BookPublisher BookPublisher { get; set; }
    }
}
