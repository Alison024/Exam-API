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
        Task<IEnumerable<GameGenre>> Find(int gameId);
        Task<GameGenre> FindByCompatibleKey(int gameId,int genreId);
        void Delete(GameGenre gameGenre);
    }
}