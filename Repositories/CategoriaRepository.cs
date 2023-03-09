using Produtos.Data;
using Produtos.Models;
using Produtos.Repositories.Contracts;

namespace Produtos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _db;

        public CategoriaRepository(AppDbContext db) 
        {
            _db = db;
        }

        public void AddCategoria(Categoria obj)
        {
            _db.Categorias.Add(obj);
            _db.SaveChanges();
        }

        public void DeleteCategoria(int id)
        {
            Categoria categoria = _db.Categorias.Find(id);

            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> categorias = _db.Categorias.ToList();

            return categorias;
        }

        public Categoria GetCategoria(int id)
        {
            Categoria categoria = _db.Categorias.Find(id);

            return categoria;
        }

        public void UpdateCategoria(Categoria obj)
        {
            _db.Categorias.Update(obj);
            _db.SaveChanges();
        }
    }
}
