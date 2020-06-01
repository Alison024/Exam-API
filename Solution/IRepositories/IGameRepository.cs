using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
namespace Solution.IRepositories
{
    public interface IGameRepository
    {
         Task<IEnumerable<Game>> GetAllAsync();
    }
}