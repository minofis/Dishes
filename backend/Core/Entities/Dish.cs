using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public DishCategory DishCategory { get; set; }
        public int DishCategoryId { get; set; }
        public DishSubcategory DishSubcategory { get; set; }
        public int DishSubcategoryId { get; set; }

        [JsonIgnore]
        public List<DishesIngredients> DishesIngredients { get; set; } = new List<DishesIngredients>();
    }
}