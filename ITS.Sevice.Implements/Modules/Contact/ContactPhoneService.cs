using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.Domain.Entities.Contact;
using ITS.Infrastructure.Enums;
using ITS.Infrastructure.Exceptions;
using ITS.Infrastructure.Helpers;
using ITS.QueryModel.Modules.Contact;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Contact;

namespace ITS.Service.Implements.Modules.Contact
{
    public class ContactPhoneService : IContactPhoneService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactPhoneService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت تلفن مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContactPhone(CreateContactPhoneCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.ContactId && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());

            var contactPhone = new ContactPhoneDataModel()
            {
                Id = new Guid(),
                Contact = contact,
                Phone = command.Phone,
                PhoneTypeCode = command.PhoneTypeCode
            };
            _repositoryWrapper.ContactPhone.Create(contactPhone);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = contactPhone.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش تلفن مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContactPhone(UpdateContactPhoneCommand command)
        {
            var contactPhone = _repositoryWrapper.ContactPhone.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();
            if (contactPhone == null) throw new ServiceException(ErrorServiceMessage.ContactPhoneNotFound.GetDescription());
            contactPhone.Phone = command.Phone;
            contactPhone.PhoneTypeCode = command.PhoneTypeCode;
            _repositoryWrapper.ContactPhone.Update(contactPhone);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف تلفن مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContactPhone(Guid id)
        {
            var contactPhone = _repositoryWrapper.ContactPhone.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactPhone == null) throw new ServiceException(ErrorServiceMessage.ContactPhoneNotFound.GetDescription());
            contactPhone.IsDeleted = true;
            _repositoryWrapper.ContactPhone.Delete(contactPhone);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت تلفن مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactPhoneDto> GetContactPhoneById(Guid id)
        {
            var contactPhone = _repositoryWrapper.ContactPhone.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactPhone == null) throw new ServiceException(ErrorServiceMessage.ContactPhoneNotFound.GetDescription());
            var dto = new ContactPhoneDto()
            {
                Id = contactPhone.Id,
                Phone = contactPhone.Phone,
                PhoneTypeCode = contactPhone.PhoneTypeCode
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت تلفن های مخاطب 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactPhoneDto>> GetAllContactPhone()
        {
            var contactPhone = _repositoryWrapper.ContactPhone.FindByCondition(i=>i.IsDeleted != true);
            var dto = contactPhone.Select(i => new ContactPhoneDto()
            {
                Id = i.Id,
                Phone = i.Phone,
                PhoneTypeCode = i.PhoneTypeCode
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}