using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.Entities;

namespace StackOverflowAPI.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(
            DbContextOptions<AppDbContext> options ) : base( options ) { }
       


        public DbSet<User> users { get; set; }  
        public DbSet <Question> questions { get; set; }
        
        public DbSet<Answer> answers { get; set; }

        public DbSet<Vote> votes { get; set; }


        public DbSet<Comment> comments { get; set; }
    }
}
