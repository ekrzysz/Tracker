using Microsoft.EntityFrameworkCore;
using Tracker.Models;
namespace Tracker.Data
{
    public class EntriesDbContext : DbContext
    {
        public EntriesDbContext(DbContextOptions<EntriesDbContext> options) : base(options)
        {

        }

        public DbSet<Entries> Entries { get; set; } 
    }
}
