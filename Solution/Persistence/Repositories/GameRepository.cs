using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;

namespace Solution.Persistence.Repositories
{
    public class GameRepository : BaseRepository,IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Game game)
        {
            await context.Games.AddAsync(game);
        }

        public void Delete(Game game)
        {
            context.Games.Remove(game);
        }

        public async Task<Game> FindById(int id)
        {
           return await context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await context.Games.Include(x=>x.GameGenres).ThenInclude(y=>y.Genre).Include(w=>w.GameTags).ThenInclude(z=>z.Tag).ToListAsync();//.Include(w=>w.GameTags).ThenInclude(z=>z.Tag)
        }

        public void Update(Game game)
        {
            context.Games.Update(game);
        }
    }
}