using System.ComponentModel.DataAnnotations;
namespace Solution.Resources
{
    public class GameResource
    {
        [Required]
        public int GameId{get;set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public double Price{get;set;}
        [Required]
        public int GenreId{get;set;}
        public string Description{get;set;}
    }
}