using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Contact
{
    public interface IContactAddressService
    {
        /// <summary>
        /// سرویس ثبت آدرس مخاطب
        /// </summary>
        /// <returns></returns>
        Task<RetrieveObject> CreateContactAddress(CreateContactAddressCommand command);

        /// <summary>
        /// سرویس ویرایش آدرس مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdateContactAddress(UpdateContactAddressCommand command);

        /// <summary>
        /// سرویس حذف آدرس مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteContactAddress(Guid id);

        /// <summary>
        /// سرویس دریافت آدرس مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContactAddressDto> GetContactAddressById(Guid id);

        /// <summary>
        /// سرویس دریافت آدرس های مخاطب 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContactAddressDto>> GetAllContactAddress();
    }
}