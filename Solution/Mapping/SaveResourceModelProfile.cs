using AutoMapper;
using Solution.Domain.Models;
using Solution.Resources;
namespace Solution.Mapping
{
    public class SaveResourceModelProfile:Profile
    {
        public SaveResourceModelProfile(){
            CreateMap<GameResource,Game>();
            CreateMap<GenreResource,Genre>();
            CreateMap<Game,GameResource>();
            CreateMap<Genre,GenreResource>();
        }
    }
}