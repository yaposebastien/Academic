using Microsoft.EntityFrameworkCore;

namespace RazorMovieApp.Models
{
    public class RazorMovieAppContext : DbContext
    {
        public RazorMovieAppContext (DbContextOptions<RazorMovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMovieApp.Models.Movie> Movie { get; set; }
    }
}