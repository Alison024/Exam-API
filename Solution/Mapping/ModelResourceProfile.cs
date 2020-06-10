using System.Linq;
using System.Net.NetworkInformation;
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
            
            CreateMap<Game,GameResource>().ForMember(g=>g.Genres, arr2=>arr2.MapFrom(v=>v.GameGenres.Select(z=>z.Genre.Name))).ForMember(t=>t.Tags, arr1=>arr1.MapFrom(x=>x.GameTags.Select(y=>y.Tag.Name)));//
            //CreateMap<Game,GameResource>().ForMember(g=>g.Genres, arr=>arr.MapFrom(x=>x.GameGenres.Select(y=>y.Genre.Name)));
            CreateMap<GenreResource,Genre>();
            CreateMap<GameResource,Game>();
            CreateMap<Customer,CustomerResourse>().ForMember(cust=>cust.Role, arr=>arr.MapFrom(x=>x.UserRoles.Select(y=>y.Role.Name)));
            CreateMap<CustomerResourse,Customer>();
            CreateMap<TagResourse,Tag>();
            CreateMap<Tag,TagResourse>();
            CreateMap<Sale,SaleResourse>().ForMember(game=>game.Game,name=>name.MapFrom(x=>x.Game.Name)).ForMember(cust=>cust.Customer, login=>login.MapFrom(y=>y.Customer.Login));
            CreateMap<SaleResourse,Sale>();
        }
    }
}