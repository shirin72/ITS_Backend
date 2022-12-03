using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Tag;
using ITS.QueryModel.Modules.Tag;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Tag
{
    public interface ITagService
    {
        /// <summary>
        /// سرویس ثبت برچسب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateTag(CreateTagCommand command);

        /// <summary>
        /// سرویس ویرایش برچسب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateTag(UpdateTagCommand command);

        /// <summary>
        /// سرویس حذف برچسب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        Task<string> DeleteTag(int id);

        /// <summary>
        /// سرویس دریافت برچسب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TagDto> GetTagById(int id);

        /// <summary>
        /// سرویس دریافت برچسب ها
        /// </summary>  
        /// <returns></returns>
        Task<IEnumerable<TagDto>> GetAllTag();
    }
}