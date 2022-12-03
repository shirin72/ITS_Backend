using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Category;
using ITS.QueryModel.Modules.Category;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Category;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Category
{
    [ApiController, Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("a")]
        public async Task<ApiResult<RetrieveObject>> Create(CreateCategoryCommand command)
        {
            command.Validate();
            var result = await _categoryService.CreateCategory(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateCategoryCommand command)
        {
            command.Validate();
            var result = await _categoryService.UpdateCategory(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<CategoryDto>> Get(int id)
        {
            var result = await _categoryService.GetCategoryById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var result = await _categoryService.GetAllCategory();
            return Ok(result);
        }
    }
}