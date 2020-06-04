using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Domain.Responses;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;
namespace Solution.Controllers
{
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
        public async Task<IActionResult> PostAsync([FromBody] SaveGenreResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var genres = mapper.Map<SaveGenreResource,Genre>(resource);
            var result = await genreServices.SaveAsync(genres);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            var genreResources = mapper.Map<Genre,GenreResource>(result.Genre);
            return Ok(genreResources);
        }
    }
}