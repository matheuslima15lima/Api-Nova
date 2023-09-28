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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository= new EspecialidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidade) 
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return Ok(especialidade);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
