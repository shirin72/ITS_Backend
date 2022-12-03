using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS.Commands.Modules.Person;
using ITS.Infrastructure.Enums;
using ITS.QueryModel.Modules.Person;
using ITS.Service.Interface.Helper;

namespace ITS.Service.Interface.Modules.Person
{
    public interface IPersonService
    {
        /// <summary>
        /// سرویس ثبت شخص
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<RetrieveObject> CreatePerson(CreatePersonCommand command);

        /// <summary>
        /// سرویس ویرایش شخص 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<string> UpdatePerson(UpdatePersonCommand command);

        /// <summary>
        /// سرویس حذف شخص   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeletePerson(Guid id);

        /// <summary>
        /// سرویس دریافت شخص با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PersonDto> GetPersonById(Guid id);

        /// <summary>
        /// سرویس دربافت تمام اشخاص
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PersonDto>> GetAllPerson();


    }
}