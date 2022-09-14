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
    public class UnidadeMedidaRepository : BaseRepository<UnidadeMedida>
    {
        public UnidadeMedidaRepository(DrcDbContext context) : base(context) { }


        public override UnidadeMedida GetById(int id)
        {
            var query = _context.Set<UnidadeMedida>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<UnidadeMedida> GetAll()
        {
            var query = _context.Set<UnidadeMedida>();

            return query.Any() ? query.ToList().Where(x => x.Ativo == true) : new List<UnidadeMedida>();
        }

        public override void Update(UnidadeMedida UnidadeMedida)
        {
            _context.Attach(UnidadeMedida);
            _context.Entry(UnidadeMedida).State = EntityState.Modified;
        }

        public override void Delete(UnidadeMedida entityToDelete)
        {
            entityToDelete.Ativo = false;
            Update(entityToDelete);
        }

        public override void Create(UnidadeMedida entity)
        {
            _context.Add(entity);
        }
    }
}
