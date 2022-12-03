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
    public class ContactPhoneController : ControllerBase
    {
        private readonly IContactPhoneService _contactPhoneService;

        public ContactPhoneController(IContactPhoneService contactPhoneService)
        {
            _contactPhoneService = contactPhoneService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactPhoneCommand command)
        {
            command.Validate();
            var result = await _contactPhoneService.CreateContactPhone(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactPhoneCommand command)
        {
            command.Validate();
            var result = await _contactPhoneService.UpdateContactPhone(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactPhoneService.DeleteContactPhone(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactPhoneDto>> GetById(Guid id)
        {
            var result = await _contactPhoneService.GetContactPhoneById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactPhoneDto>>> GetAll()
        {
            var result = await _contactPhoneService.GetAllContactPhone();
            return Ok(result);
        }
    }
}