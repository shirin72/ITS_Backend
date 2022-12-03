using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactEmailService
    {
        /// <summary>
        /// سرویس ثبت ایمیل مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContactMail(CreateContactMailCommand command);

        /// <summary>
        /// سرویس ویرایش ایمیل مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContactMail(UpdateContactMailCommand command);

        /// <summary>
        /// سرویس حذف ایمیل مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContactMail(Guid id);

        /// <summary>
        /// سرویس دریافت ایمیل مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactMailDto> GetContactMailById(Guid id);

        /// <summary>
        /// سرویس دریافت ایمیل های مخاطب 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactMailDto>> GetAllContactMail();
    }
}