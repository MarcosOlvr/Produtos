using Microsoft.AspNetCore.Mvc;

namespace Produtos.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduto()
        {
            return View();
        }
    }
}
