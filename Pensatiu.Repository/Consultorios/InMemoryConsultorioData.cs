using Pensatiu.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pensatiu.Repository.Consultorios
{
    public class InMemoryConsultorioData : IConsultorioData
    {
        private List<Consultorio> _items;

        public InMemoryConsultorioData()
        {
            _items = new List<Consultorio>
            {
                new Consultorio{Id = 1, Nome="Tatuapé", Cor="#990000", Endereco = "Rua Tuiuti, 645, 6o Andar, Cj 65, Tatuapé", CEP = "03178200", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.Proprio, ValorCustoMensal = 1000.00F, ValorLocomocao = 12.00 },
                new Consultorio{Id = 2, Nome="Mooca", Cor="#006600", Endereco = "Rua Cassandoca, 125, Mooca", CEP = "03169010", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.AluguelMensal, ValorAluguelMensal = 1500.00F, ValorLocomocao = 10.00 },
                new Consultorio{Id = 3, Nome="Bela Cintra", Cor="#000066", Endereco = "Rua Bela Cintra, 768, Consolação", CEP = "01415002", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.LocacaoPorHora, ValorLocacaoHora = 80.00F, ValorLocomocao = 15.00 }
            };
        }

        public Consultorio Create(Consultorio item)
        {
            item.Id = _items.Max(r => r.Id) + 1;
            _items.Add(item);
            return item;
        }

        public bool Delete(Consultorio item)
        {
            return _items.Remove(item);
        }

        public Consultorio Get(int id)
        {
            return _items.FirstOrDefault(r => r.Id == id);
        }

        public Consultorio GetByNome(string nome)
        {
            return _items.FirstOrDefault(r => r.Nome == nome);
        }

        public IEnumerable<Consultorio> GetAll()
        {
            return _items.OrderBy(r => r.Nome);
        }

        public bool Update(Consultorio item)
        {
            var itemToUpdate = _items.FirstOrDefault(i => i.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Nome = item.Nome;
                itemToUpdate.Cor = item.Cor;
                itemToUpdate.Endereco = item.Endereco;
                itemToUpdate.CEP = item.CEP;
                itemToUpdate.Cidade = item.Cidade;
                itemToUpdate.UF = item.UF;
                itemToUpdate.Tipo = item.Tipo;
                itemToUpdate.ValorCustoMensal = item.ValorCustoMensal;
                itemToUpdate.ValorAluguelMensal = item.ValorAluguelMensal;
                itemToUpdate.ValorLocacaoHora = item.ValorLocacaoHora;
                itemToUpdate.ValorLocomocao = item.ValorLocomocao;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Exists(int id)
        {
            return _items.Exists(i => i.Id == id);
        }
    }
}