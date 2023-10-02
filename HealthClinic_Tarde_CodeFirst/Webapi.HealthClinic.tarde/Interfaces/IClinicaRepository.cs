using Microsoft.AspNetCore.Authorization;
using Webapi.HealthClinic.tarde.Domains;

namespace Webapi.HealthClinic.tarde.Interfaces
{
    public interface IClinicaRepository
    {
    
        public void Cadastrar(Clinica clinica);


    }
}
