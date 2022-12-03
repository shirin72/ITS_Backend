using ITS.Domain.Entities.Contact;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class ContactPhoneRepository : RepositoryBase<ContactPhoneDataModel>, IContactPhoneRepository
    {
        public ContactPhoneRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}