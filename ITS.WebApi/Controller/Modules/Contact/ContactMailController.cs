using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Contact;
using ITS.QueryModel.Modules.Contact;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Contact;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Contact
{
    [ApiController, Route("api/[controller]/[action]")]
    public class ContactMailController : ControllerBase
    {
        private readonly IContactEmailService _contactEmailService;

        public ContactMailController(IContactEmailService contactEmailService)
        {
            _contactEmailService = contactEmailService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactMailCommand command)
        {
            command.Validate();
            var result = await _contactEmailService.CreateContactMail(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactMailCommand command)
        {
            command.Validate();
            var result = await _contactEmailService.UpdateContactMail(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactEmailService.DeleteContactMail(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactMailDto>> GetById(Guid id)
        {
            var result = await _contactEmailService.GetContactMailById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactMailDto>>> GetAll()
        {
            var result = await _contactEmailService.GetAllContactMail();
            return Ok(result);
        }
    }
}