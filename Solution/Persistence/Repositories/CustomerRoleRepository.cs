using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
using System.Linq;

namespace Solution.Persistence.Repositories
{
    public class CustomerRoleRepository :BaseRepository, ICustomerRoleRepository
    {
        public CustomerRoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(CustomerRole customerrole)
        {
            await context.CustomerRoles.AddAsync(customerrole);
        }

        public void Delete(CustomerRole customerrole)
        {
            context.CustomerRoles.Remove(customerrole);
        }

        public async Task<IEnumerable<CustomerRole>> Find(int id)
        {
            return await context.CustomerRoles.Where(x=>x.CustomerId==id).ToListAsync();
        }

        public async Task<CustomerRole> FindByCompatibleKey(int customerId, int roleId)
        {
            return await context.CustomerRoles.SingleOrDefaultAsync(x=>x.CustomerId==customerId && x.RoleId==roleId);
        }

        public async Task<IEnumerable<CustomerRole>> GetAllAsync()
        {
            return await context.CustomerRoles.ToListAsync();
        }

        public void Update(CustomerRole customerrole)
        {
            context.CustomerRoles.Update(customerrole);
        }
    }
}