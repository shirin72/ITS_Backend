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
    public class ContactEmailService : IContactEmailService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactEmailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت ایمیل مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContactMail(CreateContactMailCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.ContactId && i.IsCompany != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactNotFound.GetDescription());

            var contactMail = new ContactMailDataModel()
            {
                Id = new Guid(),
                Contact = contact,
                MailAddress = command.MailAddress,
                MailTypeCode = command.MailTypeCode
            };
            _repositoryWrapper.ContactEmail.Create(contactMail);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = contactMail.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش ایمیل مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContactMail(UpdateContactMailCommand command)
        {
            var contactMail = _repositoryWrapper.ContactEmail.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactMail == null) throw new ServiceException(ErrorServiceMessage.ContactMailNotFound.GetDescription());

            contactMail.MailAddress = command.MailAddress;
            contactMail.MailTypeCode = command.MailTypeCode;
            _repositoryWrapper.ContactEmail.Update(contactMail);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف ایمیل مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContactMail(Guid id)
        {
            var contactMail = _repositoryWrapper.ContactEmail.FindByCondition(i => i.Id == id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactMail == null) throw new ServiceException(ErrorServiceMessage.ContactMailNotFound.GetDescription());
            contactMail.IsDeleted = true;
            _repositoryWrapper.ContactEmail.Delete(contactMail);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت ایمیل مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactMailDto> GetContactMailById(Guid id)
        {
            var contactMail = _repositoryWrapper.ContactEmail.FindByCondition(i => i.Id == id && i.IsDeleted != true)
                .FirstOrDefault();
            if (contactMail == null) throw new ServiceException(ErrorServiceMessage.ContactMailNotFound.GetDescription());
            var dto = new ContactMailDto()
            {
                Id = contactMail.Id,
                MailAddress = contactMail.MailAddress,
                MailTypeCode = contactMail.MailTypeCode
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت ایمیل های مخاطب 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactMailDto>> GetAllContactMail()
        {
            var contactMail = _repositoryWrapper.ContactEmail.FindByCondition(i => i.IsDeleted != true);
            var dto = contactMail.Select(i => new ContactMailDto()
            {
                Id = i.Id,
                MailAddress = i.MailAddress,
                MailTypeCode = i.MailTypeCode
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}