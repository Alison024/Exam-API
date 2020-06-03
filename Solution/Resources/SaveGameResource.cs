using System.ComponentModel.DataAnnotations;
namespace Solution.Resources
{
    public class SaveGameResource
    {
        [Required]
        public string Name{get;set;}
        [Required]
        public double Price{get;set;}
        [Required]
        public int GenreName{get;set;}
        public string Description{get;set;}
    }
}