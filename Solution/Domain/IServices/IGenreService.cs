using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGenreService
    {
        Task <IEnumerable<Genre>> GetAllAsync();
        Task <GenreResponse> SaveAsync(Genre genre);
        Task<GenreResponse> UpdateAsync(int id, Genre genre);
        Task<GenreResponse> DeleteAsync(int id);
    }
}