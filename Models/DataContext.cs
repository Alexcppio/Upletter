using Microsoft.EntityFrameworkCore;

namespace Upletter.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base (opts) { }

        public DbSet<Word> Words { get; set; }
    }
}
