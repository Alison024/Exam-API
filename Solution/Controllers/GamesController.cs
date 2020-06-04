using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using AutoMapper;
namespace Solution.Controllers
{
    [Route("/api/games")]
    public class GamesController:Controller
    {
        private readonly IGameService gameServices;
        private readonly IMapper mapper;
        public GamesController(IGameService gameServices, IMapper mapper){
            this.gameServices = gameServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GameResource>> GetAllAsync(){
            var games = await gameServices.GetAllAsync();
            var gameResources = mapper.Map<IEnumerable<Game>,IEnumerable<GameResource>>(games);
            return gameResources;
        }
    }
}