using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.IRepositories;
using Solution.Domain.Responses;
using Solution.Extensions;
using Solution.Helpers;



namespace Solution.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings appSettings;
        private readonly ICustomerRepository customerRepository;
        public AuthService(IOptions<AppSettings> appSettings,  ICustomerRepository customerRepository){
            this.appSettings = appSettings.Value;
            this.customerRepository = customerRepository;
        }
        public async Task<Customer> Authenticate(string login, string password)
        {
            var customer = (await customerRepository.GetAllAsync())
                                .SingleOrDefault(usr => usr.Login == login && usr.Password == password);  
            if (customer == null)
                return null;

            customer.GenerateToken(appSettings.Secret, appSettings.ExpiresMinutes);

            return customer;
        }
    }
}