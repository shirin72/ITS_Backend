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
    public class ContactService : IContactService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ICurrentUserService _currentUserService;
        public ContactService(IRepositoryWrapper repositoryWrapper, ICurrentUserService currentUserService)
        {
            _repositoryWrapper = repositoryWrapper;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// سرویس ثبت مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContact(CreateContactCommand command)
        {
            var contact = new ContactDataModel()
            {
                Id = new Guid(),
                Title = command.Title,
                Name = command.Name,
                City = command.City,
                CompanyId = command.CompanyId,
                ContactTypeCode = command.ContactTypeCode,
                Country = command.Country,
                IsCompany = command.IsCompany,
                SiteCutomerId= _currentUserService.SiteCustomerId
            };
            _repositoryWrapper.Contact.Create(contact);
             var result = await _repositoryWrapper.SaveChangesAsync() > 0;

            if (!string.IsNullOrEmpty(command.Email) && result)
            {
                var email = new ContactMailDataModel()
                {
                    Contact = contact,
                    MailAddress = command.Email,

                };
                _repositoryWrapper.ContactEmail.Create(email);
                await _repositoryWrapper.SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(command.Phone) && result)
            {
                var phone = new ContactPhoneDataModel()
                {
                    Contact = contact,
                    Phone = command.Phone
                };
                _repositoryWrapper.ContactPhone.Create(phone);
                await _repositoryWrapper.SaveChangesAsync();
            }

            return new RetrieveObject()
            {
                Id = contact.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContact(UpdateContactCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());
            {
                contact.Title = command.Title;
                contact.Name = command.Name;
                contact.CompanyId = command.CompanyId;
                contact.City = command.City;
                contact.ContactTypeCode = command.ContactTypeCode;
                contact.IsCompany = contact.IsCompany;
                contact.Country = command.Country;
            }
            _repositoryWrapper.Contact.Update(contact);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContact(Guid id)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());
            contact.IsDeleted = true;
            _repositoryWrapper.Contact.Delete(contact);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactDto> GetContactById(Guid id)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());
            var dto = new ContactDto()
            {
                Id = contact.Id,
                Title = contact.Title,
                Name = contact.Name,
                City = contact.City,
                CompanyId = contact.CompanyId,
                ContactTypeCode = contact.ContactTypeCode,
                Country = contact.Country,
                IsCompany = contact.IsCompany,
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت همه مخاطب ها
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactDto>> GetAllContact()
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.IsDeleted == false && i.IsActive);
            var dto = contact.Select(i => new ContactDto()
            {
                Id = i.Id,
                Title = i.Title,
                Name = i.Name,
                City = i.City,
                CompanyId = i.CompanyId,
                ContactTypeCode = i.ContactTypeCode,
                Country = i.Country,
                IsCompany = i.IsCompany,

            }).ToList();
            return await Task.FromResult(dto);
        }

       
    }
}