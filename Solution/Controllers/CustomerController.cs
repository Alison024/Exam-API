using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;

namespace Solution.Controllers
{
    [Route("/api/customers")]
    public class CustomerController:Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<CustomerResourse>> GetAllAsync()
        {
            var customers = await customerService.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResourse>>(customers);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthCustomerResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = mapper.Map<AuthCustomerResourse, Customer>(resource);
            var result = await customerService.SaveAsync(customer);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var customerResource = mapper.Map<Customer, CustomerResourse>(result.Customer);
            return Ok(customerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] AuthCustomerResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = mapper.Map<AuthCustomerResourse, Customer>(resource);
            var result = await customerService.UpdateAsync(customer);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<Customer, CustomerResourse>(result.Customer);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await customerService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<Customer, CustomerResourse>(result.Customer);
            return Ok(userResource);
        }
    }
}