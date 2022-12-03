using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Person;
using ITS.QueryModel.Modules.Person;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Person;
using ITS.WebApi.Helper.Implement;
using Microsoft.AspNetCore.Authorization;   
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Controller.Modules.Person
{
    [ApiController, Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ICurrentUserService _currentUserService;

        public PersonController(IPersonService personService, ICurrentUserService currentUserService)
        {
            _personService = personService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ApiResult<RetrieveObject>> Create(CreatePersonCommand command)
        {
            command.Validate();
            //var s = _currentUserService.UserName;
            var res = await _personService.CreatePerson(command);
            //return await _resultHandler.Handle(result);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ApiResult> Update(UpdatePersonCommand command)
        {
            var result = _personService.UpdatePerson(command);
            //return await _resultHandler.Handle(result);
            return null;
        }

        [HttpDelete]
        public Task<ApiResult> Delete(Guid id)
        {
            var result = _personService.DeletePerson(id);
            //return _resultHandler.Handle(result);\
            return null;
        }

        [HttpGet]
        public async Task<ApiResult> Get(Guid id)
        {
            var res = await _personService.GetPersonById(id);
            //return await _resultHandler.Handle(res);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<IEnumerable<PersonDto>>> GetAll()
        {
            var res = await _personService.GetAllPerson();
            return Ok(res);
        }

    }
}