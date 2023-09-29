using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        public void Cadastrar(Usuario usuario);

        public void Deletar(Guid id);

        public Usuario BuscarPorEmailESenha(string email, string senha);

    }
}
