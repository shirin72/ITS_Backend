using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactTagService
    {
        /// <summary>
        /// سرویس ثبت برچسب مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContactTag(CreateContactTagCommand command);

        /// <summary>
        /// سرویس ویرایش برچسب مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContactTag(UpdateContactTagCommand command);

        /// <summary>
        /// سرویس حذف برچسب مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContactTag(Guid id);

        /// <summary>
        /// سرویس دریافت برچسب مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactTagDto> GetContactTagById(Guid id);

        /// <summary>
        /// سرویس دریافت برچسب های مخاطب 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactTagDto>> GetAllContactTag();
    }
}