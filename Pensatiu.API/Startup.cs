using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Entities;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Repository.Context;
using Pensatiu.Repository.Pacientes;
using Pensatiu.Services;
using System;
using System.Collections.Generic;

namespace Pensatiu.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private bool UseInMemoryDatabase
        {
            get
            {
                bool.TryParse(Configuration["UseInMemoryDatabase"], out bool useInMemoryDatabase);
                return useInMemoryDatabase;
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<ConsultorioService>();
            services.AddScoped<PacienteService>();
            services.AddScoped<PacienteConsultaRecorrenteService>();

            //DbContext
            if (UseInMemoryDatabase)
            {
                services.AddDbContext<PensatiuDbContext>(opt => opt.UseInMemoryDatabase("PensatiuInMemoryDatabase"), ServiceLifetime.Singleton);
            }
            else
            {
                services.AddDbContext<PensatiuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PensatiuConnection")));
                services.BuildServiceProvider().GetService<PensatiuDbContext>().Database.Migrate(); // Automatically perform database migration
            }

            //Sql Repositories
            services.AddScoped<IConsultorioData, SqlConsultorioData>();
            services.AddScoped<IPacienteData, SqlPacienteData>();
            services.AddScoped<IPacienteConsultaRecorrenteData, SqlPacienteConsultaRecorrenteData>();

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
            LoadSeedDataIfInMemoryDatabase(app);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            Services.AutoMapper.AutoMapperConfiguration.Initialize();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        private void LoadSeedDataIfInMemoryDatabase(IApplicationBuilder app)
        {
            if (UseInMemoryDatabase)
            {
                var createdDbContext = app.ApplicationServices.GetService<PensatiuDbContext>();
                using (var loader = new SeedDataLoader(createdDbContext))
                {
                    loader.Load();
                }
            }
        }
    }
}