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
    [Route("/api/roles")]
    public class RoleController:Controller
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<RoleResourse>> GetAllAsync()
        {
            var roles = await roleService.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Role>, IEnumerable<RoleResourse>>(roles);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RoleResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<RoleResourse, Role>(resource);
            var result = await roleService.SaveAsync(role);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var customerResource = mapper.Map<Role, RoleResourse>(result.Role);
            return Ok(customerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] RoleResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<RoleResourse, Role>(resource);
            var result = await roleService.UpdateAsync(role);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<Role, RoleResourse>(result.Role);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await roleService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<Role, RoleResourse>(result.Role);
            return Ok(userResource);
        }
    }
}