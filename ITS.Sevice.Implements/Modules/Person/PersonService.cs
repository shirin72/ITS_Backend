using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ITS.Commands.Modules.Person;
using ITS.Domain.Entities.Person;
using ITS.Infrastructure.Enums;
using ITS.Infrastructure.Exceptions;
using ITS.Infrastructure.Helpers;
using ITS.QueryModel.Modules.Person;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Person;

namespace ITS.Service.Implements.Modules.Person
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public PersonService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        /// <summary>
        /// سرویس ثبت شخص
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<RetrieveObject> CreatePerson(CreatePersonCommand command)
        {
            if (command.Birthdate >= DateTime.Now)
            {
                throw new ServiceException(ErrorServiceMessage.ErrorInRegisterPerson.GetDescription());
            }
            var person = new PersonDataModel()
            {
                Birthdate = command.Birthdate,
                Name = command.Name,
                Family = command.Family,
                Id = new Guid()
            };
            _repositoryWrapper.Person.Create(person);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = person.Id,
                Message = OperationHelper.BooleanToOperationResult(operate).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش شخص 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdatePerson(UpdatePersonCommand command)
        {
            var getData = _repositoryWrapper.Person.FindByCondition(i => i.Id == command.Id).FirstOrDefault();
            if (getData == null) throw new ServiceException(ErrorServiceMessage.PersonNotFound.GetDescription());
            getData.Name = command.Name;
            getData.Family = command.Family;
            getData.Birthdate = command.Birthdate;
            _repositoryWrapper.Person.Update(getData);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس حذف شخص   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeletePerson(Guid id)
        {
            var getData = _repositoryWrapper.Person.FindByCondition(i => i.Id == id).FirstOrDefault();
            if (getData == null) throw new ServiceException(ErrorServiceMessage.PersonNotFound.GetDescription());
            
            _repositoryWrapper.Person.Delete(getData);
            var operate = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(operate).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت شخص با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PersonDto> GetPersonById(Guid id)
        {
            var getData = _repositoryWrapper.Person.FindByCondition(i => i.Id == id).FirstOrDefault();
            if (getData == null) throw new ServiceException(ErrorServiceMessage.PersonNotFound.GetDescription());
            var person = new PersonDto()
            {
                Id = getData.Id,
                Name = getData.Name,
                Family = getData.Family,
                Birthdate = getData.Birthdate
            };
            return await Task.FromResult<PersonDto>(person);
        }

        /// <summary>
        /// سرویس دربافت تمام اشخاص
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PersonDto>> GetAllPerson()
        {
            var test = _repositoryWrapper.Person.GetAll<PersonDto>("sp_GetAllPerson", null);
            //var getData = _repositoryWrapper.Person.FindAll();
            //if (!getData.Any())
            //{
            //    throw new ServiceException(ErrorServiceMessage.NotFound.GetDescription());
            //}
            //var personDto = getData.Select(i => new PersonDto()
            //{
            //    Id = i.Id,
            //    Name = i.Name,
            //    Family = i.Family,
            //    Birthdate = i.Birthdate
            //}).Cast<PersonDto>().ToList();
            return await Task.FromResult<IEnumerable<PersonDto>>(test);
        }
    }
}