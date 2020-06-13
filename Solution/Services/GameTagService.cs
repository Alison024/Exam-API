using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class GameTagService:IGameTagService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameTagRepository gameTagRepository;
        public GameTagService(IUnitOfWork unitOfWork, IGameTagRepository gameTagRepository){
            this.unitOfWork =unitOfWork;
            this.gameTagRepository =gameTagRepository;
        } 

        public async Task<GameTagResponse> DeleteAsync(GameTag gameTag)
        {
            var existingGameTag = await gameTagRepository.FindByCompatibleKey(gameTag.GameId,gameTag.TagId);
            if (existingGameTag == null)
                return new GameTagResponse("Game tag not found");
            try
            {
                gameTagRepository.Delete(existingGameTag);
                await unitOfWork.CompleteAsync();

                return new GameTagResponse(existingGameTag);
            }
            catch (Exception ex)
            {
                return new GameTagResponse($"Error when deleting game's tag: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GameTag>> GetAllAsync()
        {
            return await gameTagRepository.GetAllAsync();
        }

        public async Task<IEnumerable<GameTag>> GetTagsOfGame(int id)
        {
            return await gameTagRepository.Find(id);
        }

        public async Task<GameTagResponse> SaveAsync(GameTag gameTag)
        {
            try{
                await gameTagRepository.AddAsync(gameTag);
                await unitOfWork.CompleteAsync();
                return new GameTagResponse(gameTag);
            }
            catch(Exception ex){
                return new GameTagResponse($"Error while saving game'tag. Message:{ex.Message}");
            }
            
        }

        public async Task<GameTagResponse> UpdateAsync(GameTag gameTag)
        {
            var existinggameTag = await gameTagRepository.FindByCompatibleKey(gameTag.GameId,gameTag.TagId);
            if (existinggameTag == null)
                return new GameTagResponse("Game tag not found");
            
            try
            {
                gameTagRepository.Update(existinggameTag);
                await unitOfWork.CompleteAsync();

                return new GameTagResponse(existinggameTag);
            }
            catch (Exception ex)
            {
                return new GameTagResponse($"Error when updating game's tage: {ex.Message}");
            }
        }
    }
}