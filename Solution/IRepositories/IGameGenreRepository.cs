using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface IGameGenreRepository
    {
        Task<IEnumerable<GameGenre>> GetAllAsync();
        Task AddAsync(GameGenre gameGenre);
        void Update(GameGenre gameGenre);
        Task<GameGenre> FindById(int id);
        void Delete(GameGenre gameGenre);
    }
}