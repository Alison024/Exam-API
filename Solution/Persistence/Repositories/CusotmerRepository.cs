using Solution.IRepositories;
using Solution.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Solution.Persistence.Repositories
{
    public class CusotmerRepository : BaseRepository, ICustomerRepository
    {
        public CusotmerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public void Delete(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public async Task<Customer> FindById(int id)
        {
            return await context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
        }
    }
}