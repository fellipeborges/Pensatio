using Pensatiu.Entities;
using System.Collections.Generic;

namespace Pensatiu.Repository.Pacientes
{
    public interface IPacienteData
    {
        Paciente Get(int id);
        Paciente GetByNomeSobrenome(string nome, string sobrenome);
        IEnumerable<Paciente> GetAll();
        Paciente Create(Paciente itemToCreate);
        bool Update(Paciente itemToUpdate);
        bool Delete(Paciente itemToDelete);
        bool Exists(int id);
    }
}