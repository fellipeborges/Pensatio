using Microsoft.AspNetCore.Mvc;
using Pensatiu.API.Controllers;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Services;
using Pensatiu.Services.Dto.Consultorio;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;

namespace Pensatiu.Test
{
    public class ConsultorioTest: IClassFixture<StartupFixture>
    {
        private const int ID_FOR_GET = 1;
        private const int ID_FOR_UPDATE = 2;
        private const int ID_FOR_DELETE = 3;

        private ConsultoriosController GetNewControllerInstance()
        {
            var dbContext = UnitTestHelpers.GetNewInMemoryDbContextInstance();
            var sqlData = new SqlConsultorioData(dbContext);
            var service = new ConsultorioService(sqlData);
            return new ConsultoriosController(service);
        }

        [Fact]
        public void Get_WithError()
        {
            var controller = GetNewControllerInstance();

            //not found
            var notFoundResult = controller.Get(int.MaxValue);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Get_Ok()
        {
            var controller = GetNewControllerInstance();
            var okResult = controller.Get(ID_FOR_GET) as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<ConsultorioDto>(okResult.Value);
            Assert.Equal(ID_FOR_GET, (okResult.Value as ConsultorioDto).Id);
        }

        [Fact]
        public void GetAll_Ok()
        {
            var controller = GetNewControllerInstance();
            var okResult = controller.GetAll() as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsAssignableFrom<IEnumerable<ConsultorioDto>>(okResult.Value);
            Assert.True((okResult.Value as IEnumerable<ConsultorioDto>).Where(x => x.Id > 0).Count() > 0);
        }

        [Fact]
        public void Create_WithError()
        {
            var controller = GetNewControllerInstance();
            var badRequestResponse = controller.Create(null);
            Assert.IsType<BadRequestResult>(badRequestResponse);
        }

        [Fact]
        public void Create_Ok()
        {
            var controller = GetNewControllerInstance();
            var resourceToCreate = new ConsultorioForCreateDto { Nome = $"Novo { DateTime.UtcNow.ToString() }" };
            var createdResponse = controller.Create(resourceToCreate) as CreatedAtRouteResult;
            var createdResource = createdResponse.Value as ConsultorioDto;
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
            Assert.True(createdResource.Id > 0);
            Assert.Equal(createdResource.Nome, resourceToCreate.Nome);
        }

        [Fact]
        public void Update_Ok()
        {
            var controller = GetNewControllerInstance();
            var resourceToUpdate = new ConsultorioForUpdateDto { Nome = $"Alterado { DateTime.UtcNow.ToString() }" };
            var createdResponse = controller.Update(ID_FOR_UPDATE, resourceToUpdate);
            Assert.IsType<NoContentResult>(createdResponse);
        }

        [Fact]
        public void Update_WithError()
        {
            var controller = GetNewControllerInstance();
            var resourceToUpdate = new ConsultorioForUpdateDto { Nome = $"Alterado { DateTime.UtcNow.ToString() }" };

            //not found
            var notFoundResult = controller.Update(int.MaxValue, resourceToUpdate);
            Assert.IsType<NotFoundResult>(notFoundResult);

            //bad request due to Id
            var badRequestId = controller.Update(0, resourceToUpdate);
            Assert.IsType<BadRequestResult>(badRequestId);

            //bad requests due to model
            var badRequestModel = controller.Update(ID_FOR_UPDATE, null);
            Assert.IsType<BadRequestResult>(badRequestModel);
        }

        [Fact]
        public void Delete_WithError()
        {
            var controller = GetNewControllerInstance();

            //not found
            var notFoundResult = controller.Delete(int.MaxValue);
            Assert.IsType<NotFoundResult>(notFoundResult);

            //bad request due to id
            var badRequestId = controller.Delete(0);
            Assert.IsType<BadRequestResult>(badRequestId);
        }

        [Fact]
        public void Delete_Ok()
        {
            var controller = GetNewControllerInstance();
            var noContentResult = controller.Delete(ID_FOR_DELETE);
            Assert.IsType<NoContentResult>(noContentResult);
            var notFoundResult = controller.Get(ID_FOR_DELETE); //Try to find
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
