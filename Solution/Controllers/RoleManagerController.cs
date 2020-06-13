using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace Solution.Controllers
{
    [Authorize(Roles="admin")]
    [Route("/api/rolemanager")]
    public class RoleManagerController:Controller
    {
        private readonly ICustomerRoleService customerRoleService;
        private readonly IMapper mapper;
        public RoleManagerController(ICustomerRoleService customerRoleService, IMapper mapper){
            this.customerRoleService = customerRoleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerRoleResource>> GetAllAsync(){
            var games = await customerRoleService.GetAllAsync();
            var roleResources = mapper.Map<IEnumerable<CustomerRole>,IEnumerable<CustomerRoleResource>>(games);
            return roleResources;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<CustomerRoleResource>> GetRolesOfCustomer(int id){
            var customerRoles = await customerRoleService.GetRolesOfCustomer(id);
            var customerResources = mapper.Map<IEnumerable<CustomerRole>,IEnumerable<CustomerRoleResource>>(customerRoles);
            return customerResources;
        }
    
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CustomerRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customersrole = mapper.Map<CustomerRoleResource, CustomerRole>(resource);
            var result = await customerRoleService.SaveAsync(customersrole);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<CustomerRole, CustomerRoleResource>(result.CustomerRole);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] CustomerRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customersrole = mapper.Map<CustomerRoleResource, CustomerRole>(resource);
            var result = await customerRoleService.UpdateAsync(customersrole);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var customerRoleResource = mapper.Map<CustomerRole, CustomerRoleResource>(result.CustomerRole);
            return Ok(customerRoleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromBody] CustomerRoleResource resource)
        {   
            var customersrole = mapper.Map<CustomerRoleResource, CustomerRole>(resource);
            var result = await customerRoleService.DeleteAsync(customersrole);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var customerRoleResource = mapper.Map<CustomerRole, CustomerRoleResource>(result.CustomerRole);
            return Ok(customerRoleResource);
        }
    }
}