using AutoMapper;
using Dominio.Entidade;
using Dominio.Servico;
using drc.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace drc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _produtosService;
        private readonly CategoriaService _categoriasService;
        private readonly UnidadeMedidaService _unidadeMedidaService;
        private readonly IMapper _mapper;

        public ProdutoController(ProdutoService produtosService,
                                  CategoriaService categoriasService,
                                  UnidadeMedidaService unidadeMedidaService,
                                  IMapper mapper)
        {
            _produtosService = produtosService;
            _categoriasService = categoriasService;
            _unidadeMedidaService = unidadeMedidaService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var produtos = _produtosService.GetAll();
            var produtosView = _mapper.Map<IEnumerable<ProdutoVM>>(produtos);
            return View(produtosView);
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categoria = _categoriasService.GetAll();
            ViewBag.UnidadeMedida = _unidadeMedidaService.GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(ProdutoVM model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                return Json(_produtosService.Create(produto));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Categoria = _categoriasService.GetAll();
            ViewBag.UnidadeMedida = _unidadeMedidaService.GetAll();

            var produto = _produtosService.GetById(id);
            var editProduto = _mapper.Map<ProdutoVM>(produto);

            return View(editProduto);
        }

        [HttpPost]
        public JsonResult Editar(ProdutoVM model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);

                return Json(_produtosService.Update(produto));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Visualizar(int id)
        {
            var produto = _produtosService.GetById(id);
            return Json(produto);
        }

        [HttpPost]
        public void Excluir(int id)
        {
            try
            {
                _produtosService.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
