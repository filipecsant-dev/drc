using Dominio.Entidade;
using Dominio.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ProdutoService
    {
        private readonly IBaseRepository<Produto> _produtoRepository;
        private readonly IUOW _uow;
        public ProdutoService(IBaseRepository<Produto> produtoRepository, IUOW uow)
        {
            _produtoRepository = produtoRepository;
            _uow = uow;
        }

        public IEnumerable<Produto> GetAll()
        {
            try
            {
                return _produtoRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Produto GetById(int id)
        {
            try
            {
                return _produtoRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Produto produto)
        {
            try
            {
                produto.Data_Alteracao = DateTime.Now;

                _produtoRepository.Update(produto);

                if (_uow.Commit() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var produto = _produtoRepository.GetById(id);
                _produtoRepository.Delete(produto);
                _uow.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Create(Produto produto)
        {
            try
            {
                produto.Data_Cadastro = DateTime.Now;
                produto.Data_Alteracao = DateTime.Now;
                produto.Status = true;
                produto.Ativo = true;

                _produtoRepository.Create(produto);

                if (_uow.Commit() > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
