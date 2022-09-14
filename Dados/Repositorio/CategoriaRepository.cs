using Dados.Repositorio.Context;
using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorio
{
    public class CategoriaRepository : BaseRepository<Categoria>
    {
        public CategoriaRepository(DrcDbContext context) : base(context) { }


        public override Categoria GetById(int id)
        {
            var query = _context.Set<Categoria>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Categoria> GetAll()
        {
            var query = _context.Set<Categoria>();

            return query.Any() ? query.ToList().Where(x => x.Ativo == true) : new List<Categoria>();
        }

        public override void Update(Categoria categoria)
        {
            _context.Attach(categoria);
            _context.Entry(categoria).State = EntityState.Modified;
        }

        public override void Delete(Categoria entityToDelete)
        {
            entityToDelete.Ativo = false;
            Update(entityToDelete);
        }

        public override void Create(Categoria entity)
        {
            _context.Add(entity);
        }
    }
}
