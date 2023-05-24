namespace MooBookopedia.Models
{
    public class Movies_Producer
    {
        public int MoviesId { get; set; }
        
        public Movies Movies { get; set; }

        public int ProducerId { get; set; }

        public MovieProducer MovieProducer { get; set; }
    }
}
