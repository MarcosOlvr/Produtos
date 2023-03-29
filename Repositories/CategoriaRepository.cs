using Produtos.Data;
using Produtos.Models;
using Produtos.Repositories.Contracts;

namespace Produtos.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appContext) : base(appContext) 
        {
            
        }
    }
}
