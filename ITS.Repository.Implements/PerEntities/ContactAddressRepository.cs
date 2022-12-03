using ITS.Domain.Entities.Contact;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class ContactAddressRepository : RepositoryBase<ContactAddressDataModel>, IContactAddressRepository
    {
        public ContactAddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}