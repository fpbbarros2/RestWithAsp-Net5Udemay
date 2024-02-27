using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Models.Base;

namespace RestWithAspNet5UdemayErudio.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
