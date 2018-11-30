using System;
using System.Collections.Generic;
using System.Text;
using Pensatiu.Entities;
using Pensatiu.Repository.Context;

namespace Pensatiu.Repository.Consultorios
{
    public class SqlConsultorioData : IConsultorioData
    {
        public Consultorio Create(Consultorio item)
        {
            using (var context = new PensatiuDbContext())
            {
                context.Consultorios.Add(item);
                context.SaveChanges();
                return item;
            }
        }

        public bool Delete(Consultorio item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Consultorio Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consultorio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Consultorio GetByNome(string nome)
        {
            return null;
        }

        public bool Update(Consultorio item)
        {
            throw new NotImplementedException();
        }
    }
}
