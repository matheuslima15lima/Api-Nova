using Microsoft.EntityFrameworkCore;
using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE18-S15 ; Database = HealthClinic_tarde_CodeFirst; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.NoAction); // Defina o comportamento da operação de exclusão

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.NoAction); // Defina o comportamento da operação de exclusão

            // Outras configurações aqui...

            base.OnModelCreating(modelBuilder);
        }
    }
}
