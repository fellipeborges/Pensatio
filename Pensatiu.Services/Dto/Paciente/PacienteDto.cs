using Pensatiu.Services.Interfaces;
using System;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteDto : IDtoForGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto { get
            {
                return $"{this.Nome} {this.Sobrenome}";
            }
        }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public PacienteGeneroDtoEnum Genero { get; set; }
        public DateTime? DataInicioTratamento { get; set; }
        public PacienteTipoCobrancaDtoEnum TipoCobranca { get; set; }
        public double ValorCobranca { get; set; }
        public int? DiaCobranca { get; set; }
    }
}