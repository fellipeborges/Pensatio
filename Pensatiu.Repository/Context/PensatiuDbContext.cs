using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pensatiu.Entities;

namespace Pensatiu.Repository.Context
{
    public class PensatiuDbContext : DbContext
    {
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteConsultaRecorrente> PacienteConsultasRecorrentes { get; set; }

        public PensatiuDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}