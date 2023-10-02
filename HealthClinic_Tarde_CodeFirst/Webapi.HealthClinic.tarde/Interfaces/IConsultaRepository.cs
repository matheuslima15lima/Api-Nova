using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        public void Cadastrar(Consulta consulta);

        public void Deletar(Guid id);

        public void Atualizar(Guid id, Consulta consulta);

        public List<Consulta> ListarConsultaDosUsuarios(Guid id);

     
    }
}
