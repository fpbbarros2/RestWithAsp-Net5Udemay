using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet5UdemayErudio.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        
            
        public DbSet<Person> people { get; set; }
    }
}
