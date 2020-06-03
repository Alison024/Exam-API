using System.ComponentModel.DataAnnotations;
namespace Solution.Resources
{
    public class SaveGenreResource
    {
        [Required]
        public string Name{get;set;}
        public string Description{get;set;}
        
    }
}