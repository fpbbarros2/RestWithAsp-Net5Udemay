using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet5UdemayErudio.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        
            
        public DbSet<Person> person { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
