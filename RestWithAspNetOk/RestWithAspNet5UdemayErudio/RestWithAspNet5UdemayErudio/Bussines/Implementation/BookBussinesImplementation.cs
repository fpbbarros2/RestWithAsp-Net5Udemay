using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Repository.Generic;

namespace RestWithAspNet5UdemayErudio.Bussines.Implementation
{
    public class BookBussinesImplementation : IBookBussines
    {
        private readonly IRepository<Book> _repository;

        public BookBussinesImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
