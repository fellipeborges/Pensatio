using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensatiu.Services.Dto.Consultorio
{
    public class ConsultorioForCreateUpdateDto
    {
        public string Nome { get; set; }
        public string Cor { get; set; } = "#fff";
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public TipoConsultorioDtoEnum Tipo { get; set; }
        public double ValorCustoMensal { get; set; } = 0;
        public double ValorAluguelMensal { get; set; } = 0;
        public double ValorLocacaoHora { get; set; } = 0;
        public double ValorLocomocao { get; set; } = 0;
    }
}
