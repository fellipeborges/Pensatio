using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Repository.Context;
using Pensatiu.Repository.Pacientes;
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
            services.AddScoped<PacienteService>();

            //DbContext
            //services.AddTransient<PensatiuDbContext>();
            services.AddDbContext<PensatiuDbContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("BlexzWebConnection"))
                options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = Pensatiu; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False;"),
                ServiceLifetime.Scoped
            );

            //In Memory Repositories
            //services.AddSingleton<IConsultorioData, InMemoryConsultorioData>();
            //services.AddSingleton<IPacienteData, InMemoryPacienterioData>();

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
                //app.UseExceptionHandler(GlobalErrorHandlerAppBuilder());
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            Services.AutoMapper.AutoMapperConfiguration.Initialize();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        //private static Action<IApplicationBuilder> GlobalErrorHandlerAppBuilder()
        //{
        //    return appBuilder =>
        //    {
        //        appBuilder.Run(async context =>
        //        {
        //            context.Response.ContentType = "application/json";
        //            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        //            await context.Response.WriteAsync("Um erro inesperado ocorreu ao processar a solicitação.");
        //        });
        //    };
        //}
    }
}