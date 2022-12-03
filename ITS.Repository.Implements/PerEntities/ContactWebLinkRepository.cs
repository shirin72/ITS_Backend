using ITS.Domain.Entities.Contact;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class ContactWebLinkRepository : RepositoryBase<ContactWebLinkDataModel>, IContactWebLinkRepository
    {
        public ContactWebLinkRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}