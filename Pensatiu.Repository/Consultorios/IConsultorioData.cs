using Pensatiu.Entities;
using Pensatiu.Repository.Context;
using System.Collections.Generic;

namespace Pensatiu.Repository.Consultorios
{
    public interface IConsultorioData
    {
        Consultorio Get(int id);

        Consultorio GetByNome(string nome);

        IEnumerable<Consultorio> GetAll();

        Consultorio Create(Consultorio itemToCreate);

        bool Update(Consultorio itemToUpdate);

        bool Delete(Consultorio itemToDelete);

        bool Exists(int id);
    }
}