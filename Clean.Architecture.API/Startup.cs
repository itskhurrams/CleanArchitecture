using Clean.Architecture.Application.Customer;
using Clean.Architecture.Application.Defination;
using Clean.Architecture.Application.Interfaces.Application.Customer;
using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using Clean.Architecture.Application.User;
using Clean.Architecture.Domain.Interfaces.Customer;
using Clean.Architecture.Domain.Interfaces.Defination;
using Clean.Architecture.Domain.Interfaces.User;
using Clean.Architecture.Infastructure.Logging;
using Clean.Architecture.Persistance.Customer;
using Clean.Architecture.Persistance.Defination;
using Clean.Architecture.Persistance.User;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data;

namespace Clean.Architecture.API {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            #region CORS
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            #endregion

            #region Database
            services.AddScoped<IDbConnection>(sp => {
                var config = sp.GetRequiredService<IConfiguration>();
                var connStr = config["Data:ConnectionString"]
                    ?? config.GetConnectionString("DefaultConnection")
                    ?? "Server=localhost;Database=CleanArchitectureDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
                return new SqlConnection(connStr);
            });
            #endregion

            #region Logging
            services.AddSingleton<ILoggerManager, LoggerManager>();
            #endregion

            #region Data Persistence Layer
            services.AddScoped<IAddressTypeData, AddressTypeData>();
            services.AddScoped<IAdminAccountData, AdminAccountData>();
            services.AddScoped<IBusinessTypeData, BusinessTypeData>();
            services.AddScoped<IMeritalStatusData, MeritalStatusData>();
            services.AddScoped<IPackageData, PackageData>();
            services.AddScoped<IPrefixData, PrefixData>();
            services.AddScoped<ISufixData, SufixData>();
            services.AddScoped<ICustomerAccountData, CustomerAccountData>();
            services.AddScoped<ICustomerServiceData, CustomerServiceData>();
            services.AddScoped<IUserAccountData, UserAccountData>();
            services.AddScoped<IUserAddressData, UserAddressData>();
            services.AddScoped<IUserPackageData, UserPackageData>();
            services.AddScoped<IUserCustomerServiceData, UserCustomerServiceData>();
            #endregion

            #region Application Layer Services
            services.AddScoped<IAddressTypeService, AddressTypeService>();
            services.AddScoped<IAdminAccountService, AdminAccountService>();
            services.AddScoped<IBusinessTypeService, BusinessTypeService>();
            services.AddScoped<IMeritalStatusService, MeritalStatusService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IPrefixService, PrefixService>();
            services.AddScoped<ISufixService, SufixService>();
            services.AddScoped<ICustomerAccountService, CustomerAccountService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
