using Catalogo.Applictation.DTOs;
using Catalogo.Applictation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.GetProdutos();

            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtoService.GetById(id);

            if (produto == null) return NotFound();

            return Ok(produto);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _produtoService.Add(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var produto = await _produtoService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }

            await _produtoService.Update(produtoDTO);
            return Ok(produtoDTO);
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produto = await _produtoService.GetById(id);
            if (produto == null)
            {
                NotFound();
            }

            await _produtoService.Remove(id);

            return Ok($"Produto {produto} excluido com Sucesso");
        }


    }
}
