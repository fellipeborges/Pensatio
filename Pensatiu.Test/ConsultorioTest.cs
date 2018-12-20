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

namespace Pensatiu.Test
{
    public class ConsultorioTest
    {
        ConsultoriosController _objectController;

        public ConsultorioTest()
        {
            var objectSqlData = new SqlConsultorioData(InMemoryDbContextHelper.GetInMemoryDbContext());
            var objectService = new ConsultorioService(objectSqlData);
            _objectController = new ConsultoriosController(objectService);
        }
        
        [Fact]
        public void Create()
        {
            var resourceToCreate = new ConsultorioForCreateDto($"Novo Consultório { DateTime.UtcNow.ToString() }", "#CACACA", TipoConsultorioEnumDto.Proprio);
            var createdResponse = _objectController.Create(resourceToCreate) as CreatedAtRouteResult;
            var createdResource = createdResponse.Value as ConsultorioDto;

            Assert.IsType<CreatedAtRouteResult>(createdResponse);
            Assert.True(createdResource.Id > 0);
            Assert.Equal(createdResource.Nome, resourceToCreate.Nome);
            Assert.Equal(createdResource.Cor, resourceToCreate.Cor);
            Assert.Equal(createdResource.Tipo, resourceToCreate.Tipo);
        }

        [Fact]
        public void Update()
        {
            var resourceToUpdate = new ConsultorioForUpdateDto("Consultório 1 Alterado", "#DADADA", TipoConsultorioEnumDto.AluguelMensal);
            var createdResponse = _objectController.Update(1, resourceToUpdate);

            Assert.IsType<NoContentResult>(createdResponse);
        }

        
    }
}
