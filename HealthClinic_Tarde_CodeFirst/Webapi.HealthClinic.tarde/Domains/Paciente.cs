using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "RG é obrigatório!!!")]
        public string RG { get; set; }


        [Required(ErrorMessage = "O  usuário é obrigatório!!!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario Usuario { get; set; }



    }
}
