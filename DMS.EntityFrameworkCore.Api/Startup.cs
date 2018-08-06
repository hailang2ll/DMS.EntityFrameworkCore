using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DMS.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

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
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
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
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "Version 1.0",
                    Title = "TrunkCoreDemo的API文档",
                    Description = "Dylan作者"
                });

                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, commentsFileName);
                options.IncludeXmlComments(xmlPath);

                options.OperationFilter<AssignOperationVendorExtensions>();
            });
            #endregion

            //向容器内注入数据库
            //var connectionStrings = Configuration.GetConnectionString("MYSQLWALIUJR_SYS");
            //services.AddDbContext<WALIUJR_SYSContext>(options => options.UseSqlServer(connectionStrings));

            #region Autofac DI注入 第一种
            //说明：ConfigureServices返回void，通过构造函数来获取
            //services.AddTransient<IDemoService, DemoService>();
            #endregion

            #region Autofac DI注入 第二种
            //说明：ConfigureServices返回IServiceProvider，通过接口属性来获取
            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //var builder = new ContainerBuilder();
            //builder.RegisterType<DemoService>().As<IDemoService>().InstancePerLifetimeScope().PropertiesAutowired();
            //builder.RegisterType(typeof(ValuesController)).InstancePerLifetimeScope().PropertiesAutowired();

            //builder.Populate(services); 
            //return new AutofacServiceProvider(builder.Build());
            #endregion

            #region Autofac DI注入 第三种
            //说明：ConfigureServices返回IServiceProvider，通过接口属性来获取,自动获取Controller的属性
            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //var feature = new ControllerFeature();
            //manager.PopulateFeature(feature);


            //var builder = new ContainerBuilder();
            //builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            //builder.Populate(services);

            //Assembly iface = Assembly.Load("TrunkCoreDemo.Service");
            //Assembly service = Assembly.Load("TrunkCoreDemo.Contracts");
            //builder.RegisterAssemblyTypes(iface, service)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
            //return new AutofacServiceProvider(builder.Build());
            #endregion

            #region Autofac DI注入 第四种
            //说明：ConfigureServices返回IServiceProvider，通过接口属性来获取,
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(q => q.FullName.Contains("Trunk")).ToArray();
            //var types = Assembly.GetEntryAssembly().GetReferencedAssemblies();


            //String baseDir = AppContext.BaseDirectory; //String basePath2 = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            //DirectoryInfo dirInfo = new DirectoryInfo(baseDir);

            //var fileInfo = dirInfo.GetFiles().Where(q => q.FullName.Contains(".Service")).FirstOrDefault();



            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(assembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //var feature = new ControllerFeature();
            //manager.PopulateFeature(feature);


            //var builder = new ContainerBuilder();
            //builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            //builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            //builder.Populate(services);

            //var assemblys = Assembly.LoadFrom(fileInfo.FullName);
            //var baseType = typeof(IDependency);
            //builder.RegisterAssemblyTypes(assemblys)
            // .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
            // .AsImplementedInterfaces().InstancePerLifetimeScope();

            //return new AutofacServiceProvider(builder.Build());
            #endregion

            return AutofacService.RegisterAutofac(services, "DMS.EntityFrameworkCore.Contracts", "DMS.EntityFrameworkCore.Service");



        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //var an = app.ApplicationServices.GetService<IDemoService>();
            //var en = an.GetEntity(13);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrunkCoreDemoAPI");
                c.DocExpansion(DocExpansion.None);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        public class AssignOperationVendorExtensions : IOperationFilter
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="operation"></param>
            /// <param name="context"></param>
            public void Apply(Operation operation, OperationFilterContext context)
            {
                operation.Parameters = operation.Parameters ?? new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "AccessToken",
                    In = "header",
                    Description = "身份验证票据",
                    Required = false,
                    Type = "string"
                });
            }
        }

    }
}
