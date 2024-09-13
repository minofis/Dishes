using API.Dtos;
using Core.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class DishUrlResolver : IValueResolver<Dish, DishToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public DishUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Dish source, DishToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return _config["ApiUrl"] + source.PictureUrl;
            }
            
            return null;
        }
    }
}