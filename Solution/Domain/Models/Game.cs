using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    
    public class Game
    {
        public int GameId{get;set;}
        public string Name{get;set;}
        public double Price{get;set;}
        public int GenreId{get;set;}
        public Genre Genre {get;private set;}
        public string Description{get;set;}
        
    }
}