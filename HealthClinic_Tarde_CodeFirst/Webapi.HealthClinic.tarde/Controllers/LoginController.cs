using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Webapi.HealthClinic.tarde.Domains;
using Webapi.HealthClinic.tarde.Interfaces;
using Webapi.HealthClinic.tarde.Repositories;
using Webapi.HealthClinic.tarde.ViewsModels;

namespace Webapi.HealthClinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario) 
        {

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha!);
                if(usuarioBuscado == null) 
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

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Health-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
              (
                  //emissor do token
                  issuer: "Webapi.HealthClinic.tarde",

                  //destinatário
                  audience: "Webapi.HealthClinic.tarde",

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
