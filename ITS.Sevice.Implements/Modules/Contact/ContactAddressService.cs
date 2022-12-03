using System;
using System.Collections;
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
    public class ContactAddressService : IContactAddressService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactAddressService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت آدرس مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContactAddress(CreateContactAddressCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.ContactId && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());

            var contactAddress = new ContactAddressDataModel()
            {
                Id = new Guid(),
                Contact = contact,
                Address = command.Address,
                AddressTypeCode = command.AddressTypeCode
            };
            _repositoryWrapper.ContactAddress.Create(contactAddress);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = contactAddress.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش آدرس مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContactAddress(UpdateContactAddressCommand command)
        {
            var contactAddress = _repositoryWrapper.ContactAddress.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactAddress == null) throw new ServiceException(ErrorServiceMessage.ContactAddressNotFound.GetDescription());

            contactAddress.Address = command.Address;
            contactAddress.AddressTypeCode = command.AddressTypeCode;
            _repositoryWrapper.ContactAddress.Update(contactAddress);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف آدرس مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContactAddress(Guid id)
        {
            var contactAddress = _repositoryWrapper.ContactAddress.FindByCondition(i => i.Id == id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactAddress == null) throw new ServiceException(ErrorServiceMessage.ContactAddressNotFound.GetDescription());
            contactAddress.IsDeleted = true;
            _repositoryWrapper.ContactAddress.Delete(contactAddress);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت آدرس مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactAddressDto> GetContactAddressById(Guid id)
        {
            var contactAddress = _repositoryWrapper.ContactAddress.FindByCondition(i => i.Id == id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactAddress == null) throw new ServiceException(ErrorServiceMessage.ContactAddressNotFound.GetDescription());
            var dto = new ContactAddressDto()
            {
                Id = contactAddress.Id,
                Address = contactAddress.Address,
                AddressTypeCode = contactAddress.AddressTypeCode
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت آدرس های مخاطب 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactAddressDto>> GetAllContactAddress()
        {
            var contactAddress = _repositoryWrapper.ContactAddress.FindByCondition(i => i.IsDeleted != true);
            var dto = contactAddress.Select(i => new ContactAddressDto()
            {
                Id = i.Id,
                Address = i.Address,
                AddressTypeCode = i.AddressTypeCode
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}