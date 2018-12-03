using Pensatiu.Entities;
using Pensatiu.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pensatiu.Repository.Consultorios
{
    public class SqlConsultorioData : IConsultorioData
    {
        private readonly PensatiuDbContext _dbContext;

        public SqlConsultorioData(PensatiuDbContext pensatiuDbContext)
        {
            _dbContext = pensatiuDbContext;
        }

        public Consultorio Create(Consultorio itemToCreate)
        {
            _dbContext.Consultorios.Add(itemToCreate);
            _dbContext.SaveChanges();
            return itemToCreate;
        }

        public bool Delete(Consultorio itemToDelete)
        {
            _dbContext.Consultorios.Remove(itemToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            var item = Get(id);
            return (item != null);
        }

        public Consultorio Get(int id)
        {
            return _dbContext.Consultorios.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Consultorio> GetAll()
        {
            return _dbContext.Consultorios.OrderBy(i => i.Nome).ToList();
        }

        public Consultorio GetByNome(string nome)
        {
            return _dbContext.Consultorios.FirstOrDefault(i => i.Nome == nome);
        }

        public bool Update(Consultorio itemToUpdate)
        {
            var item = Get(itemToUpdate.Id);
            _dbContext.Entry(item).CurrentValues.SetValues(itemToUpdate);
            //_dbContext.Consultorios.Update(item);
            _dbContext.SaveChanges();
            return true;
        }
    }
}