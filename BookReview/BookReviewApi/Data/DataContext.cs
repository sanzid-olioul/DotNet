using Microsoft.EntityFrameworkCore;
using Models;

namespace BookReviewApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Book> Books { get; set; }
    }
}
