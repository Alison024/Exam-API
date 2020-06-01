using System.Collections.Generic;
using Solution.Domain.Models;
using System.Threading.Tasks;
namespace Solution.Domain.IServices
{
    public interface IGenreService
    {
        Task <IEnumerable<Genre>> GetAllAsync();
    }
}