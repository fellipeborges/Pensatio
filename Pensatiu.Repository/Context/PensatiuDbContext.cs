using Microsoft.EntityFrameworkCore;
using Pensatiu.Entities;

namespace Pensatiu.Repository.Context
{
    public class PensatiuDbContext : DbContext
    {
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteConsultaRecorrente> PacienteConsultasRecorrentes { get; set; }

        public PensatiuDbContext(DbContextOptions<PensatiuDbContext> options)
            :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PacienteConsultaRecorrente>()
            //    .HasKey(c => new { c.PacienteId, c.ConsultorioId });
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Server = (localdb)\\MSSQLLocalDB;Initial Catalog=Pensatiu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"
        //    );
        //}
    }
}