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
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            
                try
                {
                    _tipoEventoRepository.Cadastrar(tipoEvento);
                    return Ok(tipoEvento);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
           
        }
    }
}
