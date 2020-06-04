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

        public async Task<SaveGenreResponse> UpdateAsync(int id, Genre genre)
        {
            var exsGenre = await genreRepository.FindByIdAsync(id);
            if(exsGenre==null){
                return new SaveGenreResponse("Genre not found");
            }
            exsGenre.Name = genre.Name;
            exsGenre.Description = genre.Description;
            try{
                genreRepository.Update(exsGenre);
                await unitOfWork.CompleteAsync();
                return new SaveGenreResponse(exsGenre);
            }catch(Exception ex){
                return new SaveGenreResponse($"Error when updating game:{ex.Message}");
            }
        }
    }
}