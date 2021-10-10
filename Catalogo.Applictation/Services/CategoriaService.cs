using AutoMapper;
using Catalogo.Applictation.DTOs;
using Catalogo.Applictation.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Applictation.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoriaDTO categoria)
        {
           var categoriaAdd =  _mapper.Map<Categoria>(categoria);
           await _categoriaRepository.CreateAsync(categoriaAdd);
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            return _mapper.Map<CategoriaDTO>(await _categoriaRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _categoriaRepository.GetCategoriasAsync());
        }
        
        //No Remove nao precisa Mapear
        public async Task Remove(int? id)
        {
            var categoriaRemove = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.RemoveAsync(categoriaRemove);
        }

        public async Task Update(CategoriaDTO categoria)
        {
            var categoriaUpdate = _mapper.Map<Categoria>(categoria);
            await _categoriaRepository.UpdateAsync(categoriaUpdate);
        }
    }
}
