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
    public class CategoryDetailService : ICategoryDetailService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryDetailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت جزئیات دسته بندی
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateCategoryDetail(CreateCategoryDetailCommand command)
        {
            var categoryDetail = new CategoryDetailDataModel()
            {
                TitleFa = command.TitleFa,
                Title = command.Title,
                Code = command.Code,
                Key = command.Key,
                Value = command.Value,
                CategoryCode = command.CategoryCode,
                SiteCustomerId = command.SiteCustomerId
            };
            _repositoryWrapper.CategoryDetail.Create(categoryDetail);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = categoryDetail.Id,
                Message = OperationHelper.BooleanToOperationResult(operate).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش جزئیات دسته بندی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateCategoryDetail(UpdateCategoryDetailCommand command)
        {
            var categoryDetail = _repositoryWrapper.CategoryDetail.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();

            if (categoryDetail == null) throw new ServiceException(ErrorServiceMessage.CategoryDetailNotFound.GetDescription());
            {
                categoryDetail.TitleFa = command.TitleFa;
                categoryDetail.Title = command.Title;
                categoryDetail.Code = command.Code;
                categoryDetail.Key = command.Key;
                categoryDetail.Value = command.Value;
                categoryDetail.CategoryCode = command.CategoryCode;
                categoryDetail.SiteCustomerId = command.SiteCustomerId;
            }

            _repositoryWrapper.CategoryDetail.Update(categoryDetail);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس حذف جزئیات دسته بندی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteCategoryDetail(int id)
        {
            var categoryDetail = _repositoryWrapper.CategoryDetail.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (categoryDetail == null) throw new ServiceException(ErrorServiceMessage.CategoryDetailNotFound.GetDescription());
            categoryDetail.IsDeleted = true;
            _repositoryWrapper.CategoryDetail.Delete(categoryDetail);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت جزئیات دسته بندی با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryDetailDto> GetCategoryDetailById(int id)
        {
            var categoryDetail = _repositoryWrapper.CategoryDetail.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (categoryDetail == null) throw new ServiceException(ErrorServiceMessage.CategoryDetailNotFound.GetDescription());
            var dto = new CategoryDetailDto()
            {
                Id = categoryDetail.Id,
                TitleFa = categoryDetail.TitleFa,
                Title = categoryDetail.Title,
                Code = categoryDetail.Code,
                Key = categoryDetail.Key,
                Value = categoryDetail.Value,
                CategoryCode = categoryDetail.CategoryCode,
                SiteCustomerId = categoryDetail.SiteCustomerId
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت جزئیات دسته بندی ها
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryDetailDto>> GetAllCategoryDetail()
        {
            var categoryDetail = _repositoryWrapper.CategoryDetail.FindByCondition(i => i.IsDeleted != true);
            var dto = categoryDetail.Select(i => new CategoryDetailDto
            {
                Id = i.Id,
                TitleFa = i.TitleFa,
                Title = i.Title,
                Code = i.Code,
                Key = i.Key,
                Value = i.Value,
                CategoryCode = i.CategoryCode,
                SiteCustomerId = i.SiteCustomerId

            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}