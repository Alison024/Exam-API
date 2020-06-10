using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
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

        public async Task<GameTag> FindById(int id)
        {
           return await context.GameTags.FindAsync(id);
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