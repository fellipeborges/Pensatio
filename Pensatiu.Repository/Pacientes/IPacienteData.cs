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

        PacienteConsultaRecorrente ConsultaRecorrenteGetById(int pacienteId, int id);
        IEnumerable<PacienteConsultaRecorrente> ConsultaRecorrenteGetAll(int pacienteId);
        PacienteConsultaRecorrente ConsultaRecorrenteCreate(int pacienteId, PacienteConsultaRecorrente item);
        bool ConsultaRecorrenteUpdate(int pacienteId, PacienteConsultaRecorrente item);
        bool ConsultaRecorrenteDelete(int pacienteId, PacienteConsultaRecorrente item);
        bool ConsultaRecorrenteExists(int pacienteId, int id);
    }
}