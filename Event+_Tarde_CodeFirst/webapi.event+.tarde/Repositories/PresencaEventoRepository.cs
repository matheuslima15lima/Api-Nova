using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{

    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            throw new NotImplementedException();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = _eventContext.PresencaEvento.Select(p => new PresencaEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,
                    IdEvento = p.IdEvento

                }).FirstOrDefault(p => p.IdPresencaEvento == id)!;

                return presencaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
           _eventContext.Add(presencaEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = _eventContext.PresencaEvento.Find(id)!;

                if(presencaBuscada !=null) 
                {
                    _eventContext.Remove(presencaBuscada);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
