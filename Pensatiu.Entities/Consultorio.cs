using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public TipoConsultorioEnum Tipo { get; set; }
        public double ValorCustoMensal { get; set; }
        public double ValorAluguelMensal { get; set; }
        public double ValorLocacaoHora { get; set; }
        public double ValorLocomocao { get; set; }
    }

    public enum TipoConsultorioEnum
    {
        Proprio = 1,
        AluguelMensal = 2,
        LocacaoPorHora = 3
    }
}
