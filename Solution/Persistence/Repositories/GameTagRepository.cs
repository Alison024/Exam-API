using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
using System.Linq;

namespace Solution.Persistence.Repositories
{
    public class GameTagRepository :BaseRepository, IGameTagRepository
    {
        public GameTagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(GameTag gameTag)
        {
            await context.GameTags.AddAsync(gameTag);
        }

        public void Delete(GameTag gameTag)
        {
            context.GameTags.Remove(gameTag);
        }

        public async Task<IEnumerable<GameTag>> Find(int id)
        {
           return await context.GameTags.Where(x=>x.GameId==id).ToListAsync();
        }

        public async Task<GameTag> FindByCompatibleKey(int gameId, int tagId)
        {
            return await context.GameTags.SingleOrDefaultAsync(x=>x.GameId==gameId && x.TagId==tagId);
        }

        public async Task<IEnumerable<GameTag>> GetAllAsync()
        {
            return await context.GameTags.ToListAsync();
        }

        public void Update(GameTag gameTag)
        {
            context.GameTags.Update(gameTag);
        }
    }
}