using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteConsultaRecorrenteForCreateDto : PacienteConsultaRecorrenteForManipulationDto, IDtoForCreate
    {
        public int ParentId { get; set; }
    }
}
