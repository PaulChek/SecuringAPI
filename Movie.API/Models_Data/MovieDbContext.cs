using Microsoft.EntityFrameworkCore;

namespace Movie.API.Models_Data {
    public class MovieDbContext : DbContext {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
