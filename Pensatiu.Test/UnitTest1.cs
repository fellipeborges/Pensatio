using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Entities;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Repository.Context;
//using Pensatiu.API.Controllers;
//using Pensatiu.Services;
//using Pensatiu.Services.Dto.Consultorio;
using System;
using System.Linq;
using Xunit;

namespace Pensatiu.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("InMemoryPensatiu");
            using (var context = new PensatiuDbContext(optionsBuilder.Options))
            {
                var consultorio = new Consultorio { Nome = "Cs1" };
                context.Consultorios.Add(consultorio);
                context.SaveChanges();
            }
            using (var context2 = new PensatiuDbContext(optionsBuilder.Options))
            {
                Assert.Equal(1, context2.Consultorios.Count());
            }
        }

        [Fact]
        public void Test2()
        {
            var services = new ServiceCollection();
            services.AddDbContext<PensatiuDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryPensatiu"),
                ServiceLifetime.Scoped
            );
            var serviceProvider = services.BuildServiceProvider();

            //var dbContext = serviceProvider.GetService<PensatiuDbContext>();
            //var consultorioData = new SqlConsultorioData(dbContext);
            //var consultService = new ConsultorioService(consultorioData);
            //var consultorioController = new ConsultoriosController(consultService);

            //var testItem = new ConsultorioForCreateDto
            //{
            //    Nome = "Cs1"
            //};
            //var createdResponse = consultorioController.Create(testItem);
            //Assert.IsType<CreatedAtActionResult>(createdResponse);
            //Assert.True(createdResponse. > 5, "The actualCount was not greater than five");
        }
    }
}
