using System.ComponentModel.DataAnnotations;
namespace Solution.Resources
{
    public class GenreResource
    {
        [Required]
        public int GenreId{get;set;}
        [Required]
        public string Name{get;set;}
        public string Description{get;set;}
    }
}