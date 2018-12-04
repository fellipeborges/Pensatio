using Pensatiu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Repository.Pacientes
{
    public interface IPacienteConsultaRecorrenteData
    {
        PacienteConsultaRecorrente Get(int id);
        IEnumerable<PacienteConsultaRecorrente> GetAll(int pacienteId);
        PacienteConsultaRecorrente Create(int pacienteId, PacienteConsultaRecorrente item);
        bool Update(PacienteConsultaRecorrente item);
        bool Delete(PacienteConsultaRecorrente item);
        bool Exists(int id);
    }
}
