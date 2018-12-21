using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Test
{
    static class UnitTestHelpers
    {
        

        //private static ServiceProvider GetServiceProvider()
        //{
        //    if (_serviceProvider == null)
        //    {
        //        if (!_isMapperInitialized)
        //        {
        //            Services.AutoMapper.AutoMapperConfiguration.Initialize();
        //            _isMapperInitialized = true;
        //        }

        //        var services = new ServiceCollection();
        //        services.AddDbContext<PensatiuDbContext>(options =>
        //            options.UseInMemoryDatabase(Guid.NewGuid().ToString()),
        //            ServiceLifetime.Singleton
        //        );
        //        _serviceProvider = services.BuildServiceProvider();
        //    }
        //    return _serviceProvider;
        //}

        //public static PensatiuDbContext GetInMemoryDbContext()
        //{
        //    _serviceProvider = GetServiceProvider();
        //    if (_dbContext == null)
        //    {
        //        _dbContext = _serviceProvider.GetService<PensatiuDbContext>();
        //        using (var loader = new SeedDataLoader(_dbContext))
        //        {
        //            loader.Load();
        //        }
        //    }
        //    return _dbContext;
        //}

        public static PensatiuDbContext GetNewInMemoryDbContextInstance()
        {
            var services = new ServiceCollection();
            services.AddDbContext<PensatiuDbContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()),
                ServiceLifetime.Singleton
            );
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<PensatiuDbContext>();
            using (var loader = new SeedDataLoader(dbContext))
            {
                loader.Load();
            }
            return dbContext;
        }
    }
}
