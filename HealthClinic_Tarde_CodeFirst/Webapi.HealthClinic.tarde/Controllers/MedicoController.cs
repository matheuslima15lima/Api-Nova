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
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoRepository _medicoRepository;

       public  MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }
        /// <summary>
        /// Endpoint de cadastrar médico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return Ok(medico);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
