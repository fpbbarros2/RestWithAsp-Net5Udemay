using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Models.Context;
using System;

namespace RestWithAspNet5UdemayErudio.Services.Implementation
{
    public class PersonServiceImplementation : IPersonServices
    {



        private volatile int count;
        private MySqlContext _mySqlContext;

        public PersonServiceImplementation(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public Person Create(Person person)
        {

            try
            {
                _mySqlContext.people.Add(person);
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
            var result = _mySqlContext.people.FirstOrDefault(e => e.Id.Equals(id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.people.Remove(result);
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
            return _mySqlContext.people.ToList();
        }

        public Person FindByID(long id)
        {
            return _mySqlContext.people.SingleOrDefault(e => e.Id.Equals(id)) ?? null;

        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return new Person();

            var result = _mySqlContext.people.FirstOrDefault(e => e.Id.Equals(person.Id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.people.Entry(result).CurrentValues.SetValues(person);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return person;
        }

        private bool Exists(long id)
        {
            return _mySqlContext.people.Any(e => e.Id.Equals(id));
        }
    }
}
