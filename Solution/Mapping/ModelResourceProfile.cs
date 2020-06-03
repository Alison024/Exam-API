using AutoMapper;
using Solution.Resources;
using Solution.Domain.Models;
namespace Solution.Mapping
{
    public class ModelResourceProfile : Profile
    {
        public ModelResourceProfile()
        {
            CreateMap<Genre,GenreResource>();
            CreateMap<Game,GameResource>();
            CreateMap<GenreResource,Genre>();
            CreateMap<GameResource,Game>();
        }
    }
}