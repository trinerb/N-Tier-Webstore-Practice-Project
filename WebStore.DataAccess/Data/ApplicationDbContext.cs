using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //passing configuration the the dbcontext class.options we configure here will then be passsed on to the Dbcontext class(built-in class)
        {

                
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //override default function(onmodelcreating) and expects a model builder. Default function
        {  //default thing implemented by .Net. just using to see data. 
            modelBuilder.Entity<Category>().HasData(  //add new object
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2},
                new Category { Id = 3, Name = "Documentary", DisplayOrder = 3}
                );  //telling entity framework core we want to create these 3 records on category. 
                   //Have to add migration always when updating something to database. "add-migration SeedCategoryTable"
                   //Next "update-database"
        }

    }
}
