using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Bussines
{
    public interface IBookBussines
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
