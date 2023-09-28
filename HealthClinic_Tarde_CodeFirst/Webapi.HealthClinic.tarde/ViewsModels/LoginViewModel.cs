using System.ComponentModel.DataAnnotations;

namespace Webapi.HealthClinic.tarde.ViewsModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório!!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!!!")]
        public string? Senha { get; set; }
    }
}
