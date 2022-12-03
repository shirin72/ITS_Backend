using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using ITS.Domain.Entities.Person;
using ITS.Repository.Interface.Base;

namespace ITS.Repository.Interface.PerEntities
{
    public interface IPersonRepository : IRepositoryBase<PersonDataModel>
    {
     
        void GetReport(Guid id);

        Task<PersonDataModel> GetByIdAsync(Guid id);

        List<T> GetAll<T>(string sp, DynamicParameters param,
                CommandType commandType = CommandType.StoredProcedure);
       
    }
}