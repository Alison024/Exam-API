using Solution.Domain.Models;

namespace Solution.Domain.Responses
{
    public class GameTagResponse: BaseResponse
    {
        public GameTag GameTag{get;private set;}
        public GameTagResponse(bool success, string message, GameTag gameTag) : base(success, message)
        {
            GameTag = gameTag;
        }
        public GameTagResponse(GameTag gameTag):this(true,string.Empty,gameTag){}
        public GameTagResponse(string mes):this(false,mes,null){}

    }
}