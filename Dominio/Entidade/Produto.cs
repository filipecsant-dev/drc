using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public string Valor_Compra { get; set; }
        public string Valor_Venda { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        [ForeignKey("UnidadeMedida")]
        public int UnidadeMedidaID { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public bool Status { get; set; }

    }
}
