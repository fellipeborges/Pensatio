using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pensatiu.Entities;
using Pensatiu.Repository.Context;

namespace Pensatiu.Repository.Pacientes
{
    public class SqlPacienteData : IPacienteData
    {
        private readonly PensatiuDbContext _dbContext;

        public SqlPacienteData(PensatiuDbContext pensatiuDbContext)
        {
            _dbContext = pensatiuDbContext;
        }

        public Paciente Create(Paciente itemToCreate)
        {
            _dbContext.Pacientes.Add(itemToCreate);
            _dbContext.SaveChanges();
            return itemToCreate;
        }

        public bool Delete(Paciente itemToDelete)
        {
            _dbContext.Pacientes.Remove(itemToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            var item = Get(id);
            return (item != null);
        }

        public Paciente Get(int id)
        {
            return _dbContext.Pacientes.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _dbContext.Pacientes.OrderBy(i => i.Nome).ToList();
        }

        public Paciente GetByNomeSobrenome(string nome, string sobrenome)
        {
            return _dbContext.Pacientes.FirstOrDefault(i => i.Nome == nome && i.Sobrenome == sobrenome);
        }

        public bool Update(Paciente itemToUpdate)
        {
            var item = Get(itemToUpdate.Id);
            _dbContext.Entry(item).CurrentValues.SetValues(itemToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
