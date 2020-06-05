using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
namespace Solution.IRepositories
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<Customer>> GetAllAsync();
         Task AddAsync(Customer customer);
         void Update(Customer customer);
         Task<Customer> FindById(int id);
         void Delete(Customer customer);
    }
}