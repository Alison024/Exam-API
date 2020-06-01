using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
namespace Solution.Domain.IServices
{
    public interface IGameService
    {
        Task <IEnumerable<Game>> GetAllAsync();
    }
}