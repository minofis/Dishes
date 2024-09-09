using Core.Entities;

namespace Core.Interfaces
{
    public interface IDishesRepository
    {
        Task<List<Dish>> GetAllDishesAsync();
        Task<Dish> GetDishByIdAsync(int id);
        Task<List<DishCategory>> GetAllDishCategoriesAsync();
        Task<List<DishSubcategory>> GetAllDishSubcategoriesAsync();
        Task<List<Ingredient>> GetAllIngredientsAsync();
    }
}