using Microsoft.AspNetCore.Mvc;
using Produtos.Models;
using Produtos.Repositories.Contracts;

namespace Produtos.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Categoria> categorias = _repository.GetAll();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult AddCategoria() 
        {
            return View();
        }
    }
}
