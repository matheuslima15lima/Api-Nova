using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        public void Cadastrar(Paciente paciente);
    }
}
