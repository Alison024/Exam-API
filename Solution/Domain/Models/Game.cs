using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    
    public class Game
    {
        public int GameId{get;set;}
        public string Name{get;set;}
        public double Price{get;set;}
        public IList<GameGenre> GameGenres{get;set;} = new List<GameGenre>();
        public IList<GameTag> GameTags{get;set;} = new List<GameTag>();
        public string Description{get;set;}
        public Sale Sale{get;set;}
        
    }
}