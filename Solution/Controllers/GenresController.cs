using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Domain.Responses;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Solution.Controllers
{
    [Authorize]
    [Route("/api/genres")]
    public class GenresController:Controller
    {
        private readonly IGenreService genreServices;
        private readonly IMapper mapper;
        public GenresController(IGenreService genreServices,IMapper mapper){
            this.genreServices = genreServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GenreResource>> GetAllAsync(){
            var genres = await genreServices.GetAllAsync();
            var genreResources = mapper.Map<IEnumerable<Genre>,IEnumerable<GenreResource>>(genres);
            return genreResources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GenreResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var genres = mapper.Map<GenreResource,Genre>(resource);
            var result = await genreServices.SaveAsync(genres);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            var genreResources = mapper.Map<Genre,GenreResource>(result.Genre);
            return Ok(genreResources);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] GenreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<GenreResource, Genre>(resource);
            var result = await genreServices.UpdateAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Genre, GenreResource>(result.Genre);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await genreServices.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Genre, GenreResource>(result.Genre);
            return Ok(categoryResource);
        }
    }
}