using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Bussines
{
    public interface IBookBussines
    {
        BookVo Create(BookVo book);
        BookVo FindByID(long id);
        List<BookVo> FindAll();
        BookVo Update(BookVo book);
        void Delete(long id);
    }
}
