using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Threading.Tasks;
namespace Solution.Controllers
{
    [Route("/api/games")]
    public class GamesController:Controller
    {
        private readonly IGameService gameServices;
        public GamesController(IGameService gameServices){
            this.gameServices = gameServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetAllAsync(){
            return await gameServices.GetAllAsync();
        }
    }
}