using System;
using System.Runtime;
namespace Solution.Domain.Models
{
    public class Sale
    {
        public int SaleId{get;set;}
        public DateTime Date{get;set;}
        public int GameId{get;set;}
        public Game Game {get;set;}
        public int CustomerId{get;set;}
        public Customer Customer{get;set;}
        //public IList<Customer> UserRoles{get;set;} = new List<CustomerRole>();
    }
}