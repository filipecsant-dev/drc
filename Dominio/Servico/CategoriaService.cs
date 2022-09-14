using Dominio.Entidade;
using Dominio.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class CategoriaService
    {
        private readonly IBaseRepository<Categoria> _categoriaRepository;
        private readonly IUOW _uow;
        public CategoriaService(IBaseRepository<Categoria> categoriaRepository, IUOW uow)
        {
            _categoriaRepository = categoriaRepository;
            _uow = uow;
        }

        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                return _categoriaRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Categoria GetById(int id)
        {
            try
            {
                return _categoriaRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Categoria Categoria)
        {
            try
            {
                Categoria.Data_Alteracao = DateTime.Now;

                _categoriaRepository.Update(Categoria);

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
                var Categoria = _categoriaRepository.GetById(id);
                _categoriaRepository.Delete(Categoria);
                _uow.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Create(Categoria Categoria)
        {
            try
            {
                Categoria.Data_Cadastro = DateTime.Now;
                Categoria.Data_Alteracao = DateTime.Now;
                Categoria.Status = true;
                Categoria.Ativo = true;

                _categoriaRepository.Create(Categoria);

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
