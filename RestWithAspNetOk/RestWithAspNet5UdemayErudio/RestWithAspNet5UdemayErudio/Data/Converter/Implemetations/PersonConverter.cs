using RestWithAspNet5UdemayErudio.Data.Converter.Contract;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Data.Converter.Implemetations
{
    public class PersonConverter : IParser<PersonVo, Person>, IParser<Person, PersonVo>
    {
        public Person Parse(PersonVo origin)
        {
            if (origin == null)
                return null;


            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
        public PersonVo Parse(Person origin)
        {
            if (origin == null)
                return null;


            return new PersonVo
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonVo> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person> Parse(List<PersonVo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
