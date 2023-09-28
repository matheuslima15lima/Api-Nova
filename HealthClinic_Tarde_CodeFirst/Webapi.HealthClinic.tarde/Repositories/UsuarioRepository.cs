using Webapi.HealthClinic.tarde.Context;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;
using Webapi.HealthClinic.tarde.Utils;

namespace Webapi.HealthClinic.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext= new HealthClinicContext();
        }
        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarGash(usuario.Senha!);
            _healthContext.Add(usuario);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {

                Usuario usuarioBuscado = _healthContext.Usuario.Find(id);

                if(usuarioBuscado != null)
                {
                    _healthContext.Remove(usuarioBuscado);
                   
                }
                _healthContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

            

        }
    }
}
