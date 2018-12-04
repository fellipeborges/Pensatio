using Pensatiu.Services.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Services.Dto.Paciente
{
    public abstract class PacienteForManipulationDto : IDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo '{0}' deve possuir no mínimo {2} e no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo '{0}' deve possuir no mínimo {2} e no máximo {1} caracteres.")]
        public string Sobrenome { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [EnumDataType(typeof(PacienteGeneroDtoEnum), ErrorMessage = "O valor do campo '{0}' é inválido.")]
        public PacienteGeneroDtoEnum Genero { get; set; }

        [Display(Name = "Data de início do tratamento")]
        public DateTime? DataInicioTratamento { get; set; }

        [Display(Name = "Tipo de Cobrança")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [EnumDataType(typeof(PacienteTipoCobrancaDtoEnum), ErrorMessage = "O valor do campo '{0}' é inválido.")]
        public PacienteTipoCobrancaDtoEnum TipoCobranca { get; set; }

        [Display(Name = "Valor de Cobrança")]
        [Required(ErrorMessage = "O campo '{0}' não foi informado.")]
        [Range(0, 9999999, ErrorMessage = "O valor do campo '{0}' deve estar entre {1} e {2}.")]
        public double ValorCobranca { get; set; }

        [Display(Name = "Dia de Cobrança")]
        public int? DiaCobranca { get; set; }
    }
}