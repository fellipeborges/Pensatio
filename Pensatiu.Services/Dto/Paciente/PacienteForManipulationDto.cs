using Pensatiu.Services.Interfaces;

namespace Pensatiu.Services.Dto.Paciente
{
    public abstract class PacienteForManipulationDto : IDto
    {
        public string Nome { get; set; }
    }
}