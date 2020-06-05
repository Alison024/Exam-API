using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameRepository gameRepository; 
        public GameService(IGameRepository gameRepository,IUnitOfWork unit)
        {
            unitOfWork = unit;
            this.gameRepository = gameRepository;
        }

        public async Task<GameResponse> DeleteAsync(int id)
        {
            var existingUser = await gameRepository.FindById(id);
            if (existingUser == null)
                return new GameResponse("User not found");
            try
            {
                gameRepository.Delete(existingUser);
                await unitOfWork.CompleteAsync();

                return new GameResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new GameResponse($"Error when deleting user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
           return await gameRepository.GetAllAsync();
        }

        public async Task<GameResponse> SaveAsync(Game game)
        {
            try{
                await gameRepository.AddAsync(game);
                await unitOfWork.CompleteAsync();
                return new GameResponse(game);
            }
            catch(Exception ex){
                return new GameResponse($"Error while saving genre! Message:{ex.Message}");
            }
        }

        public async Task<GameResponse> UpdateAsync(int id, Game game)
        {
            var existingUser = await gameRepository.FindById(id);
            if (existingUser == null)
                return new GameResponse("User not found");
           
            try
            {
                gameRepository.Update(existingUser);
                await unitOfWork.CompleteAsync();

                return new GameResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new GameResponse($"Error when updating user: {ex.Message}");
            }
        }
    }
}