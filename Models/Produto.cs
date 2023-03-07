namespace Produtos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
        public int CategoriaFK { get; set; }
    }
}
