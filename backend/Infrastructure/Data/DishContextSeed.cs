using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class DishContextSeed
    {
        public static async Task SeedAsync(DishesDbContext context){
            try{
                if(!context.DishCategories.Any()){
                    var dishCategoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/DishCategories.json");
                    var dishCategories = JsonSerializer.Deserialize<List<DishCategory>>(dishCategoriesData);
                    foreach (var dishCategory in dishCategories)
                    {
                        context.Add(dishCategory);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.DishSubcategories.Any()){
                    var dishSubcategoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/DishSubcategories.json");
                    var dishSubcategories = JsonSerializer.Deserialize<List<DishSubcategory>>(dishSubcategoriesData);
                    foreach (var dishSubcategory in dishSubcategories)
                    {
                        context.Add(dishSubcategory);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Ingredients.Any()){
                    var ingredientsData = File.ReadAllText("../Infrastructure/Data/SeedData/Ingredients.json");
                    var ingredients = JsonSerializer.Deserialize<List<Ingredient>>(ingredientsData);
                    foreach (var ingredient in ingredients)
                    {
                        context.Add(ingredient);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Dishes.Any()){
                    var dishesData = File.ReadAllText("../Infrastructure/Data/SeedData/Dishes.json");
                    var dishes = JsonSerializer.Deserialize<List<Dish>>(dishesData);
                    foreach (var dish in dishes)
                    {
                        context.Add(dish);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.DishesIngredients.Any()){
                    var dishesIngredientsData = File.ReadAllText("../Infrastructure/Data/SeedData/DishesIngredients.json");
                    var dishesIngredients = JsonSerializer.Deserialize<List<DishesIngredients>>(dishesIngredientsData);
                    foreach (var dishesIngredient in dishesIngredients)
                    {
                        context.Add(dishesIngredient);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch{}
        }
    }
}