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
    public class ContactWebLinkService : IContactWebLinkService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactWebLinkService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت لینک سایت مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContactWebLink(CreateContactWebLinkCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.ContactId && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());

            var contactWebLink = new ContactWebLinkDataModel()
            {
                Id = new Guid(),
                Contact = contact,
                AddressTypeCode = command.AddressTypeCode,
                Address = command.Address
            };
            _repositoryWrapper.ContactWebLink.Create(contactWebLink);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = contactWebLink.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };

        }

        /// <summary>
        /// سرویس ویرایش لینک سایت مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContactWebLink(UpdateContactWebLinkCommand command)
        {
            var contactWebLink = _repositoryWrapper.ContactWebLink.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();
            if (contactWebLink == null) throw new ServiceException(ErrorServiceMessage.ContactWebLinkNotFound.GetDescription());
            contactWebLink.Address = command.Address;
            contactWebLink.AddressTypeCode = command.AddressTypeCode;
            _repositoryWrapper.ContactWebLink.Update(contactWebLink);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف لینک سایت مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContactWebLink(Guid id)
        {
            var contactWebLink = _repositoryWrapper.ContactWebLink.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactWebLink == null) throw new ServiceException(ErrorServiceMessage.ContactWebLinkNotFound.GetDescription());
            contactWebLink.IsDeleted = true;
            _repositoryWrapper.ContactWebLink.Delete(contactWebLink);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت لینک سایت مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactWebLinkDto> GetContactWebLinkById(Guid id)
        {
            var contactWebLink = _repositoryWrapper.ContactWebLink.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactWebLink == null) throw new ServiceException(ErrorServiceMessage.ContactWebLinkNotFound.GetDescription());
            var dto = new ContactWebLinkDto
            {
                Id = contactWebLink.Id,
                Address = contactWebLink.Address,
                AddressTypeCode = contactWebLink.AddressTypeCode
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت لینک سایت های مخاطب 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactWebLinkDto>> GetAllContactWebLink()
        {
            var contactWebLink = _repositoryWrapper.ContactWebLink.FindByCondition(i => i.IsDeleted != true);
            var dto = contactWebLink.Select(i => new ContactWebLinkDto
            {
                Id = i.Id,
                Address = i.Address,
                AddressTypeCode = i.AddressTypeCode
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}