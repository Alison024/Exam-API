using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGameTagService
    {
        Task<IEnumerable<GameTag>> GetAllAsync();
        Task<IEnumerable<GameTag>> GetTagsOfGame(int id);
        Task<GameTagResponse> SaveAsync(GameTag gameTag);
        Task<GameTagResponse> UpdateAsync(GameTag gameTag);
        Task<GameTagResponse> DeleteAsync(GameTag gameTag);
    }
}