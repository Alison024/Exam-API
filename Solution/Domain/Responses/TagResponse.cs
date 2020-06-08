using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class TagResponse: BaseResponse
    {
        public Tag Tag{get;private set;}
        public TagResponse(bool success, string message, Tag tag) : base(success, message)
        {
            Tag = tag;
        }
        public TagResponse(Tag tag):this(true,string.Empty,tag){}
        public TagResponse(string mes):this(false,mes,null){}
    }
}