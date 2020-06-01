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

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await context.Games.ToListAsync();
        }
    }
}