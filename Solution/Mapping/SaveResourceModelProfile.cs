using System.Linq;
using AutoMapper;
using Solution.Domain.Models;
using Solution.Resources;
namespace Suka   //Solution.Mapping
{
    public class SaveResourceModelProfile//:Profile
    {
        /*public SaveResourceModelProfile(){
            CreateMap<GameResource,Game>();
            CreateMap<GenreResource,Genre>();
            CreateMap<Game,GameResource>().ForMember(t=>t.Tags, arr=>arr.MapFrom(x=>x.GameTags.Select(y=>y.Tag.Name)));
            //CreateMap<Game,GameResource>().ForMember(g=>g.Genres, arr=>arr.MapFrom(x=>x.GameGenres.Select(y=>y.Genre.Name)));
        
        }*/
    }
}