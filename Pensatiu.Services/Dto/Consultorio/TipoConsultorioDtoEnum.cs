using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Services.Dto.Consultorio
{
    public enum TipoConsultorioDtoEnum
    {
        [Display(Name = "Próprio")]
        Proprio = 1,

        [Display(Name = "Aluguel Mensal")]
        AluguelMensal = 2,

        [Display(Name = "Locação por Hora")]
        LocacaoPorHora = 3
    }
}