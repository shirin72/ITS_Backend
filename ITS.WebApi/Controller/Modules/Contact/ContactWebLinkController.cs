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
    public class ContactWebLinkController : ControllerBase
    {
        private readonly IContactWebLinkService _contactWebLinkService;

        public ContactWebLinkController(IContactWebLinkService contactWebLinkService)
        {
            _contactWebLinkService = contactWebLinkService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactWebLinkCommand command)
        {
            command.Validate();
            var result = await _contactWebLinkService.CreateContactWebLink(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactWebLinkCommand command)
        {
            command.Validate();
            var result = await _contactWebLinkService.UpdateContactWebLink(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactWebLinkService.DeleteContactWebLink(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactWebLinkDto>> GetById(Guid id)
        {
            var result = await _contactWebLinkService.GetContactWebLinkById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactWebLinkDto>>> GetAll()
        {
            var result = await _contactWebLinkService.GetAllContactWebLink();
            return Ok(result);
        }
    }
}