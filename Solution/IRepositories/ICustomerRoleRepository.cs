using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface ICustomerRoleRepository
    {
        Task<IEnumerable<CustomerRole>> GetAllAsync();
        Task AddAsync(CustomerRole customerrole);
        void Update(CustomerRole customerrole);
        Task<IEnumerable<CustomerRole>> Find(int customerId);
        Task<CustomerRole> FindByCompatibleKey(int customerId,int roleId);
        void Delete(CustomerRole customerrole);
    }
}