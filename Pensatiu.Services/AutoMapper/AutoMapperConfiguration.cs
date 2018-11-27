using AutoMapper;
using Pensatiu.Entities;
using Pensatiu.Services.Dto.Consultorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ConsultorioProfile>();
            });
        }
    }

    public class ConsultorioProfile: Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Consultorio, ConsultorioDto>();
            CreateMap<ConsultorioForCreateUpdateDto, Consultorio>();
            CreateMap<Consultorio, ConsultorioForCreateUpdateDto>();
        }
    }
}
