using Dominio.Entidade;
using Dominio.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class UnidadeMedidaService
    {
        private readonly IBaseRepository<UnidadeMedida> _unidadeMedidaRepository;
        private readonly IUOW _uow;
        public UnidadeMedidaService(IBaseRepository<UnidadeMedida> unidadeMedidaRepository, IUOW uow)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _uow = uow;
        }

        public IEnumerable<UnidadeMedida> GetAll()
        {
            try
            {
                return _unidadeMedidaRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public UnidadeMedida GetById(int id)
        {
            try
            {
                return _unidadeMedidaRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(UnidadeMedida UnidadeMedida)
        {
            try
            {
                UnidadeMedida.Data_Alteracao = DateTime.Now;

                _unidadeMedidaRepository.Update(UnidadeMedida);

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
                var UnidadeMedida = _unidadeMedidaRepository.GetById(id);
                _unidadeMedidaRepository.Delete(UnidadeMedida);
                _uow.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Create(UnidadeMedida UnidadeMedida)
        {
            try
            {
                UnidadeMedida.Data_Cadastro = DateTime.Now;
                UnidadeMedida.Data_Alteracao = DateTime.Now;
                UnidadeMedida.Ativo = true;

                _unidadeMedidaRepository.Create(UnidadeMedida);

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
