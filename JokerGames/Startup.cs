using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainService;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;


namespace JokerGames
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connStr = Configuration.GetConnectionString("DefaultConnection");

            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var _sessionFactory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                                      //.Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PlayerMap>())
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CardMap>())
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PurchaseMap>())
                                      
                                      .BuildSessionFactory();



            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });


            //services.AddTransient<IGenericRepository<object>, GenericRepository<object>>(); not working
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // services.AddScoped<Validator.IValidator, Validator.Validator>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IPurchaseService, PurchaseService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
