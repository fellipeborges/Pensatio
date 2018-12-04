using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public enum PacienteGeneroDtoEnum
    {
        [Display(Name = "Não definido")]
        NaoDefinido = 1,
        [Display(Name = "Masculino")]
        Masculino = 2,
        [Display(Name = "Feminino")]
        Feminino = 3
    }
}
