using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly DataContext _context;

        // Inyectamos el DataContext para interactuar con SQL Server
        public AulasController(DataContext context)
        {
            _context = context;
        }

        // 1. OBTENER TODAS LAS AULAS (GET)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AulaDto>>> Get()
        {
            var aulas = await _context.Aulas.ToListAsync();

            // Mapeo manual de Entidad a DTO
            var aulasDto = aulas.Select(a => new AulaDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Ubicacion = a.Ubicacion
            }).ToList();

            return Ok(aulasDto);
        }

        // 2. OBTENER UNA AULA POR ID (GET)
        [HttpGet("{id}")]
        public async Task<ActionResult<AulaDto>> GetById(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);

            if (aula == null)
            {
                return NotFound("El aula no existe.");
            }

            var aulaDto = new AulaDto
            {
                Id = aula.Id,
                Nombre = aula.Nombre,
                Ubicacion = aula.Ubicacion
            };

            return Ok(aulaDto);
        }

        // 3. CREAR UNA NUEVA AULA (POST)
        [HttpPost]
        public async Task<ActionResult<AulaDto>> Post(CreateAulaDto createDto)
        {
            var nuevaAula = new Aulas
            {
                Nombre = createDto.Nombre,
                Ubicacion = createDto.Ubicacion
            };

            _context.Aulas.Add(nuevaAula);
            await _context.SaveChangesAsync(); // Guarda en la BD real

            var resultadoDto = new AulaDto
            {
                Id = nuevaAula.Id,
                Nombre = nuevaAula.Nombre,
                Ubicacion = nuevaAula.Ubicacion
            };

            return CreatedAtAction(nameof(GetById), new { id = resultadoDto.Id }, resultadoDto);
        }

        // 4. ACTUALIZAR UNA AULA (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateAulaDto updateDto)
        {
            var aulaDb = await _context.Aulas.FindAsync(id);

            if (aulaDb == null)
            {
                return NotFound("Aula no encontrada.");
            }

            aulaDb.Nombre = updateDto.Nombre;
            aulaDb.Ubicacion = updateDto.Ubicacion;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 5. ELIMINAR UNA AULA (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aulaDb = await _context.Aulas.FindAsync(id);

            if (aulaDb == null)
            {
                return NotFound("Aula no encontrada.");
            }

            _context.Aulas.Remove(aulaDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}