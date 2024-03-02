using RestWithAspNet5UdemayErudio.Hypermedia;
using RestWithAspNet5UdemayErudio.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5UdemayErudio.Data.Vo 
{
    public class BookVo : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
