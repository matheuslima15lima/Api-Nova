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
    public class SituacaoController : ControllerBase
    {
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }
        /// <summary>
        /// Endpoint de cadastrar situacao
        /// </summary>
        /// <param name="situacao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post (Situacao situacao)
        {
            try
            {
                _situacaoRepository.Cadastrar(situacao);

                return Ok(situacao);
            }
            catch (Exception e)
            {

              return BadRequest(e.Message);
            }
        }
    }
}
