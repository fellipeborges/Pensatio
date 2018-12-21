using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Test
{
    public class StartupFixture
    {
        public StartupFixture()
        {
            Services.AutoMapper.AutoMapperConfiguration.Initialize();
        }
    }
}
