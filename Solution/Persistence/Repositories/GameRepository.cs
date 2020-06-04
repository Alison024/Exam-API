using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Persistence.Repositories;
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

        public async Task<Game> FindByIdAsync(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await context.Games.ToListAsync();
        }

        public void Update(Game game)
        {
            context.Games.Update(game);
        }
    }
}