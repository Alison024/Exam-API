using Solution.Domain.Models;

namespace Solution.Domain.Responses
{
    public class GameGenreResponse: BaseResponse
    {
        public GameGenre GameGenre{get;private set;}
        public GameGenreResponse(bool success, string message, GameGenre gameGenre) : base(success, message)
        {
            GameGenre = gameGenre;
        }
        public GameGenreResponse(GameGenre gameGenre):this(true,string.Empty,gameGenre){}
        public GameGenreResponse(string mes):this(false,mes,null){}

    }
}