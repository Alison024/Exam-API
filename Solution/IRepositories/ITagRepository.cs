using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface ITagRepository
    {
         Task<IEnumerable<Tag>> GetAllAsync();
         Task AddAsync(Tag tag);
         void Update(Tag tag);
         Task<Tag> FindById(int id);
         void Delete(Tag tag);
    }
}