using Catalogo.Applictation.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Applictation.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetById(int? id);
        Task Add(CategoriaDTO categoria);
        Task Remove(int? id);

        Task Update(CategoriaDTO categoria);

    }
}
