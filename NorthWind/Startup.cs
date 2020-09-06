using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Queryhandlers;

using NorthWind.Repositories.InsurenceContractRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NorthWind.Repositories.CustomerRepository;
using NorthWind.Repositories.AdventureWorks;

namespace NorthWind
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
            services.AddControllersWithViews();
           var QueryhandlersAsm = AppDomain.CurrentDomain.Load("NorthWind.Queryhandlers");
            //var RepositoriesAsm = AppDomain.CurrentDomain.Load("NorthWind.Repositories");
            var NorthWindContractsAsm = AppDomain.CurrentDomain.Load("NorthWind.Contracts");
            services.AddScoped<ICustomerRepository, CustomerRepositoryRepository>();
            services.AddDbContext<AdventureContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            //services.AddScoped<IRequestHandler<SampleQuery, SampleResponse>, SampleQueryhandler>();
            //services.AddScoped<IRequestHandler<ContractsQuery, ContractsResponse>, GetAllContractsHandler>();
            services.AddMediatR(QueryhandlersAsm, NorthWindContractsAsm);
            services.AddAutoMapper(typeof(Startup));
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller= CustomerSearch}/{action=GetAll}/{id?}");


            });
        }
    }
}
