using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private readonly IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// Método de cadastrar presenças
        /// </summary>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presencaEvento);

                return Ok(presencaEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        /// <summary>
        /// Endpoint que busca por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
               PresencaEvento presencaBuscada = _presencaEventoRepository.BuscarPorId(id);
                return Ok(presencaBuscada);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint de deletar Presenças
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _presencaEventoRepository.Deletar(id);

                    return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
