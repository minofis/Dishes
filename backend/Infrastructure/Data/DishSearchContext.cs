using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.DishSearchContext
{
    public class DishSearchContext 
    {
        private readonly IDishSearchByFilterStrategy _filterStrategy;

        public DishSearchContext(IDishSearchByFilterStrategy filterStrategy)
        {
            _filterStrategy = filterStrategy;
        }

        public List<Dish> ExecuteSearch(List<Dish> dishes, string category, string subcategory, string ingredient){
            return _filterStrategy.Search(dishes, category, subcategory, ingredient);
        }
    }
}