using AutoMapper;
using Catalogo.Applictation.DTOs;
using Catalogo.Applictation.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Applictation.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task Add(ProdutoDTO produto)
        {
            var produtoAdd = _mapper.Map<Produto>(produto);
            await _produtoRepository.CreateAsync(produtoAdd);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.GetProdutosAsync());
        }

        public async Task Remove(int? id)
        {
            var produtoRemove = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produtoRemove);
        }

        public async Task Update(ProdutoDTO produto)
        {
            var produtoUp = _mapper.Map<Produto>(produto);
            await _produtoRepository.UpdateAsync(produtoUp);
        }
    }
}
