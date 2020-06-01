using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int CustomerId{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
    }
}