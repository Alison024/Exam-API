using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    
    public class Customer
    {
        public int CustomerId{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public string Login{get;set;}
        public string Password{get;set;}
        public string Token{get;set;}
        public IList<CustomerRole> UserRoles{get;set;} = new List<CustomerRole>();
    }
}