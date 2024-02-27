using Microsoft.EntityFrameworkCore;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Models.Base;
using RestWithAspNet5UdemayErudio.Models.Context;

namespace RestWithAspNet5UdemayErudio.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _mySqlContext;
        private DbSet<T> dataset;
        public GenericRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            dataset = _mySqlContext.Set<T>();

        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _mySqlContext.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Delete(long id)
        {
            var result = dataset.FirstOrDefault(e => e.Id.Equals(id));

            if (result != null)
            {

                try
                {
                    dataset.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }



        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(e => e.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = dataset.FirstOrDefault(e => e.Id.Equals(item.Id));

            if (result != null)
            {

                try
                {
                    dataset.Entry(result).CurrentValues.SetValues(item);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return null;
            }

            return item;
        }

        public bool Exists(long id)
        {
            return dataset.Any(e => e.Id.Equals(id));
        }
    }
}
