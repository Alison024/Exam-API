using Solution.Domain.Models;
namespace Solution.Domain.Responses
{
    public class GenreResponse : BaseResponse
    {
        public Genre Genre{get;private set;}
        public GenreResponse(bool success, string message, Genre genre) : base(success, message)
        {
            Genre = genre;
        }
        public GenreResponse(Genre genre):this(true,string.Empty,genre){}
        public GenreResponse(string mes):this(false,mes,null){}

    }
}