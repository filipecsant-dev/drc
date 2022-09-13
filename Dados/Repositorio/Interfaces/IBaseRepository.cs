using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorio.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        void Create(TEntity entity);
        void Save(TEntity entity);
    }
}
