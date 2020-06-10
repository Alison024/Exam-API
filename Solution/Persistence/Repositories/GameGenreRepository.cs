using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
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
        public async Task<GameGenre> FindById(int id)
        {
            return await context.GameGenres.FindAsync(id);
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