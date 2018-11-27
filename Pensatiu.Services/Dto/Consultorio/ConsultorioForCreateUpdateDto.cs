using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensatiu.Services.Dto.Consultorio
{
    public class ConsultorioForCreateUpdateDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        public string Nome { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        public string Cor { get; set; } = "#fff";

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        public string UF { get; set; }

        [Display(Name = "Tipo")]
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
