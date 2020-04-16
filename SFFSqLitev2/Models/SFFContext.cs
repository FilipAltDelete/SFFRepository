using Microsoft.EntityFrameworkCore;
using SFFSqLite.Models;

namespace SFFSqLite.Models
{
    public class SFFContext : DbContext
    {
        public SFFContext(DbContextOptions<SFFContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RentedMovie> RentedMovies { get; set; }
        public DbSet<Trivia> Trivias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=SFFDB.db;");
        }

        
    }
}