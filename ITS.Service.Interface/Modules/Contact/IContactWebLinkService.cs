using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactWebLinkService
    {
        /// <summary>
        /// سرویس ثبت لینک سایت مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContactWebLink(CreateContactWebLinkCommand command);

        /// <summary>
        /// سرویس ویرایش لینک سایت مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContactWebLink(UpdateContactWebLinkCommand command);

        /// <summary>
        /// سرویس حذف لینک سایت مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContactWebLink(Guid id);

        /// <summary>
        /// سرویس دریافت لینک سایت مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactWebLinkDto> GetContactWebLinkById(Guid id);

        /// <summary>
        /// سرویس دریافت لینک سایت های مخاطب 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactWebLinkDto>> GetAllContactWebLink();
    }
}