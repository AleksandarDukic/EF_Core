using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using System.Net;

namespace PublisherData
{
    public class PubContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }

        static PubContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=PubDatabase;Username=postgres;Password=kiki;timeout=1000;").LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var someArtists = new Artist[]
            {
                new Artist
                {
                    ArtistId = 1,
                    FirstName = "Pablo",
                    LastName = "Picasso"
                },
                new Artist
                {
                    ArtistId = 2,
                    FirstName = "Dee",
                    LastName = "Bell"
                },
                new Artist
                {
                    ArtistId = 3,
                    FirstName = "Katherine",
                    LastName = "Kuharic"
                }
            };
            modelBuilder.Entity<Artist>().HasData(someArtists);

            var someCovers = new Cover[]
            {
                new Cover
                {
                    CoverId = 1,
                    DesignIdeas = "How about left hand in the dark?",
                    DigitalOnly = false,
                },
                new Cover
                {
                    CoverId = 2,
                    DesignIdeas = "Should we put a clock?",
                    DigitalOnly = true,
                },
                new Cover
                {
                    CoverId = 3,
                    DesignIdeas = "A big ear in the clouds?",
                    DigitalOnly = false,
                }
             };
            modelBuilder.Entity<Cover>().HasData(someCovers);


        }




    }
}