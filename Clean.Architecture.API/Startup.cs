using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Clean.Architecture.API {
    public class Startup {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        private readonly Database _Database;
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
            _Database = new SqlDatabase(Configuration["Data:ConnectionString"]);
        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();

            #region Singleton Configuration and Database Services
            services.AddSingleton(Configuration);
            services.AddSingleton(_Database);
            services.AddCors();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.WithOrigins("http://localhost/CleanArchitetureAPI/").AllowAnyHeader());
            //app.UseMvc();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default", pattern: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
