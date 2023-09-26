using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Situacao))]
    public class Situacao
    {
        [Key]
        public Guid IdSituacao { get; set; } = Guid.NewGuid();

       

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação obrigatória!!!")]
        public bool SituacaoConsulta { get; set; } 



    }
}
