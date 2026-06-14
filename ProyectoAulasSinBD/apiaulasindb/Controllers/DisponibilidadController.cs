using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadController : ControllerBase
    {
        private readonly DataContext _context;
        public DisponibilidadController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisponibilidadDto>>> Get()
        {
            var disp = await _context.Disponibilidades.ToListAsync();
            return Ok(disp.Select(d => new DisponibilidadDto { Id = d.Id, AulaId = d.AulaId, Estado = d.Estado }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisponibilidadDto>> GetById(int id)
        {
            var d = await _context.Disponibilidades.FindAsync(id);
            if (d == null) return NotFound("Disponibilidad no encontrada.");
            return Ok(new DisponibilidadDto { Id = d.Id, AulaId = d.AulaId, Estado = d.Estado });
        }

        [HttpPost]
        public async Task<ActionResult<DisponibilidadDto>> Post(CreateDisponibilidadDto dto)
        {
            var nuevo = new Disponibilidad { AulaId = dto.AulaId, Estado = dto.Estado };
            _context.Disponibilidades.Add(nuevo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, new DisponibilidadDto { Id = nuevo.Id, AulaId = nuevo.AulaId, Estado = nuevo.Estado });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateDisponibilidadDto dto)
        {
            var d = await _context.Disponibilidades.FindAsync(id);
            if (d == null) return NotFound();
            d.AulaId = dto.AulaId; d.Estado = dto.Estado;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var d = await _context.Disponibilidades.FindAsync(id);
            if (d == null) return NotFound();
            _context.Disponibilidades.Remove(d);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}