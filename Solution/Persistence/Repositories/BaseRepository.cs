using Solution.Persistence.Context;
using Solution.Domain.Models;

namespace Solution.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;
        public BaseRepository(AppDbContext context){
            this.context = context;
        }
    }
}