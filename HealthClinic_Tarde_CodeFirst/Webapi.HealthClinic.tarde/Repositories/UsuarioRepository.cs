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

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.Select(u => new
              Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone= u.Telefone,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if(usuarioBuscado != null )
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
          




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
