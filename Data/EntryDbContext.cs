using Microsoft.EntityFrameworkCore;
using Tracker.Models;
namespace Tracker.Data
{
    public class EntryDbContext : DbContext
    {
        public EntryDbContext(DbContextOptions<EntryDbContext> options) : base(options)
        {

        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
