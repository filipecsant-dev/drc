using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico.Interface
{
    public interface IUOW
    {
        void Dispose();
        int Commit();
        Task<int> CommitAsync();

    }
}
