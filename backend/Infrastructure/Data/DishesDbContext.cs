using Core.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DishesDbContext : DbContext
    {
        public DishesDbContext(DbContextOptions<DishesDbContext> options) : base(options)
        {   
        }

        public DbSet<Dish> Dishes { get; set;}
        public DbSet<DishCategory> DishCategories { get; set;}
        public DbSet<DishSubcategory> DishSubcategories { get; set;}
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishesIngredients> DishesIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DishConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}