﻿using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public class PacienteForCreateDto: IDtoForCreate
    {
        public string Nome { get; set; }
    }
}