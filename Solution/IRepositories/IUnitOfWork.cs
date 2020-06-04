using System.Threading.Tasks;
namespace Solution.IRepositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}