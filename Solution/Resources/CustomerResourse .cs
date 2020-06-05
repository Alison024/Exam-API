using System.ComponentModel.DataAnnotations;
namespace Solution.Resources
{
    public class CustomerResourse 
    {
        [Required]
        public int CustomerId{get;set;}
        public string Name{get;set;}
        [Required]
        public string Surname{get;set;}
        [Required]
        public string Login{get;set;}
        [Required]
        public string Token{get;set;}
        public string[] Role {get;set;}
    }
}