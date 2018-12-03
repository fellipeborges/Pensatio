using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensatiu.Services.Dto.Paciente
{
    public enum PacienteConsultaRecorrenteDiaDaSemanaDtoEnum
    {
        [Display(Name = "Domingo")]
        Domingo = 1,

        [Display(Name = "Segunda-feira")]
        SegundaFeira = 2,

        [Display(Name = "Terça-feira")]
        TercaFeira = 3,

        [Display(Name = "Quarta-feira")]
        QuartaFeira = 4,

        [Display(Name = "Quinta-feira")]
        QuintaFeira = 5,

        [Display(Name = "Sexta-feira")]
        SextaFeira = 6,

        [Display(Name = "Sábado")]
        Sabado = 7
    }
}
