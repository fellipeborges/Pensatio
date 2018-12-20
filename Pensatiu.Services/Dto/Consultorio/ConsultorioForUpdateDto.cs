using Pensatiu.Services.Interfaces;

namespace Pensatiu.Services.Dto.Consultorio
{
    public class ConsultorioForUpdateDto : ConsultorioForManipulationDto, IDtoForUpdate
    {
        public ConsultorioForUpdateDto()
        {}
        public ConsultorioForUpdateDto(string nome, string cor, TipoConsultorioEnumDto tipo)
        {
            Nome = nome;
            Cor = cor;
            Tipo = tipo;
        }
    }
}