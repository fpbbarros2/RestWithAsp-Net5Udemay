using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5UdemayErudio.Data.Vo
{
    public class BookVo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
