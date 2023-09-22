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
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }


        /// <summary>
        /// Cadastre os eventos aqui!!!
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return Ok(evento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        /// <summary>
        /// EndPoint de Listar eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return Ok(evento);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// EndPoint que Deleta Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return Ok("Deletado com sucesso!!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);
                return Ok(eventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
