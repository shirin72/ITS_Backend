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
    public class ContactAddressController : ControllerBase
    {
        private readonly IContactAddressService _contactAddressService;

        public ContactAddressController(IContactAddressService contactAddressService)
        {
            _contactAddressService = contactAddressService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactAddressCommand command)
        {
            command.Validate();
            var result = await _contactAddressService.CreateContactAddress(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactAddressCommand command)
        {
            command.Validate();
            var result = await _contactAddressService.UpdateContactAddress(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactAddressService.DeleteContactAddress(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactAddressDto>> GetById(Guid id)
        {
            var result = await _contactAddressService.GetContactAddressById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactAddressDto>>> GetAll()
        {
            var result = await _contactAddressService.GetAllContactAddress();
            return Ok(result);
        }
    }
}