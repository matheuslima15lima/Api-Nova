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

  
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }


        /// <summary>
        /// Cadastrar Instituição
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao) 
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return Ok(instituicao);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        /// <summary>
        /// Listar Instituições
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Guid id) 
        {
            try
            {
                return Ok(_instituicaoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          

        }

    }
}
