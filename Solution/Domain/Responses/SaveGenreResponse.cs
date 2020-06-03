using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class SaveGenreResponse : BaseResponse
    {
        public Genre Genre{get;private set;}
        public SaveGenreResponse(bool success, string message, Genre genre) : base(success, message)
        {
            Genre = genre;
        }
        public SaveGenreResponse(Genre genre):this(true,string.Empty,genre){}
        public SaveGenreResponse(string mes):this(false,mes,null){}

    }
}