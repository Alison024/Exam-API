using System.ComponentModel.DataAnnotations;

namespace Solution.Resources
{
    public class TagResourse
    {
        [Required]
        public int GenreId{get;set;}
        [Required]
        public string Name{get;set;}
        public string Description{get;set;}
    }
}