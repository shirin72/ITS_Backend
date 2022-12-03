using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ITS.Domain.Entities.Person;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ITS.Repository.Implements.PerEntities
{
    public class PersonRepository : RepositoryBase<PersonDataModel>, IPersonRepository
    {
        private readonly IConfiguration _configuration;
        public PersonRepository(RepositoryContext repositoryContext, IConfiguration configuration) : base(repositoryContext)
        {
            _configuration = configuration;
        }

        public void GetReport(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDataModel> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Person WHERE Id = @Id";
            //using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            //{
            //    connection.Open();
            //    var result = await connection.QuerySingleOrDefaultAsync<PersonDataModel>(sql, new { Id = id });
            //    return result;
            //}
            return null;
        }

        public List<T> GetAll<T>(string sp, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            var connectionString = _configuration["SqlConnection:connectionString"];
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<T>(sp, param, commandType: commandType).ToList();
        }
    }
}