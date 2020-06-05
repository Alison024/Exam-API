using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork){
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var exsCustomer = await customerRepository.FindById(id);
            if (exsCustomer == null)
                return new CustomerResponse("User not found");
            try
            {
                customerRepository.Delete(exsCustomer);
                await unitOfWork.CompleteAsync();

                return new CustomerResponse(exsCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"Error when deleting user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await customerRepository.GetAllAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
             try
            {
                await customerRepository.AddAsync(customer);
                await unitOfWork.CompleteAsync();

                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"Error when saving the user: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingUser = await customerRepository.FindById(id);
            if (existingUser == null)
                return new CustomerResponse("User not found");
            
            try
            {
                customerRepository.Update(existingUser);
                await unitOfWork.CompleteAsync();

                return new CustomerResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"Error when updating user: {ex.Message}");
            }
        }
    }
}