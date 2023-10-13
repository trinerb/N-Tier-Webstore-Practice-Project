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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //override default function(onmodelcreating) and expects a model builder. Default function
        {  //default thing implemented by .Net. just using to see data. 
            modelBuilder.Entity<Category>().HasData(  //add new object
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2},
                new Category { Id = 3, Name = "Documentary", DisplayOrder = 3}
                );  //telling entity framework core we want to create these 3 records on category. 
                    //Have to add migration always when updating something to database. "add-migration SeedCategoryTable"
                    //Next "update-database"

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    ISBN = "978-0-340-96019-6",
                    Price = 169,
                    Price50 = 129,
                    Price100 = 99,
                    Description = "Before Matrix, before Star Wars, before Ender's Game and Neuromancer, there was Dune, one of the greatest science fiction novels ever written."
                },

                new Product
                {
                    Id = 2,
                    Title = "Crime and Punishment",
                    Author = "Fyodor Dostoevsky",
                    ISBN = "978-1-78599-644-3",
                    Price = 89,
                    Price50 = 69,
                    Price100 = 55,
                    Description = "Rodion Raskolnikov is a handsome, yet impoverished student. Morally conflicted, he believes that extraordinary men who contribute much to society by their thinking are above the law, and in order to prove his theory, he decides to murder a grasping old money lender and, through unforeseen circumstances, her sister.  "
                },

                new Product
                {
                    Id = 3,
                    Title = "Eat & Run",
                    Author = "Scott Jurek",
                    ISBN = "978-0-544-00231-9",
                    Price = 216,
                    Price50 = 168,
                    Price100 = 128,
                    Description = "Scott Jurek is a world-renowned ultramarathon champion who trains and races on a plant-based diet. He has appeared in two New York Times bestsellers, Born to Run and The 4-Hour Body."
                });
           
        }

    }
}
