using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Responses;
namespace Solution.Domain.IServices
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<SaleResponse> SaveAsync(Sale sale);
        Task<SaleResponse> UpdateAsync(Sale sale);
        Task<SaleResponse> DeleteAsync(int id);
    }
}