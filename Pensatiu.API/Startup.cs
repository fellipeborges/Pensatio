using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pensatiu.Entities;
using Pensatiu.Repository;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Services;

namespace Pensatiu.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<ConsultorioService>();

            //In Memory Repositories
            services.AddSingleton<IConsultorioData, InMemoryConsultorioData>();
            
            //Sql Repositories

            //Other
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            Pensatiu.Services.AutoMapper.AutoMapperConfiguration.Initialize();
            app.UseMvc();
        }
    }
}
