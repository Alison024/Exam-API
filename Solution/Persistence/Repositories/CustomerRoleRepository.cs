using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
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

        public async Task<CustomerRole> FindById(int id)
        {
            return await context.CustomerRoles.FindAsync(id);
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