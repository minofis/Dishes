using Core.Entities;

namespace API.Dtos
{
    public class DishToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string DishCategory { get; set; } = string.Empty;
        public string DishSubcategory { get; set; } = string.Empty;
        public List<IngredientToReturntDto> Ingredients { get; set; } = new List<IngredientToReturntDto>();
    }
}