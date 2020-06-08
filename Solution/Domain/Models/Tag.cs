using System.Collections.Generic;

namespace Solution.Domain.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Description{get;set;}
        public IList<GameTag> GameTags {get;set;} = new List<GameTag>();
    }
}