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
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
           return await gameRepository.GetAllAsync();
        }

        public async Task<SaveGameResponse> SaveAsync(Game game)
        {
            try{
                await gameRepository.AddAsync(game);
                await unitOfWork.CompleteAsync();
                return new SaveGameResponse(game);
            }
            catch(Exception ex){
                return new SaveGameResponse($"Error while saving genre! Message:{ex.Message}");
            }
        }

        public async Task<SaveGameResponse> UpdateAsync(int id, Game game)
        {
            //throw new NotImplementedException();
            var exsGame = await gameRepository.FindByIdAsync(id);
            if(exsGame==null){
                return new SaveGameResponse("Game not found");
            }
            exsGame.Name = game.Name;
            exsGame.Price = game.Price;
            exsGame.GenreId = game.GenreId;
            exsGame.Description = game.Description;
            try{
                gameRepository.Update(exsGame);
                await unitOfWork.CompleteAsync();
                return new SaveGameResponse(exsGame);
            }catch(Exception ex){
                return new SaveGameResponse($"Error when updating game:{ex.Message}");
            }
        }
    }
}