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
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCategoria(categoria);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var categoria = _repository.GetCategoria(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria obj)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCategoria(obj);

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            Categoria categoria = _repository.GetCategoria(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _repository.DeleteCategoria(id);

            return RedirectToAction("Index");
        }
    }
}
