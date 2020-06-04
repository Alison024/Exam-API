using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGameService
    {
        Task <IEnumerable<Game>> GetAllAsync();
        Task <SaveGameResponse> SaveAsync(Game game);
    }
}