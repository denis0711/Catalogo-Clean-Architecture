using Catalogo.Applictation.DTOs;
using Catalogo.Applictation.Interfaces;
using Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias =  await _categoriaService.GetCategorias();

            return Ok(categorias);
        } 

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _categoriaService.GetById(id);

            if(categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _categoriaService.Add(categoriaDTO);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoria = await _categoriaService.GetById(id);

            if (categoria == null) return NotFound();

            await _categoriaService.Update(categoriaDTO);

            return Ok(categoriaDTO);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null) return NotFound();

            await _categoriaService.Remove(id);

            return Ok($"Categoria deletada com Sucesso");
        }
    }
}
