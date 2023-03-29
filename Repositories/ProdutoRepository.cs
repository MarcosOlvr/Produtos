using Produtos.Data;
using Produtos.Models;
using Produtos.Models.ViewModels;
using Produtos.Repositories.Contracts;

namespace Produtos.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext appContext) : base(appContext) 
        { 
            
        }  
    }
}
