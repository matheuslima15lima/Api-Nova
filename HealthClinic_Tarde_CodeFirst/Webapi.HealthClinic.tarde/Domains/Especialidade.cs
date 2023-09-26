using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column ( TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo Obrigatório!!!")]
        public string? Titulo { get; set; }
        
    }
}
