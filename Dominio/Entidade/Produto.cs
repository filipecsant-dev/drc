using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor_Compra { get; set; }
        public decimal Valor_Venda { get; set; }
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
        public int UnidadeMedidaID { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public int Status { get; set; }

    }
}
