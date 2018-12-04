using Pensatiu.Services.Interfaces;

namespace Pensatiu.Services.Dto.Consultorio
{
    public class ConsultorioDto : IDto, IDtoForGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public TipoConsultorioEnumDto Tipo { get; set; }
        public double ValorCustoMensal { get; set; }
        public double ValorAluguelMensal { get; set; }
        public double ValorLocacaoHora { get; set; }
        public double ValorLocomocao { get; set; }
    }
}