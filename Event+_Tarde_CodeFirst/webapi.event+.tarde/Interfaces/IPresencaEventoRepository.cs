using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {


        public void Cadastrar(PresencaEvento presencaEvento);

        public PresencaEvento BuscarPorId(Guid id);
        List<PresencaEvento> ListarMinhas(Guid id);

        public void Atualizar(Guid id, PresencaEvento presencaEvento);


        public void Deletar(Guid id);

    }
}
