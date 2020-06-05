using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
namespace Solution.IRepositories
{
    public interface IGenreRepository
    {
         Task<IEnumerable<Genre>> GetAllAsync();
         Task AddAsync(Genre genre);
         void Update(Genre genre);
         Task<Genre> FindById(int id);
         void Delete(Genre genre);
    }
}