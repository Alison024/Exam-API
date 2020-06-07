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
            CreateMap<Game,GameResource>();
            CreateMap<GenreResource,Genre>();
            CreateMap<GameResource,Game>();
            CreateMap<Customer,CustomerResourse>().ForMember(cust=>cust.Role, arr=>arr.MapFrom(x=>x.UserRoles.Select(y=>y.Role.Name)));
            CreateMap<CustomerResourse,Customer>();
        }
    }
}