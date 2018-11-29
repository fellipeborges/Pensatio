using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteDto: IDtoForGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
