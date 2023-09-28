using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;
using Webapi.HealthClinic.tarde.Repositories;

namespace Webapi.HealthClinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository= new ClinicaRepository();
        }

        [HttpPost]
        public IActionResult Post(Clinica clinica) 
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return Ok(clinica);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }
    }
}
