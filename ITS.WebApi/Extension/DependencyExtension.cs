using System.Reflection;
using ITS.Repository.Implements.Base;
using ITS.Repository.Interface.Base;
using ITS.Service.Implements.Modules.Category;
using ITS.Service.Implements.Modules.Contact;
using ITS.Service.Implements.Modules.Person;
using ITS.Service.Implements.Modules.Tag;
using ITS.Service.Interface.Modules.Category;
using ITS.Service.Interface.Modules.Contact;
using ITS.Service.Interface.Modules.Person;
using ITS.Service.Interface.Modules.Tag;
using ITS.WebApi.Helper.Default;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ITS.WebApi.Extension
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            AddExternals(services);
            AddRepositories(services);
            AddServices(services);
            AddHttpClients(services);
        }

        private static void AddHttpClients(IServiceCollection services)
        {
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IContactWebLinkService, ContactWebLinkService>();
            services.AddScoped<IContactTagService, ContactTagService>();
            services.AddScoped<IContactEmailService, ContactEmailService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDetailService, CategoryDetailService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactAddressService, ContactAddressService>();
            services.AddScoped<IContactPhoneService, ContactPhoneService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        private static void AddExternals(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(DefaultCommand)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(DefaultMapping)));
        }
    }
}