using Core.Interfaces;

namespace Core.Entities
{
    public class FilterDataDto : IFilterDataDto
    {   
        public FilterDataDto(string _category, string _subcategory, string _ingredient)
        {
            if(!string.IsNullOrEmpty(_category)) Category = _category;
            if(!string.IsNullOrEmpty(_subcategory)) Subcategory = _subcategory;
            if(!string.IsNullOrEmpty(_ingredient)) Ingredient = _ingredient;
        }
        public string? Category { get; set; } = string.Empty;
        public string? Ingredient { get; set; } = string.Empty;
        public string? Subcategory { get; set; } = string.Empty;
    }
}