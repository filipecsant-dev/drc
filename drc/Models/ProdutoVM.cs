using Dominio.Entidade;
using System.ComponentModel.DataAnnotations;

namespace drc.Models
{
    public class ProdutoVM
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Necessário colocar o nome do produto")]
        [MaxLength(50, ErrorMessage = "Informe um nome mais curto.")]
        [MinLength(5, ErrorMessage = "Informe um nome maior.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Necessário informar o Valor da Compra")]
        public decimal Valor_Compra { get; set; }
        [Required(ErrorMessage = "Necessário informar o Valor da Venda")]
        public decimal Valor_Venda { get; set; }
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        public int UnidadeMedidaID { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public bool Status { get; set; }
    }
}
