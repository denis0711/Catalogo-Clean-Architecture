namespace Catalogo.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
