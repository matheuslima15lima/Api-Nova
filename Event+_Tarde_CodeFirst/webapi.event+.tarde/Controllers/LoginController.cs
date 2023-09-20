using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha!);
                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!!!");
                }



                var Claims = new[]
              {
                    //formato da Claim(tipo, valor)
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!),
                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Perso","ValorPersonalizado")
               };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Event-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
              (
                  //emissor do token
                  issuer: "webapi.event+.tarde",

                  //destinatário
                  audience: "webapi.event+.tarde",

                  //dados definidos nas claims (Payload)
                  claims: Claims,

                  //tempo de expiração
                  expires: DateTime.Now.AddMinutes(5),

                  //credenciais do token
                  signingCredentials: creds

              );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
