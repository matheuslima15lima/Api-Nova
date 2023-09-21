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
        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Add(instituicao);
            _eventContext.SaveChanges();
        }
    }
}
