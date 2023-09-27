using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        public void Cadastrar(TipoUsuario tipoUsuario);
    }
}
