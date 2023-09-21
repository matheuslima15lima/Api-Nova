using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Cadastrar(TipoEvento tipoEvento)
        {
            _eventContext.Add(tipoEvento);
            _eventContext.SaveChanges();
            
        }
    }
}
