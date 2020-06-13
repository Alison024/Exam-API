using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace Solution.Controllers
{
    [Route("/api/genremanager")]
    public class GenreManagerController:Controller
    {
        private readonly IGameGenreService gameGenreService;
        private readonly IMapper mapper;
        public GenreManagerController(IGameGenreService gameGenreService, IMapper mapper){
            this.gameGenreService = gameGenreService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GameGenreResource>> GetAllAsync(){
            var gameGenres = await gameGenreService.GetAllAsync();
            var gameResources = mapper.Map<IEnumerable<GameGenre>,IEnumerable<GameGenreResource>>(gameGenres);
            return gameResources;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<GameGenreResource>> GetGenresOfGame(int id){
            var gameGenres = await gameGenreService.GetGenresOfGame(id);
            var gameResources = mapper.Map<IEnumerable<GameGenre>,IEnumerable<GameGenreResource>>(gameGenres);
            return gameResources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GameGenreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var gameGenres = mapper.Map<GameGenreResource, GameGenre>(resource);
            var result = await gameGenreService.SaveAsync(gameGenres);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenresResource = mapper.Map<GameGenre, GameGenreResource>(result.GameGenre);
            return Ok(gameGenresResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] GameGenreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var gameGenre = mapper.Map<GameGenreResource, GameGenre>(resource);
            var result = await gameGenreService.UpdateAsync(gameGenre);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenreResource = mapper.Map<GameGenre, GameGenreResource>(result.GameGenre);
            return Ok(gameGenreResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody]GameGenreResource resource)
        {   
            var gamegenre = mapper.Map<GameGenreResource, GameGenre>(resource);
            var result = await gameGenreService.DeleteAsync(gamegenre);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenreResource = mapper.Map<GameGenre, GameGenreResource>(result.GameGenre);
            return Ok(gameGenreResource);
        }
    }
}