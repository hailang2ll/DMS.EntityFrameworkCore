using DMS.Autofac;
using DMS.Common.Configurations;
using DMS.EntityFrameworkCore.Repository.Models;
using DMS.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

namespace DMS.EntityFrameworkCore.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration)
        {
            //var path = env.ContentRootPath;
            //var builder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            //.AddAppSettingsFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            // Configuration = builder.Build();

            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// IServiceProvider
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddJsonOptions(options =>
            {
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwaggerGenV2();

            #region AddDbContext
            var connectionStrings = Configuration.GetConnectionString("trydou_sys");
            services.AddDbContext<trydou_sysContext>(options => options.UseSqlServer(connectionStrings));
            #endregion


            return AutofacService.RegisterAutofac(services);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //var context = app.ApplicationServices.GetService<trydou_sysContext>();
            //var entity = context.SysJobLog.FirstOrDefault();
            //Console.WriteLine($"entity={ entity.Message}");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });




          
           


        }

    }
}
