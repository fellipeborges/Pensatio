using Pensatiu.Services.Interfaces;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteDto : IDtoForGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}