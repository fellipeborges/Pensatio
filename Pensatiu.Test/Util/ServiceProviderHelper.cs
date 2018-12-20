using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Test.Util
{
    static class ServiceProviderHelper
    {
        private static ServiceProvider _serviceProvider;

        public static ServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
            {
                Services.AutoMapper.AutoMapperConfiguration.Initialize();
                var services = new ServiceCollection();
                services.AddDbContext<PensatiuDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryPensatiu"),
                    ServiceLifetime.Scoped
                );
                _serviceProvider = services.BuildServiceProvider();
            }
            return _serviceProvider;
        }
    }
}
