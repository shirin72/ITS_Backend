using ITS.Domain.Entities.Contact;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class ContactTagRepository : RepositoryBase<ContactTagDataModel>, IContactTagRepository
    {
        public ContactTagRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}