using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteConsultaRecorrenteForManipulationDto : IDto
    {
        public int PacienteId { get; set; }
        public int ConsultorioId { get; set; }

        public PacienteConsultaRecorrenteDiaDaSemanaDtoEnum DiaSemana { get; set; }

        public TimeSpan Hora { get; set; }
    }
}
