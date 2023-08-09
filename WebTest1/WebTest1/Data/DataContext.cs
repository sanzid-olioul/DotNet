using Microsoft.EntityFrameworkCore;
using WebTest1.Models;

namespace WebTest1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Laptop> Laptops { get; set; }

    }
}
