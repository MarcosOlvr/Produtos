using Produtos.Data;
using Produtos.Models;
using Produtos.Models.ViewModels;
using Produtos.Repositories.Contracts;

namespace Produtos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _db;

        public ProdutoRepository(AppDbContext db)
        {
            _db = db;
        }

        public void AddProduto(NovoProdutoVM obj)
        {
            Produto produto = new Produto();
            produto.Nome = obj.Nome;
            produto.Preco = obj.Preco;
            produto.CategoriaFK = obj.CategoriaFK;

            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        public void DeleteProduto(int id)
        {
            Produto produto = _db.Produtos.Find(id);

            _db.Produtos.Remove(produto);
            _db.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            List<Produto> produtos = _db.Produtos.ToList();

            return produtos;
        }

        public Produto GetProduto(int id)
        {
            Produto produto = _db.Produtos.Find(id);

            return produto;
        }

        public void UpdateProduto(NovoProdutoVM obj)
        {
            Produto produto = _db.Produtos.Find(obj.Id);

            produto.Nome = obj.Nome;
            produto.Preco = obj.Preco;
            produto.CategoriaFK = obj.CategoriaFK;

            _db.Produtos.Update(produto);
            _db.SaveChanges();
        }
    }
}
