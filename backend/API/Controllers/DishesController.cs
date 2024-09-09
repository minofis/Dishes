using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.DishSearchContext;
using Infrastructure.Data.Strategies;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IDishesRepository _repo;
        private readonly IMapper _mapper;
        public DishesController(IDishesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<DishToReturnDto>> GetAllDishes(){
            var dishes = await _repo.GetAllDishesAsync();
            var dishDtos = _mapper.Map<List<DishToReturnDto>>(dishes);
            return dishDtos;
        }

        [HttpGet("{id}")]

        public async Task<DishToReturnDto> GetDishById(int id){
            var dish = await _repo.GetDishByIdAsync(id);
            var dishDto = _mapper.Map<DishToReturnDto>(dish);
            return dishDto;
        }

        [HttpGet("by-filter")]

        public async Task<List<DishToReturnDto>> GetDishesByCategory(
            [FromQuery] string? category,
            [FromQuery] string? subcategory,
            [FromQuery] string? ingredient
        ){


            var dishes = await _repo.GetAllDishesAsync();

            var strContext = new DishSearchContext(new DishSearchByFilterStrategy());

            var filteredDishes = strContext.ExecuteSearch(dishes, category, subcategory, ingredient);

            var dishDtos = _mapper.Map<List<DishToReturnDto>>(filteredDishes);

            return dishDtos;
        }
/*
        [HttpGet("by-subcategory/{subcategory}")]

        public async Task<List<DishToReturnDto>> GetDishesBySubcategory(string subcategory){
            var dishes = await _repo.GetAllDishesAsync();

            var strContext = new DishSearchContext(new BySubcategorySearchStrategy());

            var filteredDishes = strContext.ExecuteSearch(dishes, subcategory);

            var dishDtos = _mapper.Map<List<DishToReturnDto>>(filteredDishes);

            return dishDtos;
        }

        [HttpGet("by-name/{name}")]

        public async Task<List<DishToReturnDto>> GetDishesByName(string name){
            var dishes = await _repo.GetAllDishesAsync();

            var strContext = new DishSearchContext(new ByNameSearchStrategy());

            var filteredDishes = strContext.ExecuteSearch(dishes, name);

            var dishDtos = _mapper.Map<List<DishToReturnDto>>(filteredDishes);

            return dishDtos;
        }

        [HttpGet("by-rating/{rating}")]
 
        public async Task<List<DishToReturnDto>> GetDishesByRating(string rating){
            var dishes = await _repo.GetAllDishesAsync();

            var strContext = new DishSearchContext(new ByRatingSearchStrategy());

            var filteredDishes = strContext.ExecuteSearch(dishes, rating);

            var dishDtos = _mapper.Map<List<DishToReturnDto>>(filteredDishes);

            return dishDtos;
        }

        [HttpGet("by-ingredient/{ingredient}")]

        public async Task<List<DishToReturnDto>> GetDishesByIngredient(string ingredient){
            var dishes = await _repo.GetAllDishesAsync();

            var strContext = new DishSearchContext(new ByRatingSearchStrategy());

            var filteredDishes = strContext.ExecuteSearch(dishes, ingredient);

            var dishDtos = _mapper.Map<List<DishToReturnDto>>(filteredDishes);

            return dishDtos;
        } 
*/
        [HttpGet("categories")]
        public async Task<List<DishCategory>> GetAllDishCategories(){
            return await _repo.GetAllDishCategoriesAsync();
        }

        [HttpGet("subcategories")]
        public async Task<List<DishSubcategory>> GetAllDishSubcategories(){
            return await _repo.GetAllDishSubcategoriesAsync();
        }

        [HttpGet("ingredients")]
        public async Task<List<Ingredient>> GetAllIngredients(){
            var ingredients = await _repo.GetAllIngredientsAsync();
            return ingredients;
        }
    }
}