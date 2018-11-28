using Pensatiu.Entities;
using System.Collections.Generic;

namespace Pensatiu.Repository.Consultorios
{
    public interface IConsultorioData
    {
        Consultorio Get(int id);
        Consultorio GetByNome(string nome);
        IEnumerable<Consultorio> GetAll();
        Consultorio Create(Consultorio item);
        bool Update(Consultorio item);
        bool Delete(Consultorio item);
        bool Exists(int id);
    }
}
