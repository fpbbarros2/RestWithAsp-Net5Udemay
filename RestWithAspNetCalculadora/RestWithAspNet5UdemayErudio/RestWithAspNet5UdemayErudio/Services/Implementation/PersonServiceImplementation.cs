using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Services.Implementation
{
    public class PersonServiceImplementation : IPersonServices
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i); 


                people.Add(person);
            }

            return people;
        }

        public Person FindByID(long id)
        {
            return new Person
            { Id = IncrementAndGet(), FirstName = "Fábio", Address = "Amargosa", Gender = "Male", lastName = "Barros" };
        }

        public Person Update(Person person)
        {


            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            { Id = IncrementAndGet(), FirstName = "Person FirstName "  + i,  Address = "Person Address " + i, Gender = "Person Gender " + i, lastName = "Person lastName " + i };
        }

        private long IncrementAndGet()
        {
             
            return Interlocked.Increment(ref count);
        }
    }
}
