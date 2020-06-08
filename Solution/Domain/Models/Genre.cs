using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Domain.Models
{
    
    public class Genre
    {
        public int GenreId{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public IList<GameGenre> GameGenres = new List<GameGenre>();
    }
}