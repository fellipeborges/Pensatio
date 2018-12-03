using Pensatiu.Services.Dto.Consultorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteConsultaRecorrenteDto
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }

        public int ConsultorioId { get; set; }
        public string ConsultorioNome { get; set; }

        public PacienteConsultaRecorrenteDiaDaSemanaDtoEnum DiaSemana { get; set; }

        public TimeSpan Hora { get; set; }
    }
}
