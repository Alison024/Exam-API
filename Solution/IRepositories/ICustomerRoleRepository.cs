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
        Task<CustomerRole> FindById(int id);
        void Delete(CustomerRole customerrole);
    }
}