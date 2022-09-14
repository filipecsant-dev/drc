using AutoMapper;
using Dominio.Entidade;
using Dominio.Servico;
using drc.Models;
using Microsoft.AspNetCore.Mvc;

namespace drc.Controllers
{
    public class UnidadeMedidaController : Controller
    {
        private readonly UnidadeMedidaService _unidadeMedidaService;
        private readonly IMapper _mapper;

        public UnidadeMedidaController(UnidadeMedidaService unidadeMedidaService,
                                  IMapper mapper)
        {
            _unidadeMedidaService = unidadeMedidaService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var unidadeMedida = _unidadeMedidaService.GetAll();
            var unidadeMedidaView = _mapper.Map<IEnumerable<UnidadeMedidaVM>>(unidadeMedida);
            return View(unidadeMedidaView);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(UnidadeMedidaVM model)
        {
            try
            {
                var UnidadeMedida = _mapper.Map<UnidadeMedida>(model);

                return Json(_unidadeMedidaService.Create(UnidadeMedida));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Editar(int id)
        {
            var UnidadeMedida = _unidadeMedidaService.GetById(id);
            var editUnidadeMedida = _mapper.Map<UnidadeMedidaVM>(UnidadeMedida);

            return View(editUnidadeMedida);
        }

        [HttpPost]
        public JsonResult Editar(UnidadeMedidaVM model)
        {
            try
            {
                var UnidadeMedida = _mapper.Map<UnidadeMedida>(model);

                return Json(_unidadeMedidaService.Update(UnidadeMedida));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Visualizar(int id)
        {
            var UnidadeMedida = _unidadeMedidaService.GetById(id);
            return Json(UnidadeMedida);
        }

        [HttpPost]
        public void Excluir(int id)
        {
            try
            {
                _unidadeMedidaService.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
