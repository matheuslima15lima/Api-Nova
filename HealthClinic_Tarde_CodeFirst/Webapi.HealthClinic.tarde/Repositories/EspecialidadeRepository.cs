using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthContext;

        public EspecialidadeRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthContext.Add(especialidade);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
          

        }

    }
}
