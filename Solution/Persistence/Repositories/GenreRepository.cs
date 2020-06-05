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

        public void Delete(Genre genre)
        {
            context.Genres.Remove(genre);
        }
        
        public async Task<Genre> FindById(int id)
        {
            return await context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public void Update(Genre genre)
        {
            context.Genres.Remove(genre);
        }
    }
}