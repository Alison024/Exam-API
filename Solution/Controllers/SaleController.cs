using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Models;
using Solution.Domain.IServices;
using Solution.Domain.Responses;
using Solution.Resources;
using System.Threading.Tasks;
using Solution.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace Solution.Controllers
{
    public class SaleController:Controller
    {
        private readonly ISaleService saleService;
        private readonly IMapper mapper;
        public SaleController(ISaleService saleService,IMapper mapper){
            this.saleService = saleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleResourse>> GetAllAsync(){
            var sales = await saleService.GetAllAsync();
            var saleResources = mapper.Map<IEnumerable<Sale>,IEnumerable<SaleResourse>>(sales);
            return saleResources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaleResourse resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var sale = mapper.Map<SaleResourse,Sale>(resource);
            var result = await saleService.SaveAsync(sale);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            var saleResources = mapper.Map<Sale,SaleResourse>(result.Sale);
            return Ok(saleResources);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] SaleResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sale = mapper.Map<SaleResourse, Sale>(resource);
            var result = await saleService.UpdateAsync(sale);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var saleResources = mapper.Map<Sale, SaleResourse>(result.Sale);
            return Ok(saleResources);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await saleService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var saleResources = mapper.Map<Sale, SaleResourse>(result.Sale);
            return Ok(saleResources);
        }
    }
}