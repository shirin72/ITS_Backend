using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactService
    {
        /// <summary>
        /// سرویس ثبت مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContact(CreateContactCommand command);

        /// <summary>
        /// سرویس ویرایش مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContact(UpdateContactCommand command);

        /// <summary>
        /// سرویس حذف مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContact(Guid id);

        /// <summary>
        /// سرویس دریافت مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactDto> GetContactById(Guid id);

        /// <summary>
        /// سرویس دریافت مخاطب ها
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactDto>> GetAllContact();
    }
}