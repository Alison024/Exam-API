using AutoMapper;
using Solution.Domain.Models;
using Solution.Resources;
namespace Solution.Mapping
{
    public class SaveResourceModelProfile:Profile
    {
        public SaveResourceModelProfile(){
            CreateMap<SaveGameResource,Game>();
            CreateMap<SaveGenreResource,Genre>();
            CreateMap<Game,SaveGameResource>();
            CreateMap<Genre,SaveGenreResource>();
        }
    }
}