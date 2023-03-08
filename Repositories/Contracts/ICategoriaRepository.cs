using Produtos.Models;

namespace Produtos.Repositories.Contracts
{
    public interface ICategoriaRepository
    {
        void AddCategoria(Categoria obj);
        Categoria GetCategoria(int id);
        List<Categoria> GetAll();
    }
}
