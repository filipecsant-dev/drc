using System.ComponentModel.DataAnnotations;

namespace drc.Models
{
    public class CategoriaVM
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Necessário colocar o nome da Categoria")]
        [MaxLength(50, ErrorMessage = "Informe um nome mais curto.")]
        [MinLength(5, ErrorMessage = "Informe um nome maior.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário informar a descrição")]
        [MaxLength(100, ErrorMessage = "Informe uma descrição mais curta.")]
        [MinLength(5, ErrorMessage = "Informe uma descrição maior.")]
        public string Descricao { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public bool Status { get; set; }
    }
}
