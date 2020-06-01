using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Threading.Tasks;
namespace Solution.Controllers
{
    [Route("/api/genres")]
    public class GenresController:Controller
    {
        private readonly IGenreService genreServices;
        public GenresController(IGenreService genreServices){
            this.genreServices = genreServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> GetAllAsync(){
            return await genreServices.GetAllAsync();
        }
    }
}