using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using AutoMapper;
using Solution.Extensions;
using Solution.Mapping;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync (int id, [FromBody] SaveGameResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var game = mapper.Map<SaveGameResource,Game>(resource);
            var result = await gameServices.UpdateAsync(id,game);
            if(!result.IsSuccess){
                return BadRequest(result.Message);
            }
            var gameResources = mapper.Map<Game,GameResource>(result.Game);
            return Ok(gameResources);
        }
    }
}