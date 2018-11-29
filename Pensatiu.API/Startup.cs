using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Repository.Consultorios;
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

            //In Memory Repositories
            services.AddSingleton<IConsultorioData, InMemoryConsultorioData>();
            services.AddSingleton<IPacienteData, InMemoryPacienterioData>();

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
