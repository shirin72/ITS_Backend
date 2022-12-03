using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Category;
using ITS.QueryModel.Modules.Category;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Category
{
    public interface ICategoryDetailService
    {
        /// <summary>
        /// سرویس ثبت جزئیات دسته بندی
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateCategoryDetail(CreateCategoryDetailCommand command);

        /// <summary>
        /// سرویس ویرایش جزئیات دسته بندی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateCategoryDetail(UpdateCategoryDetailCommand command);

        /// <summary>
        /// سرویس حذف جزئیات دسته بندی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteCategoryDetail(int id);

        /// <summary>
        /// سرویس دریافت جزئیات دسته بندی با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryDetailDto> GetCategoryDetailById(int id);

        /// <summary>
        /// سرویس دریافت جزئیات دسته بندی ها
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CategoryDetailDto>> GetAllCategoryDetail();
    }
}