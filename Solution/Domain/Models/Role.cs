using System.Collections.Generic;

namespace Solution.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public IList<CustomerRole> UserRoles {get;set;} = new List<CustomerRole>();
    }
}