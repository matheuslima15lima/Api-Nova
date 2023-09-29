using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthcontext;

        public MedicoRepository() 
        {
        
            _healthcontext= new HealthClinicContext();
        }
        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthcontext.Add(medico);
                _healthcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
