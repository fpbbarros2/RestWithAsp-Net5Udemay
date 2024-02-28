using RestWithAspNet5UdemayErudio.Data.Converter.Implemetations;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Repository.Generic;

namespace RestWithAspNet5UdemayErudio.Bussines.Implementation
{
    public class BookBussinesImplementation : IBookBussines
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBussinesImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVo> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVo FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVo Create(BookVo book)
        {
            return _converter.Parse(_repository.Create(_converter.Parse(book)));
        }

        public BookVo Update(BookVo book)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(book)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
