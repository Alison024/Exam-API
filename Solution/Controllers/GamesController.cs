using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
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
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GameResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<GameResource, Game>(resource);
            var result = await gameServices.SaveAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Game, GameResource>(result.Game);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] GameResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<GameResource, Game>(resource);
            var result = await gameServices.UpdateAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Game, GameResource>(result.Game);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await gameServices.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Game, GameResource>(result.Game);
            return Ok(categoryResource);
        }
    }
}