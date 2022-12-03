using System;
using ITS.Repository.Implements.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.Base;
using ITS.WebApi.Helper.Implement;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ITS.Repository.Implements.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ITS.WebApi.Extension;

namespace ITS.WebApi
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA22iNivDm2sGbMRdRj1PVRj1kHhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["SqlConnection:connectionString"];
            services.AddDbContext<RepositoryContext>(i => i.UseSqlServer(connectionString));
            //services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddScoped<IPersonService, PersonService>();
            services.AddDependencies();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<RepositoryContext>();
            services.AddSwaggerGen();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, RepositoryContext>();
            services.AddAuthentication().AddIdentityServerJwt();
            services.AddHttpContextAccessor();



            // Configure JwtIssuerOptions
            services.AddScoped<IJwtFactoryBussiness, JwtFactoryBussiness>();
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            var st = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)]; ;
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha512);
            });



            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });


            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("Company", policy => policy.RequireClaim(ClaimTypes.Role, "Company"));
            });

            services.AddCors();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();

            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ITS API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var context = scope.ServiceProvider.GetService<RepositoryContext>();
                context.Database.Migrate();
                DbInitializer.EnsureDatabaseSeeded(context, userManager, roleManager).Wait();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var context = scope.ServiceProvider.GetService<RepositoryContext>();
                context.Database.Migrate();
                DbInitializer.EnsureDatabaseSeeded(context, userManager, roleManager).Wait();
            }
        }
    }
}
