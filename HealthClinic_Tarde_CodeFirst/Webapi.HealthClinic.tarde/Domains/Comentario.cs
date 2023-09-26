using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "DataComentario obrigatório!!!")]
        public DateTime DataComentario { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = " Confirmar exibição obrigatório!")]
        public bool Exibe { get; set; }


        [Required(ErrorMessage = "Consulta obrigatório")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta Consulta { get; set; }



        [Required(ErrorMessage = "Paciente obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }


    }
}
