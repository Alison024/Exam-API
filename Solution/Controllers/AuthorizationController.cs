using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Domain.Responses;
using Solution.Resources;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Solution.Controllers
{
    [Route("/api/auth")]
    public class AuthorizationController:Controller
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        public AuthorizationController(IAuthService authService, IMapper mapper){
            this.authService = authService;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Customer customer){
            var customer1 = await authService.Authenticate(customer.Login, customer.Password);
            var result = mapper.Map<Customer, CustomerResourse>(customer1);
            var response = new ResponseDate
            {
                Success = result != null,
                Message = result != null ? "" : "Incorrect login or password",
                Data = result
            };

            return Ok(response);
        }
    }
}