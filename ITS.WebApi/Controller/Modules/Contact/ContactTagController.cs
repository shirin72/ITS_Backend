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
    public class ContactTagController : ControllerBase
    {
        private readonly IContactTagService _contactTagService;

        public ContactTagController(IContactTagService contactTagService)
        {
            _contactTagService = contactTagService;
        }

        [HttpPost]
        public async Task<ApiResult<RetrieveObject>> Create(CreateContactTagCommand command)
        {
            command.Validate();
            var result = await _contactTagService.CreateContactTag(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ApiResult<string>> Update(UpdateContactTagCommand command)
        {
            command.Validate();
            var result = await _contactTagService.UpdateContactTag(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ApiResult<string>> Delete(Guid id)
        {
            var result = await _contactTagService.DeleteContactTag(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<ContactTagDto>> GetById(Guid id)
        {
            var result = await _contactTagService.GetContactTagById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<ContactTagDto>>> GetAll()
        {
            var result = await _contactTagService.GetAllContactTag();
            return Ok(result);
        }
    }
}