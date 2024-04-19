using Microsoft.EntityFrameworkCore;

namespace Mission6_Hull.Models
{
    public class CollectionFormContext : DbContext //Liaison from the app to the database
    {
        public CollectionFormContext(DbContextOptions<CollectionFormContext> options) : base(options) //Constructor
        {
        }

        //get and set movies data to Form class
        public DbSet<Form> Movies { get; set; }
        //get and set Categories data to Category class
        public DbSet<Category> Categories { get; set; }

        //seeding the Category table with some initial categories
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" });
        }
    }
}