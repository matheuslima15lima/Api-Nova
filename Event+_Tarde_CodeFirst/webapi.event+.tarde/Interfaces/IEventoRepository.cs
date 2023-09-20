using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        List<Evento> Listar();

        void Deletar(Guid id);

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);
    }
}
