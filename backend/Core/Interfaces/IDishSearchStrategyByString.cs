using Core.Entities;

namespace Core.Interfaces
{
    public interface IDishSearchByFilterStrategy
    {
        List<Dish> Search(List<Dish> dishes, string category, string subcategory, string ingredient);
    }
}