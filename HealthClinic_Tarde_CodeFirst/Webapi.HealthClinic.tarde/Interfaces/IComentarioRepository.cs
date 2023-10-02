using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface IComentarioRepository
    {
        public void Cadastrar(Comentario comentario);
    }
}
