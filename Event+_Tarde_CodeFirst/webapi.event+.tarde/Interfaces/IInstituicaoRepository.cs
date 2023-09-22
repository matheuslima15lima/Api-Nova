using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IInstituicaoRepository
    {
        public void Cadastrar(Instituicao instituicao);

        public void Deletar(Guid id);

        public void BuscarPorId(Guid id);

        public void Atualizar(Guid id, PresencaEvento presencaEvento);

        public List<Instituicao> Listar();
    }
}
