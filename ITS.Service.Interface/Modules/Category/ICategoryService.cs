using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Category;
using ITS.QueryModel.Modules.Category;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Category
{
    public interface ICategoryService
    {
        /// <summary>
        /// سرویس ثبت دسته بندی
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateCategory(CreateCategoryCommand command);

        /// <summary>
        /// سرویس ویرایش دسته بندی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateCategory(UpdateCategoryCommand command);

        /// <summary>
        /// سرویس حذف دسته بندی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteCategory(int id);

        /// <summary>
        /// سرویس دریافت دسته بندی با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryDto> GetCategoryById(int id);

        /// <summary>
        /// سرویس دریافت دسته بندی ها
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CategoryDto>> GetAllCategory();
    }
}