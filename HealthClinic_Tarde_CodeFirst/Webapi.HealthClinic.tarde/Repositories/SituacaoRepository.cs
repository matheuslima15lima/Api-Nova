using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private readonly HealthClinicContext _healthContext;

        public SituacaoRepository()
        {
            _healthContext = new HealthClinicContext();
        }

        public void Cadastrar(Situacao situacao)
        {
            try
            {
                _healthContext.Add(situacao);
                _healthContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
