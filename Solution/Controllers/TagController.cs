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
    [Route("/api/tags")]
    public class TagController:Controller
    {
        private readonly ITagService tagService;
        private readonly IMapper mapper;
        public TagController(ITagService tagService,IMapper mapper){
            this.tagService = tagService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResourse>> GetAllAsync(){
            var tags = await tagService.GetAllAsync();
            var tagResourses = mapper.Map<IEnumerable<Tag>,IEnumerable<TagResourse>>(tags);
            return tagResourses;
        }
        [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TagResourse resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            var tag = mapper.Map<TagResourse,Tag>(resource);
            var result = await tagService.SaveAsync(tag);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            var tagResourses = mapper.Map<Tag,TagResourse>(result.Tag);
            return Ok(tagResourses);
        }
        [Authorize(Roles="admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] TagResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tag = mapper.Map<TagResourse, Tag>(resource);
            var result = await tagService.UpdateAsync(tag);

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var tagResourses = mapper.Map<Tag, TagResourse>(result.Tag);
            return Ok(tagResourses);
        }
        [Authorize(Roles="admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await tagService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            
            var tagResourses = mapper.Map<Tag, TagResourse>(result.Tag);
            return Ok(tagResourses);
        }
    }
}