using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class CustomerRoleService:ICustomerRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICustomerRoleRepository customerRoleRepository;
        public CustomerRoleService(IUnitOfWork unitOfWork, ICustomerRoleRepository customerRoleRepository){
            this.unitOfWork =unitOfWork;
            this.customerRoleRepository =customerRoleRepository;
        } 

        public async Task<CustomerRoleResponse> DeleteAsync(int id)
        {
            var existingcustomerRole = await customerRoleRepository.FindById(id);
            if (existingcustomerRole == null)
                return new CustomerRoleResponse("Customer's roles not found");
            try
            {
                customerRoleRepository.Delete(existingcustomerRole);
                await unitOfWork.CompleteAsync();

                return new CustomerRoleResponse(existingcustomerRole);
            }
            catch (Exception ex)
            {
                return new CustomerRoleResponse($"Error when deleting customer's role: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CustomerRole>> GetAllAsync()
        {
            return await customerRoleRepository.GetAllAsync();
        }

        public async Task<CustomerRoleResponse> SaveAsync(CustomerRole customerRole)
        {
            try{
                await customerRoleRepository.AddAsync(customerRole);
                await unitOfWork.CompleteAsync();
                return new CustomerRoleResponse(customerRole);
            }
            catch(Exception ex){
                return new CustomerRoleResponse($"Error while saving customer's role. Message:{ex.Message}");
            }
            
        }

        public async Task<CustomerRoleResponse> UpdateAsync(CustomerRole gameTag)
        {
            var existingcustomerRole = await customerRoleRepository.FindById(gameTag.CustomerId);
            if (existingcustomerRole == null)
                return new CustomerRoleResponse("Customer role not found");
            
            try
            {
                customerRoleRepository.Update(existingcustomerRole);
                await unitOfWork.CompleteAsync();

                return new CustomerRoleResponse(existingcustomerRole);
            }
            catch (Exception ex)
            {
                return new CustomerRoleResponse($"Error when updating customer's role: {ex.Message}");
            }
        }
    }
}