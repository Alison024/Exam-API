using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);
    }
}