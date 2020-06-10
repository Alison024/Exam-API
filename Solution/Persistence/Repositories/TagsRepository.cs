using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
namespace Solution.Persistence.Repositories
{
    public class TagsRepository :BaseRepository, ITagRepository
    {
        public TagsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Tag tag)
        {
            await context.Tags.AddAsync(tag);
        }

        public void Delete(Tag tag)
        {
            context.Tags.Remove(tag);
        }

        public async Task<Tag> FindById(int id)
        {
            return await context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await context.Tags.ToListAsync();
        }

        public void Update(Tag tag)
        {
            context.Tags.Update(tag);
        }
    }
}