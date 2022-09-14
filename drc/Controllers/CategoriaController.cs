using AutoMapper;
using Dominio.Entidade;
using Dominio.Servico;
using drc.Models;
using Microsoft.AspNetCore.Mvc;

namespace drc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _categoriasService;
        private readonly UnidadeMedidaService _unidadeMedidaService;
        private readonly IMapper _mapper;

        public CategoriaController(CategoriaService categoriasService,
                                  IMapper mapper)
        {
            _categoriasService = categoriasService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var categorias = _categoriasService.GetAll();
            var categoriasView = _mapper.Map<IEnumerable<CategoriaVM>>(categorias);
            return View(categoriasView);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(CategoriaVM model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);

                return Json(_categoriasService.Create(categoria));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Editar(int id)
        {
            var categoria = _categoriasService.GetById(id);
            var editcategoria = _mapper.Map<CategoriaVM>(categoria);

            return View(editcategoria);
        }

        [HttpPost]
        public JsonResult Editar(CategoriaVM model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);

                return Json(_categoriasService.Update(categoria));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Visualizar(int id)
        {
            var categoria = _categoriasService.GetById(id);
            return Json(categoria);
        }

        [HttpPost]
        public void Excluir(int id)
        {
            try
            {
                _categoriasService.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
