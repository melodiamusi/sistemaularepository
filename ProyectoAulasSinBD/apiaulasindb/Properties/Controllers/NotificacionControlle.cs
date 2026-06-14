using apiaulasindb.Data;
using apiaulasindb.Entidades; // <-- Esto es lo que le falta para encontrar 'Notificacion'
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly DataContext _context;

        public NotificacionController(DataContext context)
        {
            _context = context;
        }

        // 1. GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacionDto>>> Get()
        {
            var notif = await _context.Notificaciones.ToListAsync();
            return Ok(notif.Select(n => new NotificacionDto { Id = n.Id, UsuarioId = n.UsuarioId, Mensaje = n.Mensaje }));
        }

        // 2. GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacionDto>> GetById(int id)
        {
            var n = await _context.Notificaciones.FindAsync(id);
            if (n == null) return NotFound("Notificación no encontrada.");
            return Ok(new NotificacionDto { Id = n.Id, UsuarioId = n.UsuarioId, Mensaje = n.Mensaje });
        }

        // 3. POST (CREATE)
        [HttpPost]
        public async Task<ActionResult<NotificacionDto>> Post(CreateNotificacionDto dto)
        {
            var nuevo = new Notificación { UsuarioId = dto.UsuarioId, Mensaje = dto.Mensaje };
            _context.Notificaciones.Add(nuevo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, new NotificacionDto { Id = nuevo.Id, UsuarioId = nuevo.UsuarioId, Mensaje = nuevo.Mensaje });
        }

        // 4. PUT (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateNotificacionDto dto)
        {
            var n = await _context.Notificaciones.FindAsync(id);
            if (n == null) return NotFound();
            n.UsuarioId = dto.UsuarioId; n.Mensaje = dto.Mensaje;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 5. DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var n = await _context.Notificaciones.FindAsync(id);
            if (n == null) return NotFound();
            _context.Notificaciones.Remove(n);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}