using Microsoft.AspNetCore.Mvc;
using Produtos.Models;
using Produtos.Models.ViewModels;
using Produtos.Repositories.Contracts;

namespace Produtos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repository;
        private readonly ICategoriaRepository _categoriaRepo;

        public ProdutosController(IProdutoRepository repository, ICategoriaRepository categoriaRepo)
        {
            _repository = repository;
            _categoriaRepo = categoriaRepo;
        }

        public IActionResult Index()
        {
            VisualizarProdutosVM vm = new VisualizarProdutosVM();

            vm.Produtos = _repository.GetAll();
            vm.Categorias = _categoriaRepo.GetAll();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            NovoProdutoVM vm = new NovoProdutoVM();
            vm.Categorias = _categoriaRepo.GetAll();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NovoProdutoVM obj)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto();

                produto.Nome = obj.Nome;
                produto.Preco = obj.Preco;
                produto.Id = obj.Id;
                produto.CategoriaFK = obj.CategoriaFK;

                _repository.Add(produto);

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            NovoProdutoVM vm = new NovoProdutoVM();
            var produto = _repository.Get(id);
            vm.Nome = produto.Nome;
            vm.Preco = produto.Preco;
            vm.CategoriaFK = produto.CategoriaFK;
            vm.Categorias = _categoriaRepo.GetAll();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NovoProdutoVM obj)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto();

                produto.Nome = obj.Nome;
                produto.Preco = obj.Preco;
                produto.Id = obj.Id;
                produto.CategoriaFK = obj.CategoriaFK;

                _repository.Update(produto);

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            NovoProdutoVM vm = new NovoProdutoVM();
            var produto = _repository.Get(id);
            vm.Nome = produto.Nome;
            vm.Preco = produto.Preco;
            vm.CategoriaFK = produto.CategoriaFK;
            vm.Categorias = _categoriaRepo.GetAll();

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
