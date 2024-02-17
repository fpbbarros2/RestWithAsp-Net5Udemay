using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
