using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly DataContext _context;
        public ReservaController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDto>>> Get()
        {
            var reservas = await _context.Reservas.ToListAsync();
            return Ok(reservas.Select(r => new ReservaDto { Id = r.Id, AulaId = r.AulaId, UsuarioId = r.UsuarioId, Fecha = r.Fecha }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> GetById(int id)
        {
            var r = await _context.Reservas.FindAsync(id);
            if (r == null) return NotFound();
            return Ok(new ReservaDto { Id = r.Id, AulaId = r.AulaId, UsuarioId = r.UsuarioId, Fecha = r.Fecha });
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDto>> Post(CreateReservaDto dto)
        {
            var nuevo = new Reserva { AulaId = dto.AulaId, UsuarioId = dto.UsuarioId, Fecha = dto.Fecha };
            _context.Reservas.Add(nuevo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, new ReservaDto { Id = nuevo.Id, AulaId = nuevo.AulaId, UsuarioId = nuevo.UsuarioId, Fecha = nuevo.Fecha });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateReservaDto dto)
        {
            var r = await _context.Reservas.FindAsync(id);
            if (r == null) return NotFound();
            r.AulaId = dto.AulaId; r.UsuarioId = dto.UsuarioId; r.Fecha = dto.Fecha;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _context.Reservas.FindAsync(id);
            if (r == null) return NotFound();
            _context.Reservas.Remove(r);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}