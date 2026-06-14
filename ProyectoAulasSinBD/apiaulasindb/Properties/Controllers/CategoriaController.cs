using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var categorias = await _context.Categorias.ToListAsync();
            var categoriasDto = categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre
            }).ToList();

            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetById(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound("La categoría no existe.");
            }

            var categoriaDto = new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };

            return Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> Post(CreateCategoriaDto createDto)
        {
            var nuevaCategoria = new Categoria
            {
                Nombre = createDto.Nombre
            };

            _context.Categorias.Add(nuevaCategoria);
            await _context.SaveChangesAsync();

            var resultadoDto = new CategoriaDto
            {
                Id = nuevaCategoria.Id,
                Nombre = nuevaCategoria.Nombre
            };

            return CreatedAtAction(nameof(GetById), new { id = resultadoDto.Id }, resultadoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateCategoriaDto updateDto)
        {
            var categoriaDb = await _context.Categorias.FindAsync(id);

            if (categoriaDb == null)
            {
                return NotFound("Categoría no encontrada.");
            }

            categoriaDb.Nombre = updateDto.Nombre;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaDb = await _context.Categorias.FindAsync(id);

            if (categoriaDb == null)
            {
                return NotFound("Categoría no encontrada.");
            }

            _context.Categorias.Remove(categoriaDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}