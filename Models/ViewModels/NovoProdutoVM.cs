namespace Produtos.Models.ViewModels
{
    public class NovoProdutoVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int CategoriaFK { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
