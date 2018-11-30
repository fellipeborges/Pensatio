using Pensatiu.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pensatiu.Repository.Pacientes
{
    public class InMemoryPacienterioData : IPacienteData
    {
        private List<Paciente> _items;

        public InMemoryPacienterioData()
        {
            _items = new List<Paciente>
            {
                new Paciente{Id = 1, Nome="João da Silva"},
                new Paciente{Id = 2, Nome="Maria das Dores"},
                new Paciente{Id = 3, Nome="Gustavo Mendes"}
            };
        }

        public Paciente Create(Paciente item)
        {
            item.Id = _items.Max(r => r.Id) + 1;
            _items.Add(item);
            return item;
        }

        public bool Delete(Paciente item)
        {
            return _items.Remove(item);
        }

        public Paciente Get(int id)
        {
            return _items.FirstOrDefault(r => r.Id == id);
        }

        public Paciente GetByNome(string nome)
        {
            return _items.FirstOrDefault(r => r.Nome == nome);
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _items.OrderBy(r => r.Nome);
        }

        public bool Update(Paciente item)
        {
            var itemToUpdate = _items.FirstOrDefault(i => i.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Nome = item.Nome;
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