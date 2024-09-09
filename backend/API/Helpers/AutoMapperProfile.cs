using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dish, DishToReturnDto>()
                .ForMember(d => d.DishSubcategory, o => o.MapFrom(s => s.DishSubcategory.Name))
                .ForMember(d => d.DishCategory, o => o.MapFrom(s => s.DishCategory.Name))
                .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.Ingredients));

            CreateMap<Ingredient, IngredientToReturntDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}