using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGameGenreService
    {
        Task<IEnumerable<GameGenre>> GetAllAsync();
        Task<IEnumerable<GameGenre>> GetGenresOfGame(int id);
        Task<GameGenreResponse> SaveAsync(GameGenre gameGenre);
        Task<GameGenreResponse> UpdateAsync(GameGenre gameGenre);
        Task<GameGenreResponse> DeleteAsync(GameGenre gameGenre);
    }
}