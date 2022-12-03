using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactPhoneService
    {
        /// <summary>
        /// سرویس ثبت تلفن مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContactPhone(CreateContactPhoneCommand command);

        /// <summary>
        /// سرویس ویرایش تلفن مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContactPhone(UpdateContactPhoneCommand command);

        /// <summary>
        /// سرویس حذف تلفن مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContactPhone(Guid id);

        /// <summary>
        /// سرویس دریافت تلفن مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactPhoneDto> GetContactPhoneById(Guid id);

        /// <summary>
        /// سرویس دریافت تلفن های مخاطب 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactPhoneDto>> GetAllContactPhone();
    }
}