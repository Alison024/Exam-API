using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;

namespace Solution.Domain.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<RoleResponse> SaveAsync(Role role);
        Task<RoleResponse> UpdateAsync(Role role);
        Task<RoleResponse> DeleteAsync(int id);
    }
}