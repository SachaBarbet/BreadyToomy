using BreadyToomy.Models;
using Microsoft.EntityFrameworkCore;

namespace BreadyToomy.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=12345;Database=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

        }

        public void SeedData()
        {
            // Insert sample data into Recipe table
            Recipes.AddRange(
                new Recipe { Difficulty = "EASY", CookTime = 15, Archived = false },
                new Recipe { Difficulty = "MEDIUM", CookTime = 30, Archived = false },
                new Recipe { Difficulty = "HARD", CookTime = 45, Archived = false }
            );

            // Insert sample data into RecipeStep table
            RecipeSteps.AddRange(
                new RecipeStep { RecipeId = 1, Index = 1, StepDetails = "Preheat the oven to 350 degrees F.", Archived = false },
                new RecipeStep { RecipeId = 1, Index = 2, StepDetails = "Mix flour and sugar in a bowl.", Archived = false },
                new RecipeStep { RecipeId = 2, Index = 1, StepDetails = "Boil water in a large pot.", Archived = false },
                new RecipeStep { RecipeId = 2, Index = 2, StepDetails = "Add pasta to the boiling water.", Archived = false },
                new RecipeStep { RecipeId = 3, Index = 1, StepDetails = "Chop vegetables into small pieces.", Archived = false },
                new RecipeStep { RecipeId = 3, Index = 2, StepDetails = "Stir-fry vegetables in a pan.", Archived = false }
            );

            // Insert sample data into Product table
            Products.AddRange(
                new Product { Name = "Spaghetti", Type = "MEAL", Description = "Delicious spaghetti with tomato sauce", Price = 10, Archived = false },
                new Product { Name = "Salad", Type = "MEAL", Description = "Fresh garden salad", Price = 7, Archived = false },
                new Product { Name = "Cake", Type = "DESSERT", Description = "Chocolate cake", Price = 15, Archived = false }
            );

            // Insert sample data into Ingredient table
            Ingredients.AddRange(
                new Ingredient { Name = "Flour", Quantity = 51, Archived = false },
                new Ingredient { Name = "Sugar", Quantity = 54, Archived = false },
                new Ingredient { Name = "Tomato", Quantity = 15, Archived = false },
                new Ingredient { Name = "Lettuce", Quantity = 3, Archived = false },
                new Ingredient { Name = "Pasta", Quantity = 9, Archived = false },
                new Ingredient { Name = "Chocolate", Quantity = 78, Archived = false }
            );

            // Insert sample data into ProductIngredient table
            ProductIngredients.AddRange(
                new ProductIngredient { ProductId = 1, IngredientId = 5, Quantity = 2, Archived = false }, // Spaghetti -> Pasta
                new ProductIngredient { ProductId = 1, IngredientId = 3, Quantity = 3, Archived = false }, // Spaghetti -> Tomato
                new ProductIngredient { ProductId = 2, IngredientId = 4, Quantity = 1, Archived = false }, // Salad -> Lettuce
                new ProductIngredient { ProductId = 3, IngredientId = 1, Quantity = 2, Archived = false }, // Cake -> Flour
                new ProductIngredient { ProductId = 3, IngredientId = 2, Quantity = 1, Archived = false }, // Cake -> Sugar
                new ProductIngredient { ProductId = 3, IngredientId = 6, Quantity = 1, Archived = false }  // Cake -> Chocolate
            );

            // Insert sample data into Order table
            Orders.AddRange(
                new Order { Number = 1001, Type = "ON_SITE", State = "ON_GOING" },
                new Order { Number = 1002, Type = "DELIVERY", State = "DONE" },
                new Order { Number = 1003, Type = "CLICK_AND_COLLECT", State = "SENT" }
            );

            // Insert sample data into OrderProduct table
            OrderProducts.AddRange(
                new OrderProduct { OrderId = 1, ProductId = 1, Quantity = 2 }, // Order 1 -> 2 Spaghetti
                new OrderProduct { OrderId = 1, ProductId = 3, Quantity = 1 }, // Order 1 -> 1 Cake
                new OrderProduct { OrderId = 2, ProductId = 2, Quantity = 3 }, // Order 2 -> 3 Salad
                new OrderProduct { OrderId = 3, ProductId = 1, Quantity = 1 }  // Order 3 -> 1 Spaghetti
            );

            SaveChanges();
        }
    }
}
