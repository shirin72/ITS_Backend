using IdentityServer4.EntityFramework.Options;
using ITS.Domain.Base;
using ITS.Domain.Entities.Category;
using ITS.Domain.Entities.Contact;
using ITS.Domain.Entities.Person;
using ITS.Domain.Entities.SiteCustomer;
using ITS.Domain.Entities.Tag;
using ITS.Repository.Implements.Identity;
using ITS.Repository.Interface.Base;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.Repository.Implements.Context
{
    public class RepositoryContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;
        public RepositoryContext(
            ICurrentUserService currentUserService,
           DbContextOptions<RepositoryContext> options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserName;
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.IsActive = true;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserName;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<PersonDataModel> Persons { get; set; }
        public DbSet<CategoryDataModel> Categories { get; set; }
        public DbSet<CategoryDetailDataModel> CategoryDetails { get; set; }
        public DbSet<ContactAddressDataModel> ContactAddress { get; set; }
        public DbSet<ContactDataModel> Contacts { get; set; }
        public DbSet<ContactOwnerDataModel> ContactOwner { get; set; }
        public DbSet<ContactMailDataModel> ContactMails { get; set; }
        public DbSet<ContactPhoneDataModel> ContactPhones { get; set; }
        public DbSet<ContactTagDataModel> ContactTags { get; set; }
        public DbSet<ContactWebLinkDataModel> ContactWebLinks { get; set; }
        public DbSet<SiteCustomerContractDataModel> SiteCustomerContracts { get; set; }
        public DbSet<SiteCustomerDataModel> SiteCustomers { get; set; }
        public DbSet<TagDataModel> Tags { get; set; }

        
    }
}