using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Bussines
{
    public interface IPersonBussines
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
