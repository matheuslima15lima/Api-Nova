using Microsoft.Extensions.Diagnostics.HealthChecks;
using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthContext;

        public ClinicaRepository()
        { 
            _healthContext = new HealthClinicContext();

            
        }
        

        public void Cadastrar(Clinica clinica)
        {
            _healthContext.Add(clinica);
            _healthContext.SaveChanges();
        }
    }
}
