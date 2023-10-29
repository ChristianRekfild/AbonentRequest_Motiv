using Microsoft.EntityFrameworkCore;

namespace motiv.Models
{
    public class Context : DbContext
    {
        public DbSet<AbonentRequest> AbonentRequests { get; set; } = null!;
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
