using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.Commands.Modules.Category;
using ITS.Domain.Entities.Category;
using ITS.Infrastructure.Enums;
using ITS.Infrastructure.Exceptions;
using ITS.Infrastructure.Helpers;
using ITS.QueryModel.Modules.Category;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Category;

namespace ITS.Service.Implements.Modules.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت دسته بندی
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateCategory(CreateCategoryCommand command)
        {
            var category = new CategoryDataModel()
            {
                Code = command.Code,
                IsSystematic = command.IsSystematic,
                Key = command.Key,
                Title = command.Title,
                TitleFa = command.TitleFa
            };
            _repositoryWrapper.Category.Create(category);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = category.Id,
                Message = OperationHelper.BooleanToOperationResult(operate).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش دسته بندی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateCategory(UpdateCategoryCommand command)
        {
            var category = _repositoryWrapper.Category.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();

            if (category == null) throw new ServiceException(ErrorServiceMessage.CategoryNotFound.GetDescription());
            {
                category.Code = command.Code;
                category.Title = command.Title;
                category.TitleFa = command.TitleFa;
                category.IsSystematic = command.IsSystematic;
                category.Key = command.Key;
            }

            _repositoryWrapper.Category.Update(category);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس حذف دسته بندی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteCategory(int id)
        {
            var category = _repositoryWrapper.Category.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (category == null) throw new ServiceException(ErrorServiceMessage.CategoryNotFound.GetDescription());
            category.IsDeleted = true;
            _repositoryWrapper.Category.Delete(category);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت دسته بندی با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = _repositoryWrapper.Category.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (category == null) throw new ServiceException(ErrorServiceMessage.CategoryNotFound.GetDescription());
            var dto = new CategoryDto()
            {
                Id = category.Id,
                TitleFa = category.TitleFa,
                Key = category.Key,
                Title = category.Title,
                IsSystematic = category.IsSystematic,
                Code = category.Code
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت دسته بندی ها
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var category = _repositoryWrapper.Category.FindByCondition(i=>i.IsDeleted != true);
            var dto = category.Select(i => new CategoryDto()
            {
                Id = i.Id,
                TitleFa = i.TitleFa,
                Key = i.Key,
                Title = i.Title,
                IsSystematic = i.IsSystematic,
                Code = i.Code
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}