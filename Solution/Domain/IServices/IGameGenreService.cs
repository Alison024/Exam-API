using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGameGenreService
    {
         Task<IEnumerable<GameGenre>> GetAllAsync();
        Task<GameGenreResponse> SaveAsync(GameGenre gameGenre);
        Task<GameGenreResponse> UpdateAsync(GameGenre gameGenre);
        Task<GameGenreResponse> DeleteAsync(int id);
    }
}