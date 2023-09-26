using Microsoft.EntityFrameworkCore;
using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        public DbSet<Especialidade> Especialidade { get; set;}

        public DbSet<Medico> Medico { get; set; }  

    
        //continuar amanha !!!!!!!
    }
}
