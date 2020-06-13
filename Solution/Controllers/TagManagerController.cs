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
    [Route("/api/tagmanager")]
    public class TagManagerController:Controller
    {
        private readonly IGameTagService gameTagService;
        private readonly IMapper mapper;
        public TagManagerController(IGameTagService gameTagService, IMapper mapper){
            this.gameTagService = gameTagService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GameTagResource>> GetAllAsync(){
            var gameTags = await gameTagService.GetAllAsync();
            var gameResources = mapper.Map<IEnumerable<GameTag>,IEnumerable<GameTagResource>>(gameTags);
            return gameResources;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<GameTagResource>> GetTagOfGame(int id){
            var gameTags = await gameTagService.GetTagsOfGame(id);
            var gameResources = mapper.Map<IEnumerable<GameTag>,IEnumerable<GameTagResource>>(gameTags);
            return gameResources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GameTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var gameGenres = mapper.Map<GameTagResource, GameTag>(resource);
            var result = await gameTagService.SaveAsync(gameGenres);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenresResource = mapper.Map<GameTag, GameTagResource>(result.GameTag);
            return Ok(gameGenresResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] GameTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var gameGenre = mapper.Map<GameTagResource, GameTag>(resource);
            var result = await gameTagService.UpdateAsync(gameGenre);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenreResource = mapper.Map<GameTag, GameTagResource>(result.GameTag);
            return Ok(gameGenreResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody]GameTagResource resource)
        {   
            var gamegenre = mapper.Map<GameTagResource, GameTag>(resource);
            var result = await gameTagService.DeleteAsync(gamegenre);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var gameGenreResource = mapper.Map<GameTag, GameTagResource>(result.GameTag);
            return Ok(gameGenreResource);
        }
    }
}