using System.ComponentModel.DataAnnotations;

namespace drc.Models
{
    public class UnidadeMedidaVM
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Necessário informar o nome da Medida")]
        [MaxLength(50, ErrorMessage = "Informe um nome mais curto.")]
        [MinLength(5, ErrorMessage = "Informe um nome maior.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário a Sigla")]
        [MaxLength(15, ErrorMessage = "Informe uma sigla mais curta.")]
        public string Sigla { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
    }
}
