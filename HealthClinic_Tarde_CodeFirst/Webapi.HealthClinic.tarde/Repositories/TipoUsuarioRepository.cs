using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext _healthContext;

        public TipoUsuarioRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _healthContext.TipoUsuario.Add(tipoUsuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
