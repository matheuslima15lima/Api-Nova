using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set;  } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome de Usuário Obrigatório!!!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha de Usuário Obrigatório!!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }


        //[StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "Telefone de Usuário Obrigatório!!!")]
        public int Telefone { get; set; }



        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email de Usuário Obrigatório!!!")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "O tipo de usuário é obrigatório!!!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }

    }
}
