using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class SaleResponse: BaseResponse
    {
        public Sale Sale{get;private set;}
        public SaleResponse(bool success, string message, Sale sale) : base(success, message)
        {
            Sale = sale;
        }
        public SaleResponse(Sale sale):this(true,string.Empty,sale){}
        public SaleResponse(string mes):this(false,mes,null){}
    }
}