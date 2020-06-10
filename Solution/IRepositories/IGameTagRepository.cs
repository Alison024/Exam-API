using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface IGameTagRepository
    {
        Task<IEnumerable<GameTag>> GetAllAsync();
        Task AddAsync(GameTag gameTag);
        void Update(GameTag gameTag);
        Task<GameTag> FindById(int id);
        void Delete(GameTag gameTag);
    }
}