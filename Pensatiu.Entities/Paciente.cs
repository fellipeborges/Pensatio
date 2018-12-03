using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pensatiu.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        public PacienteGeneroEnum Genero { get; set; }

        public DateTime? DataInicioTratamento { get; set; }

        [Required]
        public PacienteTipoCobrancaEnum TipoCobranca { get; set; }

        [Required]
        public double ValorCobranca { get; set; }

        public int? DiaCobranca { get; set; }

        public List<PacienteConsultaRecorrente> PacienteConsultasRecorrentes { get; set; }

        public Paciente()
        {
            PacienteConsultasRecorrentes = new List<PacienteConsultaRecorrente>();
        }
    }

    public enum PacienteGeneroEnum
    {
        NaoDefinido = 1,
        Masculino = 2,
        Feminino = 3
    }

    public enum PacienteTipoCobrancaEnum
    {
        NaoDefinido = 1,
        PorConsulta = 2,
        Mensal = 3
    }
}