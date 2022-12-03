using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Tag;
using ITS.QueryModel.Modules.Tag;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Tag;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Tag
{
    [ApiController, Route("api/[controller]/[action]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateTagCommand command)
        {
            command.Validate();
            var result = await _tagService.CreateTag(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateTagCommand command)
        {
            command.Validate();
            var result = await _tagService.UpdateTag(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(int id)
        {
            var result = await _tagService.DeleteTag(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<TagDto>> GetById(int id)
        {
            var result = await _tagService.GetTagById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<TagDto>>> GetAll()
        {
            var result = await _tagService.GetAllTag();
            return Ok(result);
        }
    }
}