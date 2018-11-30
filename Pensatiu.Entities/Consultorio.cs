using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(7)]
        public string Cor { get; set; }

        [StringLength(150)]
        public string Endereco { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        [Required]
        public TipoConsultorioEnum Tipo { get; set; }

        public double? ValorCustoMensal { get; set; }

        public double? ValorAluguelMensal { get; set; }

        public double? ValorLocacaoHora { get; set; }

        public double? ValorLocomocao { get; set; }
    }

    public enum TipoConsultorioEnum
    {
        Proprio = 1,
        AluguelMensal = 2,
        LocacaoPorHora = 3
    }
}