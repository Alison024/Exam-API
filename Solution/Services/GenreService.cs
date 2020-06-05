using System;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using Solution.Persistence.Repositories;
namespace Solution.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenreRepository genreRepository; 
        public GenreService(IGenreRepository genreRepository,IUnitOfWork unit)
        {
            unitOfWork = unit;
            this.genreRepository = genreRepository;
        }

        public async Task<GenreResponse> DeleteAsync(int id)
        {
            var existingUser = await genreRepository.FindById(id);
            if (existingUser == null)
                return new GenreResponse("User not found");
            try
            {
                genreRepository.Delete(existingUser);
                await unitOfWork.CompleteAsync();

                return new GenreResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new GenreResponse($"Error when deleting user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await genreRepository.GetAllAsync();
        }

        public async Task<GenreResponse> SaveAsync(Genre genre)
        {
            try{
                await genreRepository.AddAsync(genre);
                await unitOfWork.CompleteAsync();
                return new GenreResponse(genre);
            }
            catch(Exception ex){
                return new GenreResponse($"Error while saving genre! Message:{ex.Message}");
            }
            
        }

        public async Task<GenreResponse> UpdateAsync(int id, Genre genre)
        {
            var existingUser = await genreRepository.FindById(id);
            if (existingUser == null)
                return new GenreResponse("User not found");
            
            try
            {
                genreRepository.Update(existingUser);
                await unitOfWork.CompleteAsync();

                return new GenreResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new GenreResponse($"Error when updating user: {ex.Message}");
            }
        }
    }
}