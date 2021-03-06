using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface ICustomerRoleService
    {
        Task<IEnumerable<CustomerRole>> GetAllAsync();
        Task<IEnumerable<CustomerRole>> GetRolesOfCustomer(int id);
        Task<CustomerRoleResponse> SaveAsync(CustomerRole customer);
        Task<CustomerRoleResponse> UpdateAsync(CustomerRole customer);
        Task<CustomerRoleResponse> DeleteAsync(CustomerRole customer);
    }
}