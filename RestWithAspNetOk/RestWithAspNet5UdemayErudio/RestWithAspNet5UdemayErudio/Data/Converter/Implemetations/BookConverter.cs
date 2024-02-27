using RestWithAspNet5UdemayErudio.Data.Converter.Contract;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Data.Converter.Implemetations
{
    public class BookConverter : IParser<BookVo, Book>, IParser<Book, BookVo>
    {
        public BookVo Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVo { 
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title

            };
        }



        public Book Parse(BookVo origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title

            };
        }

        public List<BookVo> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();

        }

        public List<Book> Parse(List<BookVo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
