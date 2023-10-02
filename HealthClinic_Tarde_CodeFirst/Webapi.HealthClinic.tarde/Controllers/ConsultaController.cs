using Microsoft.AspNetCore.Authorization;
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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return Ok(consulta);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Liste as consultas dos pacientes e dos médicos aqui!!!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet ("{id}")]
        public IActionResult Get(Guid id) 
        {
            try
            {
               return Ok( _consultaRepository.ListarConsultaDosUsuarios(id));
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        
        }
    }
}
