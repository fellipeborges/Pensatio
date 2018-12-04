using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Services.Dto.Paciente
{
    public enum PacienteTipoCobrancaDtoEnum
    {
        [Display(Name = "Por consulta")]
        PorConsulta = 1,
        [Display(Name = "Mensal")]
        Mensal = 2
    }
}
