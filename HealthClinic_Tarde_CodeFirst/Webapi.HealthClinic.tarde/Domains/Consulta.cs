using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Data Obrigatório!!!")]
        public DateTime DataAgendamento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descrição Obrigatório!!!")]
        public string? Descricao { get; set; }



        [Required(ErrorMessage = "Paciente obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        [Required(ErrorMessage = "Médico obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Situação obrigatória")]
        public Guid IdSitucao { get; set; }

        [ForeignKey(nameof(IdSitucao))]
        public Situacao? Situacao { get; set; }



    }
}
