using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class SaveGameResponse: BaseResponse
    {
        public Game Game{get;private set;}
        public SaveGameResponse(bool success, string message, Game game) : base(success, message)
        {
            Game = game;
        }
        public SaveGameResponse(Game game):this(true,string.Empty,game){}
        public SaveGameResponse(string mes):this(false,mes,null){}

    }
}