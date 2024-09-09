using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        
        [JsonIgnore]
        public List<DishesIngredients> DishesIngredients { get; set; } = new List<DishesIngredients>();
    }
}