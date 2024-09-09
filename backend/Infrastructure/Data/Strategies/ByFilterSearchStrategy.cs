using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Strategies
{
    public class DishSearchByFilterStrategy : IDishSearchByFilterStrategy
    {
        public List<Dish> Search(List<Dish> dishes, IFilterDataDto filterData)
        {
            var query = dishes.AsQueryable();
            if (!string.IsNullOrEmpty(filterData.Category))
            {
                query = query.Where(d => d.DishCategory.Name == filterData.Category); 
            }
            if (!string.IsNullOrEmpty(filterData.Subcategory))
            {
                query = query.Where(d => d.DishSubcategory.Name == filterData.Subcategory);
            }
            if (!string.IsNullOrEmpty(filterData.Ingredient))
            {
                query = query.Where(d => d.Ingredients.Any(i => i.Name == filterData.Ingredient));
            }
            var result = query.ToList();
            
            return result;
        }
    }
}