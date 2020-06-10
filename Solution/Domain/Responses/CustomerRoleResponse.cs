using Solution.Domain.Models;

namespace Solution.Domain.Responses
{
    public class CustomerRoleResponse: BaseResponse
    {
        public CustomerRole CustomerRole{get;private set;}
        public CustomerRoleResponse(bool success, string message, CustomerRole customerRole) : base(success, message)
        {
            CustomerRole = customerRole;
        }
        public CustomerRoleResponse(CustomerRole customerRole):this(true,string.Empty,customerRole){}
        public CustomerRoleResponse(string mes):this(false,mes,null){}

    }
}