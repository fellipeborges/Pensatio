using Pensatiu.Entities;
using System.Collections.Generic;

namespace Pensatiu.Repository.Pacientes
{
    public interface IPacienteData
    {
        Paciente Get(int id);
        Paciente GetByNome(string nome);
        IEnumerable<Paciente> GetAll();
        Paciente Create(Paciente item);
        bool Update(Paciente item);
        bool Delete(Paciente item);
        bool Exists(int id);
    }
}
