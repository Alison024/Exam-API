using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITagRepository tagRepository;
        public TagService(IUnitOfWork unitOfWork, ITagRepository tagRepository){
            this.unitOfWork =unitOfWork;
            this.tagRepository =tagRepository;
        } 
        public async Task<TagResponse> DeleteAsync(int id)
        {
            var existingTag = await tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("User not found");
            try
            {
                tagRepository.Delete(existingTag);
                await unitOfWork.CompleteAsync();

                return new TagResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new TagResponse($"Error when deleting tag: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await tagRepository.GetAllAsync();
        }

        public async Task<TagResponse> SaveAsync(Tag tag)
        {
            try{
                await tagRepository.AddAsync(tag);
                await unitOfWork.CompleteAsync();
                return new TagResponse(tag);
            }
            catch(Exception ex){
                return new TagResponse($"Error while saving tag! Message:{ex.Message}");
            }
            
        }

        public async Task<TagResponse> UpdateAsync(Tag tag)
        {
            var existingUser = await tagRepository.FindById(tag.TagId);
            if (existingUser == null)
                return new TagResponse("Tag not found");
            
            try
            {
                tagRepository.Update(existingUser);
                await unitOfWork.CompleteAsync();

                return new TagResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new TagResponse($"Error when updating tag: {ex.Message}");
            }
        }
    }
}