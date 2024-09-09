using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Strategies
{
    public class DishSearchByFilterStrategy : IDishSearchByFilterStrategy
    {
        public List<Dish> Search(List<Dish> dishes, string category, string subcategory, string ingredient)
        {
            var query = dishes.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(d => d.DishCategory.Name == category);     
            }
            if (!string.IsNullOrEmpty(subcategory))
            {
                query = query.Where(d => d.DishSubcategory.Name == subcategory);
            }
            if (!string.IsNullOrEmpty(ingredient))
            {
                query = query.Where(d => d.Ingredients.Any(i => i.Name == ingredient));
            }
            var result = query.ToList();
            
            return result;
        }
    }
}