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
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(DrcDbContext context) : base(context) { }


        public override Produto GetById(int id)
        {
            var resultado = (from p in _context.Produto
                             from c in _context.Categoria.Where(x => x.Id == p.CategoriaID).DefaultIfEmpty()
                             from u in _context.UnidadeMedida.Where(x => x.Id == p.UnidadeMedidaID).DefaultIfEmpty()
                             where p.Ativo == true && p.Id == id
                             select new Produto
                             {
                                 Id = p.Id,
                                 Nome = p.Nome,
                                 Valor_Compra = p.Valor_Compra,
                                 Valor_Venda = p.Valor_Venda,
                                 CategoriaID = p.CategoriaID,
                                 Categoria = c,
                                 UnidadeMedidaID = p.UnidadeMedidaID,
                                 UnidadeMedida = u,
                                 Data_Cadastro = p.Data_Cadastro,
                                 Data_Alteracao = p.Data_Alteracao,
                                 Status = p.Status,
                                 Ativo = p.Ativo
                             }).FirstOrDefault();

            return resultado;
        }

        public override IEnumerable<Produto> GetAll()
        {
            var resultado = (from p in _context.Produto
                             from c in _context.Categoria.Where(x => x.Id == p.CategoriaID).DefaultIfEmpty()
                             from u in _context.UnidadeMedida.Where(x => x.Id == p.UnidadeMedidaID).DefaultIfEmpty()
                             where p.Ativo == true
                             select new Produto
                             {
                                 Id = p.Id,
                                 Nome = p.Nome,
                                 Valor_Compra = p.Valor_Compra,
                                 Valor_Venda = p.Valor_Venda,
                                 CategoriaID = p.CategoriaID,
                                 Categoria = c,
                                 UnidadeMedidaID = p.UnidadeMedidaID,
                                 UnidadeMedida = u,
                                 Data_Cadastro = p.Data_Cadastro,
                                 Data_Alteracao = p.Data_Alteracao,
                                 Status = p.Status,
                                 Ativo = p.Ativo
                             });

            return resultado;
        }

        public override void Update(Produto produto)
        {
            _context.Attach(produto);
            _context.Entry(produto).State = EntityState.Modified;
        }

        public override void Delete(Produto entityToDelete)
        {
            entityToDelete.Ativo = false;
            Update(entityToDelete);
        }

        public override void Create(Produto entity)
        {
            _context.Add(entity);
        }
    }
}
