using System.Threading.Tasks;
using ITS.Repository.Implements.Context;
using ITS.Repository.Implements.PerEntities;
using ITS.Repository.Interface.Base;
using ITS.Repository.Interface.PerEntities;
using Microsoft.Extensions.Configuration;

namespace ITS.Repository.Implements.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private readonly IConfiguration _configuration;
        private IPersonRepository _person;
        private ICategoryRepository _category;
        private IContactRepository _contact;
        private ICategoryDetailRepository _categoryDetail;
        private IContactAddressRepository _contactAddress;
        private IContactEmailRepository _contactEmail;
        private IContactPhoneRepository _contactPhone;
        private IContactTagRepository _contactTag;
        private IContactWebLinkRepository _contactWebLink;
        private ITagRepository _tag;

        public ITagRepository Tag
        {
            get
            {
                if (_tag != null) return _tag;
                {
                    _tag = new TagRepository(_repoContext);
                    return _tag;
                }
            }
        }
        public IContactWebLinkRepository ContactWebLink
        {
            get
            {
                if (_contactWebLink != null) return _contactWebLink;
                {
                    _contactWebLink = new ContactWebLinkRepository(_repoContext);
                    return _contactWebLink;
                }
            }
        }
        public IContactTagRepository ContactTag
        {
            get
            {
                if (_contactTag != null) return _contactTag;
                {
                    _contactTag = new ContactTagRepository(_repoContext);
                    return _contactTag;
                }
            }
        }
        public IContactPhoneRepository ContactPhone
        {
            get
            {
                if (_contactPhone != null) return _contactPhone;
                {
                    _contactPhone = new ContactPhoneRepository(_repoContext);
                    return _contactPhone;
                }
            }
        }
        public IContactEmailRepository ContactEmail
        {
            get
            {
                if (_contactEmail != null) return _contactEmail;
                {
                    _contactEmail = new ContactEmailRepository(_repoContext);
                    return _contactEmail;
                }
            }
        }
        public IContactAddressRepository ContactAddress
        {
            get
            {
                if (_contactAddress != null) return _contactAddress;
                {
                    _contactAddress = new ContactAddressRepository(_repoContext);
                    return _contactAddress;
                }
            }
        }
        public ICategoryDetailRepository CategoryDetail
        {
            get
            {
                if (_categoryDetail != null) return _categoryDetail;
                {
                    _categoryDetail = new CategoryDetailRepository(_repoContext);
                    return _categoryDetail;
                }
            }
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contact != null) return _contact;
                {
                    _contact = new ContactRepository(_repoContext);
                    return _contact;
                }
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category != null) return _category;
                _category = new CategoryRepository(_repoContext);
                return _category;
            }
        }
        public IPersonRepository Person
        {
            get
            {
                if (_person != null) return _person;
                _person = new PersonRepository(_repoContext, _configuration);
                return _person;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext, IConfiguration configuration)
        {
            _repoContext = repositoryContext;
            _configuration = configuration;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _repoContext.SaveChangesAsync();
        }
    }
}