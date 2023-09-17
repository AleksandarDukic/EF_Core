using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using System.Net;

namespace PublisherData
{
    public class PubContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=PubDatabase;Username=postgres;Password=kiki;timeout=1000;");
        }
    }
}