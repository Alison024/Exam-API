using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
using System.Linq;

namespace Solution.Persistence.Repositories
{
    public class GameGenreRepository :BaseRepository, IGameGenreRepository
    {
        public GameGenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(GameGenre gameGenre)
        {
            await context.GameGenres.AddAsync(gameGenre);
        }

        public void Delete(GameGenre gameGenre)
        {
            context.GameGenres.Remove(gameGenre);
        }
        //возможно ошибка
        public async Task<IEnumerable<GameGenre>> Find(int id)
        {
            return await context.GameGenres.Where(x=>x.GameId==id).ToListAsync();
        }

        public async Task<GameGenre> FindByCompatibleKey(int gameId, int genreId)
        {
            return await context.GameGenres.SingleOrDefaultAsync(x=>x.GameId==gameId && x.GenreId==genreId);
        }

        public async Task<IEnumerable<GameGenre>> GetAllAsync()
        {
            return await context.GameGenres.ToListAsync();
        }

        public void Update(GameGenre gameGenre)
        {
            context.GameGenres.Update(gameGenre);
        }
    }
}