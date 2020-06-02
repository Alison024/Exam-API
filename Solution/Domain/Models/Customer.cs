using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    
    public class Customer
    {
        public int CustomerId{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
    }
}