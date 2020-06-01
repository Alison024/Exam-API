using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
namespace Solution.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository; 
        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
           return await gameRepository.GetAllAsync();
        }
    }
}