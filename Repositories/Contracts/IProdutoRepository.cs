using Produtos.Models;
using Produtos.Models.ViewModels;

namespace Produtos.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        Produto GetProduto(int id);
        void DeleteProduto(int id);
        void AddProduto(NovoProdutoVM obj);
        void UpdateProduto(NovoProdutoVM obj);
    }
}
