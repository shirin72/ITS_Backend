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
    public class ContactTagService : IContactTagService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactTagService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت برچسب مخاطب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateContactTag(CreateContactTagCommand command)
        {
            var contact = _repositoryWrapper.Contact.FindByCondition(i => i.Id == command.ContactId && i.IsDeleted != true).FirstOrDefault();
            if (contact == null) throw new ServiceException(ErrorServiceMessage.ContactTagNotFound.GetDescription());
            var contactTag = new ContactTagDataModel()
            {
                Id = new Guid(),
                Contact = contact,
                TagId = command.TagId
            };
            _repositoryWrapper.ContactTag.Create(contactTag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = contactTag.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };

        }

        /// <summary>
        /// سرویس ویرایش برچسب مخاطب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateContactTag(UpdateContactTagCommand command)
        {
            var contactTag = _repositoryWrapper.ContactTag.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();
            if (contactTag == null) throw new ServiceException(ErrorServiceMessage.ContactTagNotFound.GetDescription());
            contactTag.TagId = command.TagId;
            _repositoryWrapper.ContactTag.Update(contactTag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف برچسب مخاطب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContactTag(Guid id)
        {
            var contactTag = _repositoryWrapper.ContactTag.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactTag == null) throw new ServiceException(ErrorServiceMessage.ContactTagNotFound.GetDescription());
            contactTag.IsDeleted = true;
            _repositoryWrapper.ContactTag.Delete(contactTag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت برچسب مخاطب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContactTagDto> GetContactTagById(Guid id)
        {
            var contactTag = _repositoryWrapper.ContactTag.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (contactTag == null) throw new ServiceException(ErrorServiceMessage.ContactTagNotFound.GetDescription());
            var dto = new ContactTagDto
            {
                Id = contactTag.Id,
                TagId = contactTag.TagId
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت برچسب های مخاطب 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactTagDto>> GetAllContactTag()
        {
            var contactTag = _repositoryWrapper.ContactTag.FindByCondition(i=>i.IsDeleted != true);
            var dto = contactTag.Select(i => new ContactTagDto()
            {
                Id = i.Id,
                TagId = i.TagId
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}