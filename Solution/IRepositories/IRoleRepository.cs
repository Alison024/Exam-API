using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface IRoleRepository
    {
         Task<IEnumerable<Role>> GetAllAsync();
         Task AddAsync(Role role);
         void Update(Role role);
         Task<Role> FindById(int id);
         void Delete(Role role);
    }
}