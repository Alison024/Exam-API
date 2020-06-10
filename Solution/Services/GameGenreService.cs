using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class GameGenreService:IGameGenreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameGenreRepository gameGenreRepository;
        public GameGenreService(IUnitOfWork unitOfWork, IGameGenreRepository gameGenreRepository){
            this.unitOfWork =unitOfWork;
            this.gameGenreRepository =gameGenreRepository;
        } 

        public async Task<GameGenreResponse> DeleteAsync(int id)
        {
            var existingGameGenre = await gameGenreRepository.FindById(id);
            if (existingGameGenre == null)
                return new GameGenreResponse("Game genre not found");
            try
            {
                gameGenreRepository.Delete(existingGameGenre);
                await unitOfWork.CompleteAsync();

                return new GameGenreResponse(existingGameGenre);
            }
            catch (Exception ex)
            {
                return new GameGenreResponse($"Error when deleting game's genre: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GameGenre>> GetAllAsync()
        {
            return await gameGenreRepository.GetAllAsync();
        }

        public async Task<GameGenreResponse> SaveAsync(GameGenre gameGenre)
        {
            try{
                await gameGenreRepository.AddAsync(gameGenre);
                await unitOfWork.CompleteAsync();
                return new GameGenreResponse(gameGenre);
            }
            catch(Exception ex){
                return new GameGenreResponse($"Error while saving game' genre. Message:{ex.Message}");
            }
            
        }

        public async Task<GameGenreResponse> UpdateAsync(GameGenre gameTag)
        {
            var existingGameGenre = await gameGenreRepository.FindById(gameTag.GameId);
            if (existingGameGenre == null)
                return new GameGenreResponse("Game genre not found");
            
            try
            {
                gameGenreRepository.Update(existingGameGenre);
                await unitOfWork.CompleteAsync();

                return new GameGenreResponse(existingGameGenre);
            }
            catch (Exception ex)
            {
                return new GameGenreResponse($"Error when updating game's genre: {ex.Message}");
            }
        }
    }
}