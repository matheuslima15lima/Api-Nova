using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        public readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            throw new NotImplementedException();
        }

        public void BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Add(instituicao);
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
               PresencaEvento presencaBuscada = _eventContext.PresencaEvento.Find(id)!;

                if(presencaBuscada != null)
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

        public List<Instituicao> Listar()
        {
           return _eventContext.Instituicao.ToList();
        }
    }
}
