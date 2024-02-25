using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Models.Context;
using System;

namespace RestWithAspNet5UdemayErudio.Repository.Implementation
{
    public class PersonRepositoryImplementation : IPersonRepository
    {



        private volatile int count;
        private MySqlContext _mySqlContext;

        public PersonRepositoryImplementation(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public Person Create(Person person)
        {

            try
            {
                _mySqlContext.person.Add(person);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _mySqlContext.person.FirstOrDefault(e => e.Id.Equals(id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.person.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }




        }

        public List<Person> FindAll()
        {
            return _mySqlContext.person.ToList();
        }

        public Person FindByID(long id)
        {
            return _mySqlContext.person.SingleOrDefault(e => e.Id.Equals(id)) ?? null;

        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return null;

            var result = _mySqlContext.person.FirstOrDefault(e => e.Id.Equals(person.Id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.person.Entry(result).CurrentValues.SetValues(person);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return person;
        }

        public bool Exists(long id)
        {
            return _mySqlContext.person.Any(e => e.Id.Equals(id));
        }
    }
}
