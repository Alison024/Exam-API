using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using System;
namespace Solution.Services
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;
        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository){
            this.unitOfWork =unitOfWork;
            this.roleRepository =roleRepository;
        } 

        public async Task<RoleResponse> DeleteAsync(int id)
        {
            var existingRole = await roleRepository.FindById(id);
            if (existingRole == null)
                return new RoleResponse("Customer's roles not found");
            try
            {
                roleRepository.Delete(existingRole);
                await unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"Error when deleting customer's role: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await roleRepository.GetAllAsync();
        }

        public async Task<RoleResponse> SaveAsync(Role role)
        {
            try{
                await roleRepository.AddAsync(role);
                await unitOfWork.CompleteAsync();
                return new RoleResponse(role);
            }
            catch(Exception ex){
                return new RoleResponse($"Error while saving role. Message:{ex.Message}");
            }
            
        }

        public async Task<RoleResponse> UpdateAsync(Role role)
        {
            var existingRole = await roleRepository.FindById(role.RoleId);
            if (existingRole == null)
                return new RoleResponse("Customer role not found");
            
            try
            {
                roleRepository.Update(existingRole);
                await unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"Error when updating role: {ex.Message}");
            }
        }
    }
}