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

        public List<Dish> ExecuteSearch(List<Dish> dishes, IFilterDataDto filterData){
            return _filterStrategy.Search(dishes, filterData);
        }
    }
}