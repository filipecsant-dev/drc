using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Alteracao { get; set; }
        public bool Status { get; set; }
    }
}
