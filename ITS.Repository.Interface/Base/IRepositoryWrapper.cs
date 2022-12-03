using System.Threading.Tasks;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Interface.Base
{
    public interface IRepositoryWrapper
    {
        ITagRepository Tag { get; }
        IContactWebLinkRepository ContactWebLink { get; }
        IContactTagRepository ContactTag { get; }
        IContactPhoneRepository ContactPhone { get; }
        IContactEmailRepository ContactEmail { get; }
        IContactAddressRepository ContactAddress { get; }
        ICategoryDetailRepository CategoryDetail { get; }
        IContactRepository Contact { get; }
        ICategoryRepository Category { get; }
        IPersonRepository Person { get; }
        void Save();
        Task<int> SaveChangesAsync();
    }
}