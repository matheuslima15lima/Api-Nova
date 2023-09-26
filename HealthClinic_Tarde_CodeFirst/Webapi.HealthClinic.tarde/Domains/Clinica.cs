using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Usuario))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome fantasia Obrigatório!!!")]
        public string NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "RazaoSocial Obrigatório!!!")]
        public string RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "RazaoSocial Obrigatório!!!")]
        public string Endereco { get; set; }

        [Column(TypeName = "Time ")]
        [Required(ErrorMessage = "HoraAbertura Obrigatório!!!")]
        public TimeSpan HoraAbertura { get; set; }

        [Column(TypeName = "Time ")]
        [Required(ErrorMessage = "HoraFechamento Obrigatório!!!")]
        public TimeSpan HoraFechamento { get; set; }

        [Column(TypeName = "VARCHAR(100) ")]
        [Required(ErrorMessage = "CNPJ Obrigatório!!!")]
        public string CNPJ { get; set; }
        




    }
}
