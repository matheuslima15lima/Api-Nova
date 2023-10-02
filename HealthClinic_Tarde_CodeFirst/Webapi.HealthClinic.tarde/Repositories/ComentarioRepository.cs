using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthContext;

        public ComentarioRepository() 
        { 
            _healthContext= new HealthClinicContext();
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _healthContext.Add(comentario);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
