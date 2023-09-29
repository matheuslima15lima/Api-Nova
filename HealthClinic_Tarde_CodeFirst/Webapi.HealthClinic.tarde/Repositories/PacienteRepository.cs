using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthContext;

        public PacienteRepository()
        {
            _healthContext = new HealthClinicContext();
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthContext.Add(paciente);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
