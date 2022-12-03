using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Category;
using ITS.QueryModel.Modules.Category;
using ITS.Service.Interface.Modules.Category;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Category
{
    [ApiController, Route("api/[controller]/[action]")]
    public class CategoryDetailController : ControllerBase
    {
        private readonly ICategoryDetailService _categoryDetailService;

        public CategoryDetailController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }

        [HttpPost]
        public async Task<ApiResult<string>> Create(CreateCategoryDetailCommand command)
        {
            command.Validate();
            var result = await _categoryDetailService.CreateCategoryDetail(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateCategoryDetailCommand command)
        {
            command.Validate();
            var result = await _categoryDetailService.UpdateCategoryDetail(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(int id)
        {
            var result = await _categoryDetailService.DeleteCategoryDetail(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<CategoryDetailDto>> Get(int id)
        {
            var result = await _categoryDetailService.GetCategoryDetailById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<CategoryDetailDto>>> GetAll()
        {
            var result = await _categoryDetailService.GetAllCategoryDetail();
            return Ok(result);
        }
    }
}