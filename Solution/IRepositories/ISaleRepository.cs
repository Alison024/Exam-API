using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.IRepositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
         Task AddAsync(Sale sale);
         void Update(Sale sale);
         Task<Sale> FindById(int id);
         void Delete(Sale sale);
    }
}