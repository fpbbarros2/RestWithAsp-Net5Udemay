using RestWithAspNet5UdemayErudio.Data.Converter.Implemetations;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Repository.Generic;

namespace RestWithAspNet5UdemayErudio.Bussines.Implementation
{
    public class PersonBussinesImplementation : IPersonBussines
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBussinesImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVo> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVo FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PersonVo Create(PersonVo person)
        {
            return _converter.Parse(_repository.Create(_converter.Parse(person)));
        }

        public PersonVo Update(PersonVo person)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(person)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
