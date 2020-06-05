using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class GameResponse: BaseResponse
    {
        public Game Game{get;private set;}
        public GameResponse(bool success, string message, Game game) : base(success, message)
        {
            Game = game;
        }
        public GameResponse(Game game):this(true,string.Empty,game){}
        public GameResponse(string mes):this(false,mes,null){}

    }
}