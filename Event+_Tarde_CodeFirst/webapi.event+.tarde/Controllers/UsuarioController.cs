using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();

        }


        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint que busca por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> usuario que foi buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            try
            {

                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);


                return Ok(usuarioBuscado);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
    }
}
