using Catalogo.Applictation.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Applictation.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetById(int? id);

        Task Add(ProdutoDTO produto);
        Task Remove(int? id);
        Task Update(ProdutoDTO produto);
    }
}
