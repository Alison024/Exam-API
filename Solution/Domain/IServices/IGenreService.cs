using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface IGenreService
    {
        Task <IEnumerable<Genre>> GetAllAsync();
        Task <SaveGenreResponse> SaveAsync(Genre genre);
    }
}