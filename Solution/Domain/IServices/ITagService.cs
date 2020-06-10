using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<TagResponse> SaveAsync(Tag tag);
        Task<TagResponse> UpdateAsync(Tag tag);
        Task<TagResponse> DeleteAsync(int id);
    }
}