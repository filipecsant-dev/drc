using Dados.Repositorio.Context;
using Dominio.Entidade;
using Dominio.Servico.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorio
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadeBase
    {
        protected readonly DrcDbContext _context;
        public BaseRepository(DrcDbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(e => e.Id == id);

                return query.First();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var query = _context.Set<TEntity>();
                if (query.Any())
                    return query.ToList().Where(x => x.Ativo == true);
                return new List<TEntity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                _context.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            try
            {
                entityToDelete.Ativo = false;
                Update(entityToDelete);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Create(TEntity entity)
        {
            try
            {
                _context.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
