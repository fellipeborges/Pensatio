using Microsoft.EntityFrameworkCore;
using Pensatiu.Entities;
using Pensatiu.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensatiu.Repository.Pacientes
{
    public class SqlPacienteConsultaRecorrenteData : IPacienteConsultaRecorrenteData
    {
        private readonly PensatiuDbContext _dbContext;

        public SqlPacienteConsultaRecorrenteData(PensatiuDbContext pensatiuDbContext)
        {
            _dbContext = pensatiuDbContext;
        }

        public PacienteConsultaRecorrente Create(int pacienteId, PacienteConsultaRecorrente itemToCreate)
        {
            _dbContext.PacienteConsultasRecorrentes.Add(itemToCreate);
            _dbContext.SaveChanges();
            return itemToCreate;
            //var paciente = Get(pacienteId);
            //paciente.PacienteConsultasRecorrentes.Add(item);
            //if (Update(paciente) == true)
            //{
            //    return item;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public bool Delete(PacienteConsultaRecorrente item)
        {
            _dbContext.PacienteConsultasRecorrentes.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            var item = Get(id);
            return (item != null);
        }

        public IEnumerable<PacienteConsultaRecorrente> GetAll(int pacienteId)
        {
            return _dbContext.PacienteConsultasRecorrentes
                .Where(i => i.PacienteId == pacienteId)
                .Include(i => i.Consultorio)
                .OrderBy(i => i.DiaSemana)
                .ToList();
        }

        public PacienteConsultaRecorrente Get(int id)
        {
            var item = _dbContext.PacienteConsultasRecorrentes
                .Include(r => r.Paciente)
                .Include(r => r.Consultorio)
                .FirstOrDefault(r => r.Id == id);
            return item;
        }

        public bool Update(PacienteConsultaRecorrente itemToUpdate)
        {
            var item = Get(itemToUpdate.Id);
            _dbContext.Entry(item).CurrentValues.SetValues(itemToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
