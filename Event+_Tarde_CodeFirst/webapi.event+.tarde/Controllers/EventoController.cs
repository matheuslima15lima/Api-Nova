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



    }
}
