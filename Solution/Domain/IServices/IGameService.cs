using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGameService
    {
        Task <IEnumerable<Game>> GetAllAsync();
        Task <GameResponse> SaveAsync(Game game);
        Task<GameResponse> UpdateAsync(int id, Game game);
        Task<GameResponse> DeleteAsync(int id);
    }
}