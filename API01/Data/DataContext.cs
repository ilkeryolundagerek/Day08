using API01.Model;
using Microsoft.EntityFrameworkCore;

namespace API01.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
