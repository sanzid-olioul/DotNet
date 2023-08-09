using Microsoft.EntityFrameworkCore;
namespace MovieRecord.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; } = null!;
    }
    
}
