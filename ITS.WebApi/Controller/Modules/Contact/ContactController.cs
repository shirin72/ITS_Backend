using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Contact;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Contact
{
    [ApiController, Route("api/[controller]/[action]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
       
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactCommand command)
        {
            command.Validate();
            var result = await _contactService.CreateContact(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactCommand command)
        {
            command.Validate();
            var result = await _contactService.UpdateContact(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactService.DeleteContact(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactDto>> GetById(Guid id)
        {
            var result = await _contactService.GetContactById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactDto>>> GetMyContacts()
        {
            
            var result = await _contactService.GetAllContact();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactDto>>> GetAll()
        {
            var result = await _contactService.GetAllContact();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactDto>>> GetAllInPool()
        {
            var result = await _contactService.GetAllContact();
            return Ok(result);
        }
    }
}