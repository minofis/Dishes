using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .HasOne(d => d.DishCategory)
                .WithMany()
                .HasForeignKey(d => d.DishCategoryId);

            builder
                .HasOne(d => d.DishSubcategory)
                .WithMany()
                .HasForeignKey(d => d.DishSubcategoryId);

            builder
                .HasMany(d => d.Ingredients)
                .WithMany()
                .UsingEntity<DishesIngredients>(
                    i => i
                        .HasOne(di => di.Ingredient)
                        .WithMany(i => i.DishesIngredients)
                        .HasForeignKey(di => di.IngredientId),
                    d => d
                        .HasOne(di => di.Dish)
                        .WithMany(d => d.DishesIngredients)
                        .HasForeignKey(di => di.DishId)
                );
        }
    }
}