using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface ISituacaoRepository
    {
        public void Cadastrar(Situacao situacao);
        
    }
}
