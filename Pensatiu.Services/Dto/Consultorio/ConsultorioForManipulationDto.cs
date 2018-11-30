using Pensatiu.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Services.Dto.Consultorio
{
    public abstract class ConsultorioForManipulationDto : IDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo '{0}' deve possuir no mínimo {2} e no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        public string Cor { get; set; } = "#fff";

        [Display(Name = "Endereço")]
        [StringLength(150, ErrorMessage = "O campo '{0}' deve possuir no máximo {1} caracteres.")]
        public string Endereco { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, ErrorMessage = "O campo '{0}' deve possuir no máximo {1} caracteres.")]
        public string CEP { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "O campo '{0}' deve possuir no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        public string UF { get; set; }

        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        public TipoConsultorioDtoEnum Tipo { get; set; }

        [Display(Name = "Valor do Custo Mensal")]
        [Range(0, 9999999, ErrorMessage = "O valor do campo '{0}' deve estar entre {1} e {2}.")]
        public double ValorCustoMensal { get; set; } = 0;

        [Display(Name = "Valor do Aluguel Mensal")]
        [Range(0, 9999999, ErrorMessage = "O valor do campo '{0}' deve estar entre {1} e {2}.")]
        public double ValorAluguelMensal { get; set; } = 0;

        [Display(Name = "Valor da Locação por Hora")]
        [Range(0, 9999999, ErrorMessage = "O valor do campo '{0}' deve estar entre {1} e {2}.")]
        public double ValorLocacaoHora { get; set; } = 0;

        [Display(Name = "Valor de Locomoção (ida/volta)")]
        [Range(0, 9999999, ErrorMessage = "O valor do campo '{0}' deve estar entre {1} e {2}.")]
        public double ValorLocomocao { get; set; } = 0;
    }
}