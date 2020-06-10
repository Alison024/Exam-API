using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class SaleService:ISaleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISaleRepository saleRepository;
        public SaleService(IUnitOfWork unitOfWork, ISaleRepository saleRepository){
            this.unitOfWork =unitOfWork;
            this.saleRepository =saleRepository;
        } 

        public async Task<SaleResponse> DeleteAsync(int id)
        {
            var existingSale = await saleRepository.FindById(id);
            if (existingSale == null)
                return new SaleResponse("User not found");
            try
            {
                saleRepository.Delete(existingSale);
                await unitOfWork.CompleteAsync();

                return new SaleResponse(existingSale);
            }
            catch (Exception ex)
            {
                return new SaleResponse($"Error when deleting sale: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await saleRepository.GetAllAsync();
        }

        public async Task<SaleResponse> SaveAsync(Sale sale)
        {
            try{
                await saleRepository.AddAsync(sale);
                await unitOfWork.CompleteAsync();
                return new SaleResponse(sale);
            }
            catch(Exception ex){
                return new SaleResponse($"Error while saving sale! Message:{ex.Message}");
            }
            
        }

        public async Task<SaleResponse> UpdateAsync(Sale sale)
        {
            var existingSale = await saleRepository.FindById(sale.SaleId);
            if (existingSale == null)
                return new SaleResponse("Sale not found");
            
            try
            {
                saleRepository.Update(existingSale);
                await unitOfWork.CompleteAsync();

                return new SaleResponse(existingSale);
            }
            catch (Exception ex)
            {
                return new SaleResponse($"Error when updating sale: {ex.Message}");
            }
        }
    }
}