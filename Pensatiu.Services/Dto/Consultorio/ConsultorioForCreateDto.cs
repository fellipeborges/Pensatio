using Pensatiu.Services.Interfaces;

namespace Pensatiu.Services.Dto.Consultorio
{
    public class ConsultorioForCreateDto : ConsultorioForManipulationDto, IDtoForCreate
    {
        public ConsultorioForCreateDto()
        {}
        public ConsultorioForCreateDto(string nome, string cor, TipoConsultorioEnumDto tipo)
        {
            Nome = nome;
            Cor = cor;
            Tipo = tipo;
        }
    }
}