using AutoMapper;
using Pensatiu.Entities;
using Pensatiu.Services.Dto.Consultorio;
using Pensatiu.Services.Dto.Paciente;

namespace Pensatiu.Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ConsultorioProfile>();
                cfg.AddProfile<PacienteProfile>();
            });
        }
    }

    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Consultorio, ConsultorioDto>();
            CreateMap<ConsultorioForCreateDto, Consultorio>();
            CreateMap<ConsultorioForUpdateDto, Consultorio>();
            CreateMap<Consultorio, ConsultorioForCreateDto>();
            CreateMap<Consultorio, ConsultorioForUpdateDto>();
        }
    }

    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<Paciente, PacienteDto>();
            CreateMap<PacienteForCreateDto, Paciente>();
            CreateMap<PacienteForUpdateDto, Paciente>();
            CreateMap<Paciente, PacienteForCreateDto>();
            CreateMap<Paciente, PacienteForUpdateDto>();
            
            //Consultas recorrentes
            CreateMap<PacienteConsultaRecorrente, PacienteConsultaRecorrenteDto>()
                .ForMember(dest => dest.ConsultorioId, opt => opt.MapFrom(src => src.Consultorio.Id))
                .ForMember(dest => dest.ConsultorioNome, opt => opt.MapFrom(src => src.Consultorio.Nome));
            CreateMap<PacienteConsultaRecorrenteDto, PacienteConsultaRecorrente>();
            CreateMap<PacienteConsultaRecorrenteForCreateDto, PacienteConsultaRecorrente>();
            CreateMap<PacienteConsultaRecorrenteForUpdateDto, PacienteConsultaRecorrente>();
            CreateMap<PacienteConsultaRecorrente, PacienteConsultaRecorrenteForCreateDto>();
            CreateMap<PacienteConsultaRecorrente, PacienteConsultaRecorrenteForUpdateDto>();
        }
    }
}