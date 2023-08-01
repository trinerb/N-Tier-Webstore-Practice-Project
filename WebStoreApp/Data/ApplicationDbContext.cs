using Microsoft.EntityFrameworkCore;
using WebStoreApp.Models;

namespace WebStoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //passing configuration the the dbcontext class.options we configure here will then be passsed on to the Dbcontext class(built-in class)
        {

                
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2},
                new Category { Id = 3, Name = "Documentary", DisplayOrder = 3}
                );
        }

    }
}
