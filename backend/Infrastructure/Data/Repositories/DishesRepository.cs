using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly DishesDbContext _context;
        public DishesRepository(DishesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dish>> GetAllDishesAsync()
        {
            var dishes = await _context.Dishes
                .Include(d => d.DishCategory)
                .Include(d => d.DishSubcategory)
                .Include(d => d.DishesIngredients)
                    .ThenInclude(di => di.Ingredient)
                    .ToListAsync();
            return dishes;
        }

        public async Task<List<DishCategory>> GetAllDishCategoriesAsync()
        {
            return await _context.DishCategories.AsNoTracking().ToListAsync();
        }

        public async Task<List<DishSubcategory>> GetAllDishSubcategoriesAsync()
        {
            return await _context.DishSubcategories.AsNoTracking().ToListAsync();
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.AsNoTracking().ToListAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            var dish = await _context.Dishes
                .Include(d => d.DishCategory)
                .Include(d => d.DishSubcategory)
                .Include(d => d.DishesIngredients)
                    .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(d => d.Id == id);
            return dish;
        }
    }
}