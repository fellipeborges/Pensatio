using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pensatiu.Entities;

namespace Pensatiu.Repository.Context
{
    public class PensatiuDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteConsultaRecorrente> PacienteConsultasRecorrentes { get; set; }

        public PensatiuDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public PensatiuDbContext(DbContextOptions options)
            :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Se não vier configurado o optionsBuilder, usa por padrão a base de dados real
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PensatiuConnection"));
            }
        }
    }
}