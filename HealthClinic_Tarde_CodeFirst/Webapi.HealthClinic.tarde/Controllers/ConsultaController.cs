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

        /// <summary>
        /// Endpoint de cadastrar consulta
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [Authorize]
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

        /// <summary>
        /// Endpoint que atualiza consulta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return Ok(consulta);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
               Consulta consultaBuscada = _consultaRepository.Deletar(id);

                return Ok("Deletado");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
