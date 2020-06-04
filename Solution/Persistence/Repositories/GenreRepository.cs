using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;

namespace Solution.IRepositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Genre genre)
        {
            await context.Genres.AddAsync(genre);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await context.Genres.ToListAsync();
        }
    }
}