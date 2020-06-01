using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
namespace Solution.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository; 
        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await genreRepository.GetAllAsync();
        }
    }
}