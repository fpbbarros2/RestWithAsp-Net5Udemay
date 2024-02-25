using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithAspNet5UdemayErudio.Models;
using RestWithAspNet5UdemayErudio.Models.Context;
using System;

namespace RestWithAspNet5UdemayErudio.Repository.Implementation
{
    public class BookRepositoryImplementation : IBookRepository
    {

        private MySqlContext _mySqlContext;

        public BookRepositoryImplementation(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public Book Create(Book book)
        {

            try
            {
                _mySqlContext.books.Add(book);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _mySqlContext.books.FirstOrDefault(e => e.Id.Equals(id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.books.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }




        }

        public List<Book> FindAll()
        {
            return _mySqlContext.books.ToList();
        }

        public Book FindByID(long id)
        {

            return _mySqlContext.books.SingleOrDefault(e => e.Id.Equals(id));

        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id))
                return null;

            var result = _mySqlContext.books.FirstOrDefault(e => e.Id.Equals(book.Id));

            if (result != null)
            {

                try
                {
                    _mySqlContext.books.Entry(result).CurrentValues.SetValues(book);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return book;
        }

        public bool Exists(long id)
        {
            return _mySqlContext.books.Any(e => e.Id.Equals(id));
        }
    }
}
