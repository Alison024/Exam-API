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

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await genreRepository.GetAllAsync();
        }

        public async Task<SaveGenreResponse> SaveAsync(Genre genre)
        {
            try{
                await genreRepository.AddAsync(genre);
                await unitOfWork.CompleteAsync();
                return new SaveGenreResponse(genre);
            }
            catch(Exception ex){
                return new SaveGenreResponse($"Error while saving genre! Message:{ex.Message}");
            }
            
        }
    }
}