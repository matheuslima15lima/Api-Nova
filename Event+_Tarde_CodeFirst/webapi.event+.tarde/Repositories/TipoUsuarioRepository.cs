using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Contexts;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        { 
            _eventContext= new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.Select(t => new TipoUsuario 
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    Titulo = t.Titulo
                
                
                }).FirstOrDefault(t => t.IdTipoUsuario == id)!;


                return tipoUsuarioBuscado;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

                if(tipoUsuarioBuscado != null)
                {
                    _eventContext.Remove(tipoUsuarioBuscado);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            //temos que retornar uma lista
            return _eventContext.TipoUsuario.ToList();
          
            
        }
    }
}
