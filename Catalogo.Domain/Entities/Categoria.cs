using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
