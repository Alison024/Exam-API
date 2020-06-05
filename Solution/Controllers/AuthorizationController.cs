
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Resources;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Solution.Controllers
{
    public class AuthorizationController:Controller
    {
        private readonly ICustomerService userService;
        public AuthorizationController(ICustomerService userService){
            this.userService = userService;
        }
        /*[AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult  Authenticate([FromBody] Customer customer){
            var user = userService.Authenticate(customer.Login, customer.Password);
            if(user==null)
            {
                return Ok(user);
            }
        }*/
    }
}