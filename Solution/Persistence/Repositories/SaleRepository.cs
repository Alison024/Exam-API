using Solution.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Solution.IRepositories;
namespace Solution.Persistence.Repositories
{
    public class SaleRepository :BaseRepository, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Sale sale)
        {
            await context.Sales.AddAsync(sale);
        }

        public void Delete(Sale sale)
        {
            context.Sales.Remove(sale);
        }

        public async Task<Sale> FindById(int id)
        {
            return await context.Sales.FindAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await context.Sales.ToListAsync();
        }

        public void Update(Sale sale)
        {
            context.Sales.Update(sale);
        }
    }
}