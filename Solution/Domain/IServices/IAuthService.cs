using System.Threading.Tasks;
using Solution.Domain.Models;
namespace Solution.Domain.IServices
{
    public interface IAuthService
    {
         Task<Customer> Authenticate(string login, string password);
    }
}