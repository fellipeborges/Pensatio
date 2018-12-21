using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.API.Controllers;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Repository.Context;
using Pensatiu.Services;
using Pensatiu.Services.Dto.Consultorio;
using System;
using System.Linq;
using Pensatiu.Test.Util;
using Xunit;
using System.Collections.Generic;

namespace Pensatiu.Test
{
    public class ConsultorioTest
    {
        ConsultoriosController _controller;
        private const int ID_FOR_GET = 1;
        private const int ID_FOR_UPDATE = 2;
        private const int ID_FOR_DELETE = 3;

        public ConsultorioTest()
        {
            var objectSqlData = new SqlConsultorioData(InMemoryDbContextHelper.GetInMemoryDbContext());
            var objectService = new ConsultorioService(objectSqlData);
            _controller = new ConsultoriosController(objectService);
        }

        [Fact]
        public void Get_WithError()
        {
            //not found
            var notFoundResult = _controller.Get(int.MaxValue);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Get_Ok()
        {
            var okResult = _controller.Get(ID_FOR_GET) as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<ConsultorioDto>(okResult.Value);
            Assert.Equal(ID_FOR_GET, (okResult.Value as ConsultorioDto).Id);
        }

        [Fact]
        public void GetAll_Ok()
        {
            var okResult = _controller.GetAll() as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsAssignableFrom<IEnumerable<ConsultorioDto>>(okResult.Value);
            Assert.True((okResult.Value as IEnumerable<ConsultorioDto>).Where(x => x.Id > 0).Count() > 0);
        }


        [Fact]
        public void Create_WithError()
        {
            var badRequestResponse = _controller.Create(null);
            Assert.IsType<BadRequestResult>(badRequestResponse);
        }

        [Fact]
        public void Create_Ok()
        {
            var resourceToCreate = new ConsultorioForCreateDto($"Novo Consultório { DateTime.UtcNow.ToString() }", "#CACACA", TipoConsultorioEnumDto.Proprio);
            var createdResponse = _controller.Create(resourceToCreate) as CreatedAtRouteResult;
            var createdResource = createdResponse.Value as ConsultorioDto;
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
            Assert.True(createdResource.Id > 0);
            Assert.Equal(createdResource.Nome, resourceToCreate.Nome);
            Assert.Equal(createdResource.Cor, resourceToCreate.Cor);
            Assert.Equal(createdResource.Tipo, resourceToCreate.Tipo);
        }

        [Fact]
        public void Update_Ok()
        {
            var resourceToUpdate = new ConsultorioForUpdateDto($"Consultório Alterado { DateTime.UtcNow.ToString() }", "#DADADA", TipoConsultorioEnumDto.AluguelMensal);
            var createdResponse = _controller.Update(ID_FOR_UPDATE, resourceToUpdate);
            Assert.IsType<NoContentResult>(createdResponse);
        }

        [Fact]
        public void Update_WithError()
        {
            var resourceToUpdate = new ConsultorioForUpdateDto($"Consultório Alterado { DateTime.UtcNow.ToString() }", "#DADADA", TipoConsultorioEnumDto.AluguelMensal);

            //not found
            var notFoundResult = _controller.Update(int.MaxValue, resourceToUpdate);
            Assert.IsType<NotFoundResult>(notFoundResult);

            //bad request due to Id
            var badRequestId = _controller.Update(0, resourceToUpdate);
            Assert.IsType<BadRequestResult>(badRequestId);

            //bad requests due to model
            var badRequestModel = _controller.Update(ID_FOR_UPDATE, null);
            Assert.IsType<BadRequestResult>(badRequestModel);
        }

        [Fact]
        public void Delete_WithError()
        {
            //not found
            var notFoundResult = _controller.Delete(int.MaxValue);
            Assert.IsType<NotFoundResult>(notFoundResult);

            //bad request due to id
            var badRequestId = _controller.Delete(0);
            Assert.IsType<BadRequestResult>(badRequestId);
        }

        [Fact]
        public void Delete_Ok()
        {
            var noContentResult = _controller.Delete(ID_FOR_DELETE);
            Assert.IsType<NoContentResult>(noContentResult);
            var notFoundResult = _controller.Get(ID_FOR_DELETE); //Try to find
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
